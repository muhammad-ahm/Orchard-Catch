# 🍎 OrchardCatch

A 2D arcade dodge-and-catch game built in Unity, set in a cozy orchard.
Catch the good apples, dodge the rotten ones, survive as the pace
ramps up. Built as a portfolio project focused on core Unity systems:
collision, UI, audio mixing, scene management, and difficulty pacing.

## Gameplay

Move your basket left and right to catch apples falling from the
trees. Good apples score points; rotten apples cost you a life. Miss
one on purpose — no penalty — but touch a bad one and you'll feel it.
The longer you survive, the faster (and more dangerous) it gets.

See [GAMEPLAY.md](GAMEPLAY.md) for full mechanics, controls, and the
difficulty curve.

## Features

- Core catch/dodge gameplay with a 3-life system
- Tiered difficulty curve — spawn rate and fall speed both scale with score
- Full main menu: Start, Options (music/SFX volume + mute), How to
  Play, and Credits screens
- Persistent audio system with separate Music/SFX mixer channels
- Game Over screen with Restart and Main Menu options
- Published to itch.io, Y8, and Google Play

## Play It

- **itch.io**: https://madebyahmed.itch.io/orchard-catch
- **Y8**: _link here once published_

## Controls

| Action | Key |
|---|---|
| Move Left | Left Arrow / A |
| Move Right | Right Arrow / D |

## Built With

- **Engine**: Unity 6.5
- **Language**: C#
- **Art**: Google Gemini (AI-generated sprites and background)
- **Music**: RaoMusic (AI-generated)
- **Sound Effects**: Mixkit, freegamedesigntools.com SFX Board

Full asset credits and licenses are listed in-game under the Credits
menu, and summarized in [`credits_text.txt`](credits_text.txt).

## Project Background

OrchardCatch is the first game in a personal game-development learning
series — building small, focused Unity projects to learn core
engine/systems concepts one at a time (collision, UI, audio, scene
flow) before moving on to larger mechanics like physics-based
platforming and AI in later projects.

## License

Original code is licensed under the MIT License — see
[LICENSE.txt](LICENSE.txt). Third-party art, music, and sound assets
are licensed separately by their original creators/sources; see
[`credits_text.txt`](credits_text.txt) for details on each.
