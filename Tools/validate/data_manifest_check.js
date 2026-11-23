// Data manifest check: the player build must ship every Data/ file the Unity runtime reads.
// Statically scans the runtime .cs files for the Data paths they read, then fails if a path does not exist in Data/ or is
// not covered by BuildPlayer's copy rule (it copies Data/**/*.json except ExcludedDataDirs / ExcludedDataFiles).
// Run: node Tools/validate/data_manifest_check.js   (also part of `npm run build`)
const fs = require('fs');
const path = require('path');

const ROOT = path.resolve(__dirname, '..', '..');
const DATA = path.join(ROOT, 'Data');
const BUILD = path.join(ROOT, 'Game/Assets/_Game/Editor/BuildPlayer.cs');
const SCAN_ROOTS = ['Game/Assets/_Game/Runtime', 'Code/Unity/Runtime'].map(p => path.join(ROOT, p));

function walk(dir, out) {
  if (!fs.existsSync(dir)) return out;
  for (const e of fs.readdirSync(dir, { withFileTypes: true })) {
    const p = path.join(dir, e.name);
    if (e.isDirectory()) walk(p, out); else if (e.name.endsWith('.cs')) out.push(p);
  }
  return out;
}

function arrayLiterals(src, name) {
  const m = src.match(new RegExp(name + '\\s*=\\s*\\{([\\s\\S]*?)\\};'));
  if (!m) return null;
  const body = m[1].replace(/\/\/.*$/gm, '');
  return [...body.matchAll(/"([^"]+)"/g)].map(x => x[1]);
}

const errors = [];
const build = fs.readFileSync(BUILD, 'utf8');
const exDirs = arrayLiterals(build, 'ExcludedDataDirs');
const exFiles = arrayLiterals(build, 'ExcludedDataFiles');
if (!exDirs || !exFiles) errors.push('BuildPlayer.cs: ExcludedDataDirs / ExcludedDataFiles arrays not found (the copy rule changed shape; update this check)');
if (!/GetFiles\(\s*repoData\s*,\s*"\*\.json"\s*,\s*SearchOption\.AllDirectories\s*\)/.test(build)) errors.push('BuildPlayer.cs no longer copies Data/**/*.json (expected GetFiles(repoData, "*.json", SearchOption.AllDirectories))');

const covered = rel => !((exDirs || []).some(d => rel.startsWith(d + '/')) || (exFiles || []).includes(rel));

// path -> first file that reads it
const reads = new Map();
function add(rel, file) { if (!reads.has(rel)) reads.set(rel, path.relative(ROOT, file).replace(/\\/g, '/')); }
for (const file of SCAN_ROOTS.flatMap(r => walk(r, []))) {
  const src = fs.readFileSync(file, 'utf8').replace(/\/\/.*$/gm, '');
  // "Folder/name.json" literals (AscendData Read / ReadOpt / Once)
  for (const m of src.matchAll(/"((?:[A-Za-z_]+\/)+[\w.\-]+\.json)"/g)) add(m[1], file);
  // Path.Combine(AscendData.DataRoot, "Folder", "name.json")
  for (const m of src.matchAll(/DataRoot\s*,\s*((?:"[^"]*"\s*,?\s*)+)\)/g)) {
    const parts = [...m[1].matchAll(/"([^"]*)"/g)].map(x => x[1]);
    if (parts.length && parts[parts.length - 1].endsWith('.json')) add(parts.join('/'), file);
  }
}
if (reads.size === 0) errors.push('scanner found no Data paths in the runtime (pattern broke?)');

for (const [rel, file] of [...reads].sort()) {
  if (!fs.existsSync(path.join(DATA, rel))) errors.push(`${file} reads Data/${rel}, which does not exist`);
  else if (!covered(rel)) errors.push(`${file} reads Data/${rel}, which BuildPlayer excludes from the player build`);
}

if (errors.length) {
  console.error('data manifest check FAILED:');
  for (const e of errors) console.error('  - ' + e);
  process.exit(1);
}
console.log(`data manifest check OK: ${reads.size} runtime-read Data files, all exist and ship in the player build`);
