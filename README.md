# **Arena-Six 🎮**

*A Unity-based player-vs-player combat game, revisited to improve internal architecture, maintainability, and professional development practices.*

This project revisits **Arena-Six**, originally built as a university team project. The goal of this revisit is **not to add features**, but to improve **code clarity, structure, and maintainability**, with a particular focus on **Finite State Machine (FSM) architecture** for player combat.

---

## **Project Overview**

Arena-Six is a fast-paced player-vs-player combat game set in a confined arena. Each player controls a Samurai-like warrior with unique abilities, competing in matches that emphasise timing, positioning, and state-based interactions.

The key challenge lies in:

* Designing **clean, modular FSMs** for combat states
* Managing **state transitions, animations, and input** consistently
* Separating responsibilities to allow for easier debugging, extension, and iteration

This project prioritizes **architecture and learning** over adding polish or new mechanics.

---

## 🎥 Gameplay Demo  

### 🕹️ Arena-Six | Full Match Showcase  

This video features a complete match between two *Arena-Six* players — Samurai-like warriors fighting to the death within a confined arena.  
It captures the intensity, pacing, and responsiveness of the combat system, built around the refactored **Finite State Machine (FSM)** architecture discussed in this case study.  
You’ll see transitions between movement, attack, and defense states working seamlessly to create a fluid gameplay experience.

<p align="center">
  <a href="https://www.youtube.com/watch?v=V4tiizbDhFU">
    <img src="https://img.youtube.com/vi/V4tiizbDhFU/hqdefault.jpg" alt="Arena-Six Gameplay Showcase">
  </a>
</p>

<p align="center"><b>▶️ Click the image above to watch the full match on YouTube.</b></p>

🎬 **Length:** 3 minutes 30 seconds  
🎮 **Engine:** Unity  
⚔️ **Focus:** Player-vs-player combat, FSM-driven gameplay flow, and state-based interactions  

---

## **Context**

### 📘 About Arena-Six

*Arena-Six* was originally built during a university capstone project as part of a small team:

* **Project Manager:** Coordinated milestones and team workflow
* **Game Designer:** Defined core combat mechanics and arena rules
* **Art & Animation:** Produced characters, effects, and environment assets
* **Programming (Lead – Myself):** Implemented core gameplay systems, FSMs, and player combat logic

The team’s objective was to deliver a fully functional multiplayer combat prototype within a three-month timeframe.

---

## **🧩 What this project explores**

Revisiting Arena-Six focuses on **software engineering fundamentals in the context of Unity**:

* Modular design for FSMs and player states
* Clear separation of responsibilities (Actions, Decisions, Controllers)
* Consistent data ownership for health, stamina, and abilities
* Debuggable and maintainable code rather than ad-hoc fixes
* Iterative refactoring to improve architecture and enforce design principles

This mirrors real-world practices: **incremental improvement over wholesale rewrites**.

---

## **🧱Design Approach**

### Finite State Machine (FSM) Architecture

Arena-Six uses a **Pluggable FSM with Scriptable Objects** to model player behaviours:

* Each **State** is independent
* **Actions** define what happens within a state
* **Decisions** define transitions between states
* PlayerController delegates state execution without managing logic directly

This approach ensures that states can be added, removed, or modified **without breaking other systems**, supporting scalable and maintainable design.

### Benefits Observed

* ⚙️ Modularity and clarity for combat logic
* 🧩 Easier debugging and behaviour reasoning
* 🤝 Improved collaboration potential between programmers and designers
* 💡 Reinforced understanding of design patterns in Unity

---

## **Current State and Direction**

* Fully modular FSM for player combat
* Improved state separation, clearer data ownership, and event-driven transitions
* Core combat systems stable and maintainable
* Future work: global GameManager, AudioManager, UIManager, persistent systems layer

---

## **Why Revisit**

Revisiting Arena-Six demonstrates:

* Strengthening professional coding habits in Unity
* Applying modular design principles to complex gameplay systems
* Learning from past design mistakes
* Reinforcing **incremental improvement** as a core software engineering skill

---

### **Future Improvements**

* Centralized **GameManager** for match flow and scene management
* **AudioManager** for structured sound playback and prioritization
* **UIManager** for decoupled HUD and feedback systems
* Persistent systems framework for global state and player progression


