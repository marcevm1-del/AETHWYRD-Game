# Templates

Copy the block, fill every field. "None" and "Unknown" are valid answers; a blank is not.

## 1. Backlog task (`FEATURE_BACKLOG.md`)

```text
TASK ID:            T-###
TASK TITLE:
PARENT FEATURE:     UPG-### / IDEA-### / milestone M#
SYSTEM:             SYS-xxx-## (from SYSTEM_INVENTORY.md)
DESCRIPTION:
PLAYER BENEFIT:
IMPLEMENTATION DETAILS:
OWNER:              agent name (one)
REVIEWER:           agent name (not the owner)
MODEL TIER:         haiku / sonnet / opus
PRIORITY:           P0 blocker · P1 needed for the next milestone · P2 important · P3 useful · P4 optional
STATUS:             READY / IN PROGRESS / BLOCKED / IN REVIEW / DONE / DROPPED
DEPENDENCIES:       task IDs, owner decisions
EFFORT:             S (under half a window) / M (about one window) / L (more)
COMPLEXITY:         S / M / L
RISKS:
AFFECTED FILES:
ACCEPTANCE CRITERIA:
TESTING REQUIREMENTS:
DOCUMENTATION REQUIREMENTS:
NEEDS UNITY:        yes / no   (yes = can only be finished on the owner's PC)
```

A "window" is one 5-hour usage window as defined in `13_Production/risk_register_and_usage_budget.md` §3. Effort is a reviewer's estimate, never a date.

## 2. Upgrade entry (`UPGRADE.md`)

```text
UPGRADE ID:         UPG-###
Title:
Existing System:    SYS-xxx-##
Current Implementation Status:
Current Problem:
Evidence:           file paths, test names, run logs
Proposed Improvement:
Player Benefit:
Technical Benefit:
Gameplay Benefit:
Dependencies:
Affected Systems:
Affected Files:
Priority:           P0 … P4
Complexity:         S / M / L
Risk:
Acceptance Criteria:
Testing Requirements:
Status:             PROPOSED / INVESTIGATION / APPROVED / READY / IN PROGRESS / BLOCKED / IMPLEMENTED / VERIFIED / DEFERRED / REJECTED
Related Ideas:
Related Tasks:
Date Added:
Decision History:   date, who, what, why
```

## 3. Idea entry (`IDEAS.md`)

```text
IDEA ID:            IDEA-###
Title:
Category:
Description:
Player Experience:
Gameplay Purpose:
Why It Belongs in AETHWYRD:
Player Benefit:
Affected Systems:
Potential Dependencies:
Suggested Implementation:
Technical Considerations:
Content Requirements:
Complexity:         S / M / L
Priority:           P0 … P4
Risks:
Design Questions:
Related Ideas:
Related Upgrades:
Related Files:
Status:             NEW / EXPLORING / NEEDS RESEARCH / READY FOR REVIEW / APPROVED / ADDED TO BACKLOG / IN DEVELOPMENT / IMPLEMENTED / DEFERRED / REJECTED
Date Added:
Decision History:
```

## 4. Agent brief (what the orchestrator sends)

```text
You are the <agent>. <One sentence: the objective.>
Read: CLAUDE.md, then <the 3 to 6 files that matter>.
Task: <numbered steps>.
Files you may write: <exact paths>. Nothing else.
Not in scope: <what to leave alone, and who owns it>.
Checks: <commands to run and what must hold>.
Done when: <acceptance criteria>.
Report in the format of Planning/TASK_TEMPLATES.md §5.
```

Rules for briefs: one owner per file per wave; name the model tier when it differs from the agent's default; say "UNITY OK" explicitly or the agent must not start Unity; at most two working agents at once, three when one only reads (`13_Production/risk_register_and_usage_budget.md` §1).

## 5. Agent report (what every agent sends back)

```text
AGENT:
MODEL TIER:
ASSIGNED TASK:
FILES INSPECTED:
FILES MODIFIED:
CURRENT FINDINGS:

WHAT EXISTS:
WHAT IS MISSING:
PROBLEMS IDENTIFIED:
RECOMMENDATIONS:

DEPENDENCIES:
RISKS:
COMPLEXITY:
PRIORITY:

DECISIONS REQUIRED:
TESTING REQUIRED:
ACCEPTANCE CRITERIA:

UPGRADE ENTRIES:
IDEA ENTRIES:
BACKLOG TASKS:

CONFIDENCE:
UNRESOLVED QUESTIONS:
FINAL STATUS:       DELIVERED (what) / RECOMMENDATION ONLY / BLOCKED (why)
```

Every claim carries one label: **VERIFIED FACT** (read in the file or ran it) · **DOCUMENTED FACT** (a doc says so, unchecked) · **REASONED CONCLUSION** · **DESIGN RECOMMENDATION** · **UNVERIFIED ASSUMPTION** · **OPEN QUESTION**.

## 6. Canon discrepancy (`CANON_DISCREPANCIES.md`)

```text
Discrepancy ID:     CD-###
Conflicting documents:
Relevant sections:
Description:
Why it matters:
Recommended resolution:
Decision owner:     owner / orchestrator / canon-keeper
Status:             OPEN / RESOLVED (date, how) / ACCEPTED AS IS (why)
```

## 7. Risk (`TECHNICAL_RISK_REGISTER.md`)

```text
Risk ID:            R##  (R1 to R14 keep their numbers from 13_Production/risk_register_and_usage_budget.md)
Kind:               CONFIRMED DEFECT / OBSERVED (has happened) / THEORETICAL
Description:
Probability:        H / M / L
Impact:             H / M / L
Severity:           probability x impact
Affected systems:
Detection method:
Mitigation:
Contingency:
Owner:
Status:             OPEN / MITIGATED / CLOSED
```
