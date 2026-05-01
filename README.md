# 🎯 Darts & Drafts

> A recreational VR dart throwing experience set inside an immersive virtual pub.

![Unity](https://img.shields.io/badge/Unity-2022.x-black?logo=unity)
![Platform](https://img.shields.io/badge/Platform-Meta%20Quest%202-blue?logo=meta)
![Language](https://img.shields.io/badge/Language-C%23-purple?logo=csharp)
![Status](https://img.shields.io/badge/Status-Complete-brightgreen)

---

## 📖 Overview

Darts & Drafts brings the classic pub darts experience into virtual reality. Set inside a lively, atmospheric pub, players can freely explore the environment and choose between two distinct game modes that challenge their precision and accuracy. Whether you have five darts or forty-five seconds, the goal is the same: score as many points as possible.

This project was developed by a team of five CS students as part of **CS 458**, with no prior Unity or VR experience going into it.

---

## 🎮 Game Modes

### 🏹 Points Mode
- Five darts are spawned on a floating table at the start
- Score as many points as possible before all darts are thrown
- Each dartboard section carries a specific point value
- Results are displayed after the last dart lands

### ⏱ Time Mode
- A 45-second countdown begins after a 5-second prep timer
- Infinite dart respawns — darts are destroyed and regenerated in batches of five
- Maximize your score before time runs out

---

## 🕹 Controls

| Input | Action |
|---|---|
| Left Thumbstick | Continuous movement |
| Right Thumbstick | Camera rotation |
| B Button (hold + release) | Teleport to target location |
| Left / Right Trigger | Click UI buttons via interactor ray |
| Grip | Grab dart |

---

## 🏗 Features

- **Immersive pub environment** with dancing NPCs, ambient lighting, fireplace, and a functioning TV
- **Realistic dart physics** with custom velocity tracking and trajectory correction on release
- **Custom dartboard colliders** built with ProBuilder for accurate hit detection
- **Two locomotion systems**: continuous movement and teleportation
- **Custom grab poses** that replace the default hand model when holding a dart
- **Score tracking UI** displayed in-game per mode
- **Fade transitions** between the main menu, lobby, and game scenes
- **Sound design**: ambient pub music, dart impact effects, and volume control via options menu
- **Replay support**: scenes reset cleanly on revisit

---

## 🛠 Tech Stack

| Tool / Asset | Purpose |
|---|---|
| Unity | Game engine |
| Meta Quest 2 + Oculus SDK | VR headset and controller input |
| ProBuilder | Custom dartboard colliders |
| Unity Asset Store | Dart models, pub environment |
| Valem Tutorials (GitHub) | Hand models, interactor rays, UI components |
| Sketchfab | NPC models |
| Mixamo | Dancing animations |
| FreeSound | Sound effects and background music |

---

## 🗂 Project Structure

```
Assets/
├── Scenes/
│   ├── MainMenu
│   ├── Lobby
│   ├── PointsMode
│   └── TimeMode
├── Scripts/
│   ├── DartThrowing/
│   ├── ScoreManager/
│   ├── UIManager/
│   └── SceneTransitions/
├── Models/
├── Animations/
├── Audio/
└── Prefabs/
```

---

## ⚙️ Setup and Build

### Requirements
- Unity 2022.x or later
- Meta Quest 2 headset
- Oculus Integration SDK
- Android Build Support module (for APK builds)

### Running in Editor
1. Clone the repository
2. Open the project in Unity
3. Connect your Meta Quest 2 via Link or Air Link
4. Open the `MainMenu` scene and press Play

### Building an APK
1. Go to **File > Build Settings**
2. Switch platform to **Android**
3. Select the target scenes in order (MainMenu, Lobby, PointsMode, TimeMode)
4. Click **Build and Run**

---

## 👥 Team

| Name | Student ID |
|---|---|
| Akshat | 200445189 |
| Tai | 200511435 |
| Jeet | 200436140 |
| Manjotveer | 200440731 |
| David | 200442215 |

**Group D | CS 458**

---

## 🚧 Known Limitations

- Single-player only (no multiplayer support)
- No persistent leaderboard between sessions
- Limited pub interactivity (no beer bottles, pool table, or NPC dialogue)
- No dart or dartboard color customization

---

## 🔮 Potential Future Features

- Persistent high score leaderboard with name entry
- Additional game modes (moving dartboard, distance challenges)
- Expanded pub interactivity
- Dart and board customization options
- Publishing to the Meta Quest app store

---

## 📚 References and Credits

- [Valem Tutorials](https://www.youtube.com/@ValemTutorials) — VR development guidance and open-source assets
- Unity Asset Store — Environment and prop assets
- Sketchfab — NPC models
- Mixamo — Character animations
- FreeSound — Audio assets

---

> *Developed as a final project for CS 458. No prior Unity or VR experience was held by any team member at the start of this project.*
