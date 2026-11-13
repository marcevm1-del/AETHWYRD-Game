# -*- coding: utf-8 -*-
"""Scan, repair and shelve the draft book shelf into the repo.

Reads the originals (never edits them) from <books_dir> (catalog.json + aethwyrd/*.md), runs the spoiler / canon
scan (Canon section 3), applies minimal repairs, then writes:
  02_Lore/library/<library-id>/<book-id>.md   repaired copies
  Data/Library/books.json, Data/Library/libraries.json
  13_Production/library_scan_report.json     machine-readable result for every book
Usage: python Tools/library/shelve.py <books_dir> [--dry]
Docs: 12_Systems/libraries_and_books.md
"""
import json, os, re, sys, collections, glob, datetime

REPO = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..'))
books_dir = sys.argv[1]
DRY = '--dry' in sys.argv
cat = json.load(open(os.path.join(books_dir, 'catalog.json'), encoding='utf-8'))
regions = json.load(open(os.path.join(REPO, 'Data/World/regions.json'), encoding='utf-8'))
species = json.load(open(os.path.join(REPO, 'Data/Monsters/species.json'), encoding='utf-8'))
sys.path.insert(0, os.path.dirname(__file__))
reg_by_name = {r['name']: r for r in regions}
reg_by_name['Great Labyrinth (Floors 1-40)'] = next(r for r in regions if r['id'] == 'reg_labyrinth_upper')
sp_by_name = {s['name']: s for s in species}
import gap_books
GAP = gap_books.make_gap(os.path.abspath(books_dir), species, regions)
N_ORIGINAL = len(cat)
cat = cat + GAP
RANKS = ['F', 'E', 'D', 'C', 'B', 'A', 'S', 'SS', 'SSS', 'EX']

# ---------- scan rules (Canon section 3 and the other-studio / real-world / teen checks) ----------
HOLD = [
    ('azrael', r'Azrael|Noxveil'), ('adrian_vale', r'\bAdrian\b|\bAdrian Vale\b'), ('hero_numbers', r'\bHero #?[123]\b|Hero (One|Two|Three)\b|first Hero|third Hero'),
    ('tomas_seal', r'Tom[aá]s Reyes|Lantern Seal|Lantern Night'), ('malgareth', r'Malgareth|Malchior|\bVane\b|Red Prophet|Night of Unweaving'),
    ('caspian', r'Caspian'), ('nocturne', r'Nocturne'), ('mina', r'\bMina\b'), ('ezrath', r'Ezrath|Forgotten Ninth|Hooded Traveler|ninth god'),
    ('whiskers', r'Whiskers'), ('nyx', r'\bNyx\b'), ('valdrisia_is_moon', r'Valdrisia[^.]{0,80}(moon|sky)|(moon|sky)[^.]{0,80}Valdrisia'),
    ('system_harvest', r'harvest(s|ed|ing)? (the )?(souls?|growth)|soul harvest|re-?stitch|fraying Weave|no growth ceiling'),
    ('ilvaris_truth', r'Ilvaris[^.]{0,80}(harvest|betray|erase)'), ('loom', r'Unclosed Knot|Floor 120|floor 120'),
    ('fourth_wall', r'Thirteenth Star|Unwoven Sky'), ('gamer', r'video game|\bgamer\b|isekai'),
    ('ranks_origin', r'Kaede|Aoyama'),
    ('other_studio', r'Zelda|Hyrule|Skyrim|Tamriel|Witcher|Dark Souls|Elden Ring|Genshin|Warcraft|Azeroth|Final Fantasy|Pok[eé]mon|Dungeons (&|and) Dragons|Tolkien|Middle-earth|Hobbit|Forgotten Realms|Dragon Quest|Mass Effect|Harry Potter|Hogwarts|Narnia|Sword Art|Naruto|One Piece|Fallout|Minecraft|Stardew'),
    ('real_world', r'\b(Jesus|Christ|Allah|Buddha|Bible|Quran|Japan|Japanese|Chinese|Korean|Europe|American|England|English|French|German|Viking|Samurai|Ninja|Christmas|Easter|Halloween|Monday|Tuesday|Wednesday|Friday|Saturday|Sunday)\b'),
    ('teen', r'\b(naked|nude|breast|sexy|seduc|orgasm|rape|suicide|slut|whore|fuck|shit|bitch)\w*'),
]
REVIEW = [('vesper_moon', r'\bVesper\b|red moon'), ('system_purpose', r"System.s purpose"), ('year1024', r'\b1024\b')]
hold_res = [(n, re.compile(p)) for n, p in HOLD]
rev_res = [(n, re.compile(p)) for n, p in REVIEW]

def scan(text):
    h = []
    for n, rx in hold_res:
        for m in rx.finditer(text):
            h.append({'rule': n, 'match': m.group(0), 'ctx': text[max(0, m.start() - 40):m.end() + 40].replace('\n', ' ')})
    r = []
    for n, rx in rev_res:
        for m in rx.finditer(text):
            r.append({'rule': n, 'match': m.group(0), 'ctx': text[max(0, m.start() - 40):m.end() + 40].replace('\n', ' ')})
    return h, r

# ---------- repairs (minimal, each named) ----------
SUBS = [
    ('template_the_a', re.compile(r'\bThe a (?=[a-z])'), 'The '),
    ('template_cores_moves', re.compile(r'\bCores moves\b'), 'Cores move'),
    ('template_numbered', re.compile(r'records no numbered\.'), 'records no numbered count.'),
    ('weekday_tuesday', re.compile(r'\bnot a Tuesday\b'), 'not a Maelsday'),
    ('lantern_night_heading', re.compile(r'(?m)^## Lantern Night$'), '## Lamp Vigil'),
    ('lantern_night_is', re.compile(r'Lantern Night is'), 'The Lamp Vigil is'),
    ('lantern_night_other', re.compile(r'Lantern Night'), 'the Lamp Vigil'),
    ('kaede_founded', re.compile(r'Kaede Aoyama founded the Guild in the year 12 under that charter\. '), ''),
    ('kaede_nickname', re.compile(r", and 'a Kaede' for someone whose growth frightens the table\. "), ', and \'a brightlamp\' for someone whose growth frightens the table. '),
    ('ranks_origin_line', re.compile(r'The Guild.s letters, F and upward, are a Veilborn habit that the world picked up and made into a door\. '), 'The Guild’s letters, F and upward, are a door the world picked up. '),
    ('system_purpose_line', re.compile(r"It does not explain the sky, the System.s purpose, or anybody else.s secret\."), 'It does not explain the sky or anybody else’s secret.'),
]

def repair(text, meta):
    fixes = []
    for name, rx, rep in SUBS:
        t2, n = rx.subn(rep, text)
        if n:
            fixes.append(f'{name} x{n}')
            text = t2
    return text, fixes

def field_guide_prune(text, region):
    """Drop species chapters whose habitats do not include the guide's region."""
    if region is None:
        return text, [], 0
    parts = re.split(r'(?m)^(?=## )', text)
    out, dropped, kept = [], [], 0
    for p in parts:
        m = re.match(r'## (.+)\n', p)
        if m and m.group(1) in sp_by_name:
            hab = sp_by_name[m.group(1)].get('habitats') or []
            if region['id'] in hab:
                out.append(p); kept += 1
            else:
                dropped.append(m.group(1))
        else:
            out.append(p)
    return ''.join(out), dropped, kept

# ---------- libraries ----------
exec(open(os.path.join(os.path.dirname(__file__), 'libraries_table.py'), encoding='utf-8').read())  # defines LIBRARIES, COVER, KIND_RULES

KIND = {
    'Field guide': ('field_guide', 'partial', ['bestiary', 'taming']), 'Cookery': ('cookery', 'accurate', ['cooking']),
    'Road book': ('road_book', 'accurate', ['travel']), 'Local history': ('local_history', 'partial', ['history']),
    'Household book': ('household_book', 'accurate', ['housing', 'daily_life']), 'Craft notes': ('craft_notes', 'accurate', ['crafting']),
    'Myth telling': ('myth_telling', 'folk belief', ['myth', 'faith']), 'Guild manual': ('guild_manual', 'partial', ['guild']),
    'Chapel notes': ('chapel_notes', 'folk belief', ['faith']), 'Trade notes': ('trade_notes', 'accurate', ['trade']),
    'Letter book': ('letter_book', 'partial', ['daily_life']), 'Law notes': ('law_notes', 'partial', ['law']),
    'Academy lecture': ('academy_lecture', 'partial', ['magic']), 'Ballad sheet': ('ballad_sheet', 'folk belief', ['music']),
    'Veilborn memoir': ('veilborn_memoir', 'partial', ['otherworlders']), 'Stories for reading aloud': ('story_aloud', 'folk belief', ['children']),
    'A short play': ('play', 'folk belief', ['theatre']), 'Valdrisian fragment': ('valdrisian_fragment', 'partial', ['history', 'valdrisia']),
    'Festival notes': ('festival_notes', 'folk belief', ['festival']), 'Romance serial': ('romance_serial', 'folk belief', ['fiction']),
}

def slug(s):
    return re.sub(r'[^a-z0-9]+', '_', s.lower()).strip('_')

def rank_below(r):
    i = RANKS.index(r)
    return RANKS[max(0, i - 1)]

report, books = {}, []
sentence_counts = collections.Counter()
texts = {}
for c in cat:
    t = c['text'] if c.get('text') else open(os.path.join(books_dir, c['file']), encoding='utf-8').read()
    texts[c['file']] = t
    body = t.split('\n', 8)[-1]
    for s in set(x.strip() for x in re.split(r'(?<=[.!?])\s+|\n+', body) if len(x.strip()) > 30):
        sentence_counts[s] += 1

for i, c in enumerate(cat, 1):
    bid = f'bk_{i:03d}'
    text = texts[c['file']]
    reg = reg_by_name.get(c['region'])
    kind, reliab, tags = KIND[c['genre']]
    pre_hold, pre_rev = scan(text)
    text, fixes = repair(text, c)
    dropped = []
    kept_species = []
    if kind == 'field_guide':
        text, dropped, nkept = field_guide_prune(text, reg)
        if dropped:
            fixes.append('off-habitat chapters removed: ' + ', '.join(dropped))
        kept_species = [m for m in re.findall(r'(?m)^## (.+)$', text) if m in sp_by_name]
    hold_hits, rev_hits = scan(text)
    status, why = 'clear', ''
    if hold_hits:
        status, why = 'hold', 'unresolved Canon section 3 / policy hit: ' + ', '.join(sorted({h['rule'] for h in hold_hits}))
    elif kind == 'field_guide' and len(kept_species) < 2:
        status, why = 'hold', f'field guide left with {len(kept_species)} habitat-correct species after repair; needs a rewrite'
    elif fixes:
        status = 'fix'
    ss = [x.strip() for x in re.split(r'(?<=[.!?])\s+|\n+', text.split('\n', 8)[-1]) if len(x.strip()) > 30]
    tshare = sum(1 for s in ss if sentence_counts[s] >= 3) / max(1, len(ss))
    quality = 'strong' if tshare < 0.7 else 'average' if tshare < 0.9 else 'templated'
    words = len(re.findall(r'\w+', text))
    report[bid] = {'file': c['file'], 'title': c['title'], 'kind': kind, 'subjectRegion': c['region'], 'scanStatus': status,
                   'holdReason': why, 'repairs': fixes, 'reviewNotes': [f"{h['rule']}: {h['ctx']}" for h in rev_hits][:6],
                   'originalHits': [f"{h['rule']}: {h['match']}" for h in pre_hold][:6], 'templatedShare': round(tshare, 2), 'quality': quality}
    # shelving
    lib = None
    if status != 'hold':
        lib = choose_library(kind, reg, c)
    rank_gate = None
    if kind in ('field_guide', 'guild_manual', 'road_book') and reg and RANKS.index(reg['rankMin']) >= RANKS.index('C'):
        rank_gate = rank_below(reg['rankMin']) if RANKS.index(reg['rankMin']) <= RANKS.index('B') else 'B'
    m = re.search(r'\*\*In-world date:\*\* (.+)', text)
    blurb = BLURBS[kind].format(region=c['region'], title=c['title'])
    rewards = []
    if kind == 'field_guide':
        for n in kept_species[:3]:
            rewards.append({'kind': 'bestiary', 'id': sp_by_name[n]['id']})
    if kind == 'valdrisian_fragment':
        rewards.append({'kind': 'archive', 'id': 'civ_valdrisia'})
    entry = {'id': bid, 'title': c['title'], 'author': c['author'], 'kind': kind, 'library': lib, 'region': LIB_REGION.get(lib) if lib else None,
             'subjectRegion': reg['id'] if reg else None, 'shelf': c['genre'], 'language': 'Common' if kind != 'valdrisian_fragment' else 'Common (copied from Old Weave-tongue)',
             'blurb': blurb, 'readingMinutes': max(1, round(words / 200)), 'words': words, 'tags': sorted(set(tags + [reg['id']] if reg else tags)),
             'reliability': reliab, 'status': 'hold' if status == 'hold' else ('clear' if status == 'clear' else 'draft'),
             'quality': quality, 'inWorldDate': m.group(1).strip() if m else '', 'source': ('Tools/library/gap_books.py (generated gap book)' if c.get('generated') else 'books/' + c['file']),
             'text': f'02_Lore/library/{lib}/{bid}.md' if lib else None}
    if rank_gate:
        entry['rankGate'] = rank_gate
    if rewards:
        entry['rewards'] = rewards
    books.append(entry)
    if lib and not DRY:
        d = os.path.join(REPO, '02_Lore', 'library', lib)
        os.makedirs(d, exist_ok=True)
        open(os.path.join(d, bid + '.md'), 'w', encoding='utf-8', newline='\n').write(text)

# summary
cnt = collections.Counter(v['scanStatus'] for v in report.values())
print('status', dict(cnt))
print('by library', collections.Counter(b['library'] for b in books))
print('quality', collections.Counter(b['quality'] for b in books))
if not DRY:
    os.makedirs(os.path.join(REPO, 'Data', 'Library'), exist_ok=True)
    json.dump({'version': 1, 'note': LIB_NOTE, 'books': books}, open(os.path.join(REPO, 'Data/Library/books.json'), 'w', encoding='utf-8', newline='\n'), indent=1, ensure_ascii=False)
    json.dump({'version': 1, 'note': LIB_NOTE, 'libraries': LIBRARIES}, open(os.path.join(REPO, 'Data/Library/libraries.json'), 'w', encoding='utf-8', newline='\n'), indent=1, ensure_ascii=False)
    json.dump({'generated': str(datetime.date.today()), 'counts': dict(cnt), 'books': report}, open(os.path.join(REPO, '13_Production/library_scan_report.json'), 'w', encoding='utf-8', newline='\n'), indent=1, ensure_ascii=False)

# ---------- generated index ----------
if not DRY:
    lines = ['# Libraries of Aethwyrd (generated)', '',
             'Generated by `Tools/library/shelve.py` from `Data/Library/`. **Do not edit by hand.** Every book here is a **draft, not Canon**, until the user approves it; a library marked *proposed* is not Canon either. Rules and schema: `12_Systems/libraries_and_books.md`.', '',
             f'{sum(1 for b in books if b["library"])} books shelved in {len(LIBRARIES)} libraries; {sum(1 for b in books if b["status"] == "hold")} held back (see `13_Production/library_scan_report.json`).', '']
    for l in LIBRARIES:
        mine = [b for b in books if b['library'] == l['id']]
        lines += [f'## {l["name"]} (`{l["id"]}`, {l["type"]}, {l["status"]})', '', f'{l["blurb"]} Region: `{l["region"]}`, {l["settlement"]}. Source: {l["source"]}.', '']
        for b in mine:
            lines.append(f'- [{b["title"]}]({l["id"]}/{b["id"]}.md) ({b["shelf"]}, {b["reliability"]}, {b["status"]}): {b["blurb"]}')
        lines.append('')
    held = [b for b in books if b['status'] == 'hold']
    lines += ['## Held back', ''] + [f'- `{b["id"]}` {b["title"]} ({b["shelf"]}): {report[b["id"]]["holdReason"]}' for b in held] + ['']
    open(os.path.join(REPO, '02_Lore', 'library', 'README.md'), 'w', encoding='utf-8', newline='\n').write('\n'.join(lines))
