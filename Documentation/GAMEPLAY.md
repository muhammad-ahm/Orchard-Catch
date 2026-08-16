# Gameplay — OrchardCatch

## Objective

Catch as many good apples as you can while avoiding the rotten ones.
Survive as long as possible — the game gets progressively harder the
higher your score climbs.

## Controls

| Action | Key(s) |
|---|---|
| Move Left | Left Arrow or A |
| Move Right | Right Arrow or D |

## Core Mechanics

- **Good apple caught**: +10 score
- **Bad (rotten) apple touched**: -1 life
- **Starting lives**: 3
- **Missed apple** (falls off-screen uncaught, good or bad): no
  penalty, it simply despawns
- **Game Over**: triggered when lives reach 0

## Difficulty Curve

Difficulty is tiered, stepping up every 50 score. Each tier changes
three things at once: how often apples spawn, how fast bad apples
fall, and how fast good apples fall (good apples scale up later and
more slowly than bad apples).

| Tier | Score Threshold | Spawn Interval | Bad Apple Speed | Good Apple Speed |
|---|---|---|---|---|
| 0 | 0 | 1.6s | 1x | 1x |
| 1 | 50 | 1.35s | 2x | 1x |
| 2 | 100 | 1.1s | 3x | 1x |
| 3 | 150 | 0.85s | 4x | 2x |
| 4 | 200 | 0.6s | 5x | 2x |
| 5 | 250 | 0.35s | 6x | 2x |
| 6 | 300+ | 0.2s | 7x | 3x |

Tier 6 is the ceiling — difficulty does not continue to escalate
beyond it, regardless of final score.

## Menus

- **Main Menu**: Start, Options, How to Play, Credits
- **Options**: independent Music and SFX volume sliders, plus a Mute
  All toggle. Settings persist between play sessions.
- **How to Play**: in-game controls and objective summary
- **Credits**: full asset attribution and license summary
- **Game Over screen**: Restart (replay immediately) or Main Menu
  (return to the title screen)

## Version History

- **v1** — Core dodge loop: single hazard type, any touch ends the
  game immediately, endless survival scoring.
- **v2** — Split hazards into good/bad apples, added a 3-life system,
  scoring shifted to per-catch instead of per-second survived.
- **v3** — Added full audio system (music + SFX, mixer-based volume
  control), main menu with Options/Instructions/Credits, and
  Restart/Main Menu navigation from the Game Over screen.
- **v4** — Replaced the single difficulty threshold with the full
  7-tier curve above, affecting spawn rate and fall speed for both
  apple types independently.
