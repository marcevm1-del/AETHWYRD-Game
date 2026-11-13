# -*- coding: utf-8 -*-
"""Gap books: habitat-correct replacements for the field guides that were held (their species did not live in the guide's region).
Uses the originals' own generator functions (generate_library.field_guide) with species picked FROM the region's habitat list, so the voice
is the same. At most MAX_GAP books. They are drafts, shelved after the same scan and repair as every other book.
Usage (called by shelve.py): make_gap(books_dir, species, regions) -> list of catalog-like dicts with a 'text' key.
"""
import os, sys, random

MAX_GAP = 20
BANNED = ("Sovereign", "Primordial", "Overlord", "Tyrant", "Calamity", "Azrael", "Nyx", "Nocturne", "Vesper", "Umbrael")


def make_gap(books_dir, species, regions):
    sys.path.insert(0, books_dir)
    import generate_library as g
    by_region = {}
    for s in species:
        if s.get('isUnique') or s.get('tier') != 'core' or s.get('variantKind'):
            continue
        if any(w in s['name'] for w in BANNED):
            continue
        for rid in s.get('habitats') or []:
            by_region.setdefault(rid, []).append(s)
    skip = set(getattr(g, 'SKIP_REGIONS', set())) | {'reg_vesper'}
    cands = [r for r in regions if r['layer'] == 'surface' and r['id'] not in skip and len(by_region.get(r['id'], [])) >= 4]
    cands.sort(key=lambda r: (r['ring'], r['id']))
    out = []
    for r in cands[:MAX_GAP]:
        rng = random.Random('aethwyrd-gap-field-' + r['id'])
        window = rng.sample(by_region[r['id']], 5)
        place = g.places_of(r)[0]
        book = {'title': f'Neighbors Near {place}', 'author': g.author_for(rng, r['name']), 'genre_label': 'Field guide',
                'region_name': r['name'], 'year': f'{990 + rng.randrange(30)} SC'}
        body = g.field_guide(rng, r, window)
        out.append({'file': f'gap/{r["id"]}-field-guide.md', 'title': book['title'], 'author': book['author'], 'genre': 'Field guide',
                    'region': r['name'], 'status': 'draft', 'generated': True,
                    'text': g.header(book) + body + g.close_note()})
    return out
