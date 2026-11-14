# -*- coding: utf-8 -*-
"""Deepen every shelved book entry: excerpt, provenance, what it teaches, hooks into the game data.
Called by shelve.py after the shelving pass. Deterministic (seeded by book id); nothing is invented about Canon.
 - excerpt: verbatim lines from the book's own (repaired) text, chosen as the least-repeated paragraph so it reads like THIS book.
 - provenance: tradition (from the gazetteer epithet), region, era from the in-world date line, copy condition and shelf place
   (generated flavour, draft like the rest of the shelf).
 - teaches / hooks: from the book's kind and from names the text really mentions that exist in Data/ (species, items, recipes, regions,
   places, civilizations) plus the eight gods of the week. canonNotes: where the text touches something Canon fixes.
"""
import re, random, json, os, collections

GODS = ['Solenne', 'Maelis', 'Thorgrim', 'Sylvara', 'Kaelthas', 'Morrowyn', 'Vex', 'Ilvaris']
CIVS = {'civ_valdrisia': r'Valdris', 'civ_draconic': r'Draconic|dragon-tongue', 'civ_titans': r'\bTitan', 'civ_khazdur': r'Khazd|Khazdûr'}
WEEKDAYS = ['Solenday', 'Maelsday', 'Thorsday', 'Sylvasday', 'Kaelsday', 'Morrowsday', 'Vexday']
PRESENT = 1024
SPLIT = re.compile(r'(?<=[.!?])\s+|\n+')
STOCK = re.compile(r'listens by way of|A speaker at|Both saw the same hour|stayed honest|is not a relic|argument has moved|Evidence you can touch|public devotion|Margins belong|If two copies disagree|Neither is lying|made their own choice look worse|different banks|remembering a (person|rule)|Copy the object')

CONDITIONS = [
    'Sewn quires, the spine re-stitched in waxed thread.', 'Water-stained along the lower edge but fully legible.',
    'Corners rounded by many thumbs; a tea ring on the second page.', 'Clean and stiff, plainly little read.',
    'Margins crowded with later readers’ notes in three hands.', 'Pages brittle at the fold; handle with a flat palm.',
    'A pressed leaf marks the middle; nobody has dared remove it.', 'Cover re-covered in oilcloth by the last keeper.',
    'Foxed with age, ink faded brown but sound.', 'Loose gatherings tied together with a ribbon.',
    'A child’s pencil drawing in the back, left in on purpose.', 'Bound in plain board, the title lettered by hand.',
]
SHELF_PLACES = {
    'library': ['on the low shelf by the window', 'in the second case from the door', 'in the reading-table drawer', 'on the top shelf, reached by the step-stool'],
    'archive': ['in a labelled box on the second rack', 'in the clerk’s drawer, between two ledgers', 'on the open shelf beside the copying desk'],
    'temple': ['on the shrine-side shelf, under the lamp', 'in the keeper’s chest by the door', 'on the pilgrims’ table near the offering bowl'],
    'school': ['in the students’ stack by the lecture room', 'on the lecturer’s shelf, behind the slate', 'in the copying room, third desk'],
    'guild_hall': ['on the branch shelf behind the board', 'in the newcomers’ box under the notice wall', 'on the clerk’s counter, tied with cord'],
}
TEACH = {
    'field_guide': ['How folk around {place} file each creature by Guild rank, and what they say it fears.', 'Which approaches locals think are mistakes, with the rumour clearly marked as rumour.'],
    'cookery': ['Plain working recipes of {region}, with the kitchen quarrels behind them.', 'What a household of {region} keeps in the larder and why.'],
    'road_book': ['A leg-by-leg walk with the named roads and the habits of each crossing.', 'What a careful traveller of {region} watches for before the weather turns.'],
    'local_history': ['Two retellings of the past of {region}, set side by side.', 'A reminder that every account is written by someone who benefits from the version.'],
    'household_book': ['The small rules of a shared home in {region}: lamps, guests, mending.', 'How ordinary people of {region} keep a house at peace.'],
    'craft_notes': ['Bench habits of {region} makers: materials, tools and mistakes worth making only once.', 'Why a careful maker writes the material on the work before bragging.'],
    'myth_telling': ['How {region} tells the gods and which version the tellers argue over.', 'What a sceptic, a child and a keeper each take from the same story.'],
    'guild_manual': ['How the Guild branch near {place} runs: forms, slang, rank etiquette.', 'What the board will not say out loud and the courtesy that fills the gap.'],
    'chapel_notes': ['What a shrine floor in {region} sees across a week.', 'The quiet customs of keepers, mourners and festival crowds.'],
    'trade_notes': ['Goods that pass through {region}, as rules of thumb and not promises.', 'Who buys what, and which quarrels over price are for show.'],
    'letter_book': ['Ordinary news from {region}, kept because someone could not throw it away.', 'How people of {region} write to those who left.'],
    'law_notes': ['What a neighbour, a guard and a clerk of {region} each expect of you.', 'The difference between the written rule and the street rule.'],
    'academy_lecture': ['A copied lecture on magic as it is practised near {place}.', 'The questions a tired student writes in the margin.'],
    'ballad_sheet': ['Songs of {region} with the verses people disagree about.', 'How a tune moves from one town to the next and changes.'],
    'veilborn_memoir': ['A Veilborn cook’s way of making an old-world kitchen work in Aethwyrd.', 'What it is like to be kind to strangers in a new world.'],
    'story_aloud': ['Stories for a lamp-lit room in {region}, with the pauses marked.', 'The small lesson each story leaves, never spelled out.'],
    'play': ['A short play for two voices and one latch, staged near {place}.', 'How a household drama settles without a villain.'],
    'valdrisian_fragment': ['Potsherd readings of the old empire as copied in {region}.', 'The copyists’ doubts, left in the margin on purpose. Public history only.'],
    'festival_notes': ['The year’s festivals in {region}, by household, shrine and branch hall.', 'What each festival asks of a guest.'],
    'romance_serial': ['One volume of the Aldmere serial of the Knight and the Wyvern Princess.', 'A story people of {region} pass hand to hand; fiction, not history.'],
}


def para_candidates(text):
    out = []
    for p in re.split(r'\n\s*\n', text):
        p = p.strip()
        if not p or p.startswith('#') or p.startswith('**') or p.startswith('---') or p.startswith('*End of this copy') or p.startswith('*') and p.endswith('*') and len(p) < 90:
            continue
        if len(p) < 70:
            continue
        out.append(p)
    return out


def trim(p, limit=420):
    p = re.sub(r'\s+', ' ', p)
    if len(p) <= limit:
        return p
    sents = re.split(r'(?<=[.!?])\s+', p)
    acc = ''
    for s in sents:
        if len(acc) + len(s) + 1 > limit:
            break
        acc = (acc + ' ' + s).strip()
    return acc or p[:limit].rsplit(' ', 1)[0] + '…'


def run(books, texts, ctx):
    """books: list of entries (dicts), texts: bid -> final text, ctx: dict with regions, species, items, recipes, gazetteer."""
    para_count = collections.Counter()
    cands = {}
    for bid, t in texts.items():
        c = para_candidates(t)
        cands[bid] = c
        for p in set(c):
            para_count[p] += 1
    sent_count = collections.Counter()
    for t in texts.values():
        for x in set(y.strip() for y in SPLIT.split(t) if len(y.strip()) > 15):
            sent_count[x] += 1
    def freq(p):
        ss = [y.strip() for y in SPLIT.split(p) if len(y.strip()) > 15]
        return sum(sent_count[x] for x in ss) / max(1, len(ss))
    quests_by_region = collections.defaultdict(list)
    for q in ctx.get('quests', []):
        if q.get('region'):
            quests_by_region[q['region']].append(q)
    species = [(s['name'], s['id']) for s in ctx['species'] if len(s['name']) >= 4 and not s.get('variantKind')]
    species.sort(key=lambda x: -len(x[0]))
    items = [(i['name'], i['id']) for i in ctx['items'] if len(i['name']) >= 5]
    items.sort(key=lambda x: -len(x[0]))
    recipes = [(r['name'], r['id']) for r in ctx['recipes'] if len(r['name']) >= 5]
    reg_names = [(r['name'], r['id']) for r in ctx['regions'] if len(r['name']) >= 5 and r['layer'] != 'post-game']
    place_to_region = {}
    for r in ctx['regions']:
        for pl in list((r.get('map') or {}).get('places') or {}) + list(r.get('defenceSettlements') or []):
            place_to_region.setdefault(pl, r['id'])
    for b in books:
        if not b['library']:
            continue
        t = texts[b['id']]
        rng = random.Random('deepen-' + b['id'])
        reg = ctx['reg_by_id'].get(b['subjectRegion'])
        rname = reg['name'] if reg else 'Aldmere'
        gaz = ctx['gaz'].get(b['subjectRegion'] or '', {})
        epithet = gaz.get('epithet') or rname
        places = [p for p in place_to_region if re.search(r'\b' + re.escape(p) + r'\b', t)]
        own_places = [p for p in place_to_region if place_to_region[p] == b['subjectRegion']]
        place = (places[0] if places else (own_places[0] if own_places else rname))
        # excerpt: least repeated paragraph, then the one that mentions the place, then the longest within range
        cs = cands[b['id']]
        scored = sorted(cs, key=lambda p: (1 if STOCK.search(p) else 0, 0 if place in p or rname in p else 1, round(freq(p) / 5), abs(len(p) - 260)))
        ex = trim(scored[0]) if scored else trim(t[:420])
        if scored and STOCK.search(scored[0]):
            # every paragraph is frame text: take the three rarest whole sentences of the body, in reading order
            body = t.split('Written as what a person in Aethwyrd could know.', 1)[-1]
            sents = [y.strip() for y in SPLIT.split(body) if 45 <= len(y.strip()) <= 230 and not y.strip().startswith(('#', '*', '-')) and not STOCK.search(y)]
            if len(sents) >= 2:
                pick = sorted(sents, key=lambda y: (sent_count[y], 0 if place in y or rname in y else 1))[:3]
                ex = trim(' '.join(y for y in sents if y in pick))
        if 'handwritten' in b['source']:
            # a hand-written book is excerpted from its opening: the first body paragraph of real length
            first = [p for p in cs if len(p) >= 100]
            if first:
                ex = trim(first[0])
        b['excerpt'] = ex
        m = re.match(r'(\d{3,4})', b.get('inWorldDate') or '')
        year = int(m.group(1)) if m else None
        era = (f'about {year} SC, {PRESENT - year} years before the present (1024 SC)' if year and year < PRESENT else (b.get('inWorldDate') or 'undated'))
        lib = ctx['lib_by_id'][b['library']]
        b['provenance'] = {
            'tradition': f'{epithet} tradition of {rname}', 'writtenIn': b['subjectRegion'] or lib['region'], 'era': era,
            'copy': rng.choice(CONDITIONS), 'shelfPlace': f"{rng.choice(SHELF_PLACES[lib['type']])}, {lib['name']}",
        }
        teaches = [s.format(region=rname, place=place) for s in TEACH[b['kind']]]
        hooks = []
        seen = set()
        def add(kind, id_, note):
            if (kind, id_) in seen:
                return
            seen.add((kind, id_)); hooks.append({'kind': kind, 'id': id_, 'note': note})
        if b['subjectRegion']:
            add('region', b['subjectRegion'], f'The region this book is about ({rname}).')
        for p in places[:3]:
            add('place', p, 'A settlement or place the text names.')
        sp_hits = []
        for n, i in species:
            if re.search(r'\b' + re.escape(n) + r'\b', t) and i not in [h['id'] for h in hooks]:
                sp_hits.append((n, i))
        reward_ids = {r['id'] for r in b.get('rewards', []) if r['kind'] == 'bestiary'}
        for n, i in sp_hits[:6]:
            add('species', i, 'Named in this book' + ('; reading it marks the species Seen.' if i in reward_ids else '.'))
        it_hits = [(n, i) for n, i in items if re.search(r'\b' + re.escape(n) + r'\b', t, re.I)]
        for n, i in it_hits[:4]:
            add('item', i, 'A material or item the text mentions.')
        for n, i in [(n, i) for n, i in recipes if re.search(r'\b' + re.escape(n) + r'\b', t, re.I)][:3]:
            add('recipe', i, 'A craft the text mentions.')
        for n, i in reg_names:
            if i != b['subjectRegion'] and re.search(r'\b' + re.escape(n) + r'\b', t):
                add('region', i, f'Another region the text mentions ({n}).')
        if b['kind'] in ('field_guide', 'road_book', 'local_history', 'guild_manual', 'trade_notes', 'law_notes') and b['subjectRegion']:
            for q in quests_by_region.get(b['subjectRegion'], [])[:2]:
                add('quest', q['id'], 'A quest in this region; the book is background reading, never a requirement.')
        for cid, rx in CIVS.items():
            if re.search(rx, t):
                add('civilization', cid, 'An old civilization the text mentions (public account only).')
        for g in GODS:
            if re.search(r'\b' + g + r'\b', t):
                add('god', g, 'A god of the week the text names.')
        b['hooks'] = hooks[:14]
        if sp_hits:
            teaches.append('Species it names: ' + ', '.join(n for n, i in sp_hits[:6]) + '.')
        notes = []
        if any(d in t for d in WEEKDAYS):
            notes.append('Uses the seven-day week of Canon section 2 (Solenday to Vexday).')
        if re.search(r'\b(rank|Rank) ?[A-FS]\b|[A-FS]-rank|guild rank', t):
            notes.append('Mentions Guild ranks (Canon section 2, F to SSS).')
        if b['kind'] == 'valdrisian_fragment' or re.search(r'Valdris', t):
            notes.append('Public account of the old empire only; what Canon section 3 fixes about its fate is not stated here.')
        if re.search(r'Labyrinth', t):
            notes.append('Mentions the Great Labyrinth (halls reset weekly, Canon section 6).')
        if b['kind'] == 'veilborn_memoir':
            notes.append('Written from what one Veilborn could know; it explains no secret.')
        b['teaches'] = teaches
        if notes:
            b['canonNotes'] = notes
    return books
