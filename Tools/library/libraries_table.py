# -*- coding: utf-8 -*-
# Libraries of Aethwyrd and the shelving rules. Executed by shelve.py.
# status "canon" = the place or institution already exists in Canon, 02_Lore or Data/World (source says where).
# status "proposed" = a reading room invented for the shelf; NOT Canon until the user approves (Canon section 6, row L1).
LIB_NOTE = ("Libraries, archives, temples, schools and guild halls of Aethwyrd and the draft books on their shelves (12_Systems/libraries_and_books.md). "
            "Books are drafts, not Canon, until the user approves them. A library with status 'proposed' is not Canon either.")

def L(id, name, type, region, settlement, status, source, blurb, covers, rankGate=None):
    d = {'id': id, 'name': name, 'type': type, 'region': region, 'settlement': settlement, 'status': status, 'source': source, 'blurb': blurb, 'covers': covers}
    if rankGate:
        d['rankGate'] = rankGate
    return d

LIBRARIES = [
    L('lib_brindlewick_guild_shelf', "Brindlewick Guild Branch Shelf", 'guild_hall', 'reg_whisperwood', 'Brindlewick', 'canon',
      "Data/World/gazetteer.json (Whisperwood: the guild branch); 10_World/brindlewick.md (Magistra Eolande Fairweather, mage trainer and librarian)",
      "The guild branch where most adventurers wake up keeps a small shelf for newcomers, tended by the village's mage trainer.", ['reg_whisperwood']),
    L('lib_aldmere_royal_archive', "Aldmere Royal and Noble Archives", 'archive', 'reg_aldmere', 'Aldmere City', 'canon',
      "10_World/world.md (Aldmere City, five districts); 02_Lore/history.md (royal and noble archives)",
      "Copies of reeve's papers, valley records and travellers' notes kept in the crown city, with the road to the Labyrinth entrance below it.", ['reg_aldmere', 'reg_labyrinth_upper']),
    L('lib_mages_academy', "The Mages' Academy Library", 'school', 'reg_aldmere', 'Aldmere City (Academy district)', 'canon',
      "02_Lore/history.md (Mages' Academy, est. 512); 10_World/world.md (Aldmere City Academy district)",
      "Lectures, copied demonstrations and the careful fragments of the old empire, kept where magic is taught.", []),
    L('lib_aldmere_guild_hall', "Aldmere Guild Hall Reading Room", 'guild_hall', 'reg_aldmere', 'Aldmere City', 'proposed',
      "The Guild exists in Canon (Section 2 ranks); a reading room in its Aldmere hall is proposed",
      "Branch manuals, street-law notes and the guild's copies of local rules.", []),
    L('lib_aldmere_cathedral_shelf', "Summoning Cathedral Shelf", 'temple', 'reg_aldmere', 'Aldmere City (Temple district)', 'canon',
      "10_World/world.md (Aldmere City: Summoning Cathedral, Temple district)",
      "Myth tellings and chapel notes left by pilgrims and keepers, shelved by the shrine floor.", []),
    L('lib_peat_library', "The Peat Library", 'library', 'reg_greymoor', 'Greymoor', 'canon',
      "Data/World/gazetteer.json (Greymoor landmark: The Peat Library, a cave where the bog preserved a monastery's books)",
      "A bog-cave where a drowned monastery's books are dried and read with care.", ['reg_greymoor']),
    L('lib_lothaniel_root_archive', "Lothaniel Root Archive", 'archive', 'reg_sylvaran', 'Canopy City Lothaniel', 'proposed',
      "Proposed reading room in Sylvaran's canopy city (settlement in gazetteer)",
      "Living-timber shelves kept by the canopy city, covering the mossy and summer lands around it.", ['reg_sylvaran', 'reg_mossdeep', 'reg_everdusk']),
    L('lib_lirian_licence_archive', "Lirian Licence Archive", 'archive', 'reg_lirian', 'Lirian canal cities', 'proposed',
      "Proposed; Lirian's lock-licence quarrels (gazetteer) suggest a records house",
      "The canal cities keep every lock licence and, beside them, the grain and market notes of the trunk river.", ['reg_lirian', 'reg_velmark', 'reg_moraveil']),
    L('lib_vharlen_legion_records', "Vharlen Legion Records House", 'archive', 'reg_vharlen', 'Vharlen frontier legions', 'proposed',
      "Proposed; Vharlen's frontier legions (gazetteer) would keep muster and road records",
      "Muster books, route notes and soldiers' letters from the northern frontier.", ['reg_vharlen', 'reg_fanghold', 'reg_strife_marches', 'reg_calamity_steppe']),
    L('lib_bastion_watch_library', "Bastion Watch Library", 'library', 'reg_bastion', 'Bastion outer ring', 'proposed',
      "Proposed; Bastion's outer ring (gazetteer) is a defensive town",
      "A watch-house shelf of field notes about the dark country the Bastion stands against.", ['reg_bastion', 'reg_nox_dominion']),
    L('lib_karak_dun_records', "Karak Dûn Hall of Records", 'archive', 'reg_iron_hold', 'Karak Dûn', 'proposed',
      "Proposed; Karak Dûn is canon (gazetteer); oath and craft records are implied by the Oath-Anvil tradition",
      "Craft marks, oath records and the working notes of the mines and the clockwork halls.", ['reg_iron_hold', 'reg_gearholm', 'reg_cinderhole']),
    L('lib_shen_lu_sect_library', "Shen-Lu Foothill Sect Library", 'school', 'reg_shen_lu', 'Sect foothill towns', 'proposed',
      "Proposed; Shen-Lu sect foothill towns (gazetteer)",
      "A sect library of rules, practice notes and gate-town letters, open to guests who ask politely.", ['reg_shen_lu', 'reg_haneul']),
    L('lib_hoshizora_shrine_library', "Hoshizora Shrine Library", 'temple', 'reg_hoshizora', 'Hoshizora City', 'proposed',
      "Proposed; household shrines of Hoshizora (gazetteer)",
      "River-mouth shrine shelves of festival notes, rain tables and household books.", ['reg_hoshizora']),
    L('lib_fox_shrine_library', "Fox Shrine Isle Library", 'temple', 'reg_kitsune_isles', 'Fox Shrine Isle', 'canon',
      "Data/World/gazetteer.json (Kitsune Isles: Fox Shrine, The Ninefold Shrine)",
      "Stair-top shrine shelves where stories arrive by boat and leave changed.", ['reg_kitsune_isles', 'reg_true_name_isles']),
    L('lib_dragon_bone_monastery_library', "Dragon-Bone Monastery Library", 'temple', 'reg_dragon_spine', 'Dragon-bone monasteries', 'canon',
      "Data/World/gazetteer.json (Dragon Spine: the Bone Road links every monastery)",
      "Monastery shelves along the Bone Road, with copies sent up to the eyries.", ['reg_dragon_spine', 'reg_heavenreach', 'reg_sky_archipelago']),
    L('lib_skjaldheim_skald_hall', "Skjaldheim Skald Hall", 'library', 'reg_frostveil', 'Skjaldheim', 'proposed',
      "Proposed; Skjaldheim is canon (gazetteer); a skald hall is implied by longhouse culture",
      "Sagas, weather notes and ice-country road books kept in the fjord-head hall.", ['reg_frostveil', 'reg_whitewater_reach', 'reg_quaking_lands']),
    L('lib_qadira_water_archive', "Qadira Water Archive", 'archive', 'reg_sunscar', 'Oasis of Qadira', 'proposed',
      "Proposed in 02_Lore/history.md (Sunscar: build a water archive, draft)",
      "Water-keepers' recitations and well records of the desert oasis and the dune country around it.", ['reg_sunscar', 'reg_dunewhale_drift', 'reg_apu_highlands']),
    L('lib_zaruma_earth_towers', "Zaruma Earth Towers", 'library', 'reg_zaruma', 'Zaruma gold-road towns', 'canon',
      "02_Lore/history.md (Zaruma: a kingdom of scholars; library-mosque-style towers of earth)",
      "Griots and scribes keep the kingdom's histories in earth towers along the gold road.", ['reg_zaruma', 'reg_lustrine_shores']),
    L('lib_port_goldmere_reading_room', "Port Goldmere Harbor Reading Room", 'library', 'reg_goldmere_coast', 'Port Goldmere', 'proposed',
      "Proposed; Port Goldmere is canon (gazetteer)",
      "Tide tables, trade notes and sailors' songs kept by the harbor masters.", ['reg_goldmere_coast']),
    L('lib_xochitl_cord_archive', "Xochitl Cord Archive", 'archive', 'reg_xochitl_mire', 'Xochitl river-cities', 'proposed',
      "Proposed in 02_Lore/history.md (treat the cords as a land and labor archive, draft)",
      "Knotted records and river-city ledgers, read aloud by those who keep the cords.", ['reg_xochitl_mire']),
    L('lib_lumbaya_sky_temple', "Lumbaya Sky Temple Shelf", 'temple', 'reg_lumbaya', 'Lumbaya temple villages', 'canon',
      "Data/World/gazetteer.json (Lumbaya: The Sky Temple)",
      "Temple village shelves of chapel notes, pilgrim letters and valley histories.", ['reg_lumbaya', 'reg_ashira_vale']),
    L('lib_zarvan_garden_library', "Zarvan Garden Library", 'library', 'reg_zarvan', 'Zarvan garden cities', 'proposed',
      "Proposed; Zarvan's garden cities are canon (gazetteer)",
      "Terrace-garden reading rooms of aqueduct, planting and cliff-town notes.", ['reg_zarvan', 'reg_stormreach']),
    L('lib_aurumdeep_camp_shelf', "Aurumdeep Explorers' Camp Shelf", 'library', 'reg_aurumdeep', "Aurumdeep explorers' camp", 'canon',
      "Data/World/gazetteer.json (Aurumdeep explorers' camp; Labyrinth back-door from floor 30)",
      "Explorers leave their notes here for the next party: deep-country field notes and letters.", ['reg_aurumdeep', 'reg_root_of_the_world', 'reg_umbravel', 'reg_hollow_sea']),
    L('lib_labyrinth_upside_down_library', "The Upside-Down Library (Floor 72)", 'library', 'reg_labyrinth_deep', 'Great Labyrinth, floor 72', 'canon',
      "Data/World/gazetteer.json (a scholar wants a book from the upside-down library on floor seventy-two, read in the right direction)",
      "A library hanging the wrong way up, whose books must be read in the right direction.", ['reg_labyrinth_deep', 'reg_labyrinth_abyss', 'reg_the_maw'], 'B'),
]

LIB_REGION = {l['id']: l['region'] for l in LIBRARIES}
COVER = {}
for l in LIBRARIES:
    for r in l['covers']:
        COVER[r] = l['id']

def choose_library(kind, reg, c):
    rid = reg['id'] if reg else None
    if kind == 'valdrisian_fragment':
        return 'lib_labyrinth_upside_down_library' if rid in ('reg_labyrinth_deep', 'reg_labyrinth_abyss', 'reg_the_maw', 'reg_root_of_the_world', 'reg_aurumdeep') else 'lib_mages_academy'
    if kind == 'academy_lecture':
        return 'lib_mages_academy'
    if kind in ('guild_manual', 'law_notes'):
        return 'lib_brindlewick_guild_shelf' if rid == 'reg_whisperwood' else 'lib_aldmere_guild_hall'
    if kind in ('chapel_notes', 'myth_telling') and rid in ('reg_aldmere', 'reg_whisperwood', 'reg_labyrinth_upper'):
        return 'lib_aldmere_cathedral_shelf'
    if kind == 'romance_serial' or rid is None:
        return 'lib_aldmere_royal_archive'
    return COVER.get(rid, 'lib_aldmere_royal_archive')

BLURBS = {
    'field_guide': "A walker's guide to the creatures near {region}: what folk file them under, how to approach them, what to leave alone.",
    'cookery': "A household cookery from {region} with plain recipes, kitchen arguments and the reasons behind them.",
    'road_book': "A road notebook that walks the legs toward {region}, with weather, crossings and the habits of the road.",
    'local_history': "Two retellings of the history of {region}, set side by side, with the question of who benefits left open.",
    'household_book': "A house book from {region}: lamps, guests, mending and the small rules of a shared home.",
    'craft_notes': "Bench notes from {region} on materials, tools and mistakes worth making only once.",
    'myth_telling': "The gods as told in {region}, in the voices of those who tell them and those who doubt.",
    'guild_manual': "A guild branch manual for {region}: forms, slang, rank etiquette and what the board will not say.",
    'chapel_notes': "What a shrine floor in {region} sees: keepers, mourners, festival crowds and quiet hours.",
    'trade_notes': "Trade notes on goods that pass through {region}, with prices as rules of thumb and not promises.",
    'letter_book': "Letters left in {region}: ordinary news, kept because someone could not throw them away.",
    'law_notes': "A street-law note for {region}: what a neighbour, a guard and a clerk each expect of you.",
    'academy_lecture': "A copied academy lecture about magic as practised near {region}, with its pauses and its student's marginalia.",
    'ballad_sheet': "Songs heard in {region}, set down with the verses people disagree about.",
    'veilborn_memoir': "A Veilborn cook's memoir from {region}: an old-world kitchen made to work in a new one.",
    'story_aloud': "Stories to read aloud in {region}, with the pauses marked for the reader.",
    'play': "A short play for a latch and two voices, staged in {region}.",
    'valdrisian_fragment': "Potsherd readings of the old empire as copied in {region}, with the copyists' doubts left in.",
    'festival_notes': "The year's festivals in {region}, by household, shrine and branch hall.",
    'romance_serial': "One volume of the Aldmere serial The Knight and the Wyvern Princess, printed in Aldmere and passed hand to hand.",
}
