// Runs every offline Python tool test: Tools/*/test_*.py (the set is derived from the folder, so a new test is
// covered the moment it exists). Each runs with `python -I` (isolated). Part of `npm run build`.
//
// A missing Python is a FAILURE, not a skip: a gate that cannot run must not look like a gate that passed.
// Set ASCEND_PYTHON to pick an interpreter. Usage: node Tools/validate/run_py_tests.js
const { spawnSync } = require('child_process');
const fs = require('fs');
const path = require('path');

const ROOT = path.join(__dirname, '..', '..');
const TOOLS = path.join(ROOT, 'Tools');

function findPython() {
  const cands = [process.env.ASCEND_PYTHON, 'python3', 'python', 'py'].filter(Boolean);
  for (const c of cands) {
    const r = spawnSync(c, ['-I', '-c', 'import sys; print(sys.version_info[:2] >= (3, 8))'], { encoding: 'utf8' });
    if (r.status === 0 && r.stdout.trim() === 'True') return c;
  }
  return null;
}

const tests = [];
for (const d of fs.readdirSync(TOOLS, { withFileTypes: true })) {
  if (!d.isDirectory()) continue;
  for (const f of fs.readdirSync(path.join(TOOLS, d.name))) {
    if (/^test_.*\.py$/.test(f)) tests.push(path.join('Tools', d.name, f));
  }
}
tests.sort();

if (tests.length === 0) {
  console.error('FAIL: no Tools/*/test_*.py found; the Python test gate would run nothing.');
  process.exit(1);
}
const py = findPython();
if (!py) {
  console.error('FAIL: Python 3 not found, so ' + tests.length + ' Python tool tests could NOT run (set ASCEND_PYTHON).');
  process.exit(1);
}

let failed = 0;
for (const t of tests) {
  const r = spawnSync(py, ['-I', '-B', t], { cwd: ROOT, encoding: 'utf8', timeout: 300000 });
  const last = ((r.stdout || '').trim().split(/\r?\n/).pop() || '').trim();
  if (r.status === 0) {
    console.log('ok   ' + t + (last ? '  (' + last + ')' : ''));
  } else {
    failed++;
    console.log('FAIL ' + t + ' (exit ' + r.status + (r.error ? ', ' + r.error.code : '') + ')');
    console.log(((r.stdout || '') + (r.stderr || '')).trim().split(/\r?\n/).slice(-15).join('\n'));
  }
}
console.log(tests.length - failed + '/' + tests.length + ' Python test files passed (' + py + ')');
process.exit(failed ? 1 : 0);
