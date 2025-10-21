# 🎮 **Arena-Six**

### *A Professional Development Case Study*

---

## 🧭 **Overview**

As mentioned, this GitHub was created as part of my on-going effort to build with real-world discipline, not just to write clean, functional code, but to think critically about planning, design, documentation, and long-term maintainability.

One of the projects I chose to revisit is *Arena-Six*, a game originally developed during my final year at university as part of a small team project.

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

## 🌍 **Context**

*Arena-Six* is a player-vs-player fighting game set in a dystopian future where two Samurai-like warriors, each with unique skill sets, battle to the death within a confined arena.

The game drew inspiration from several titles in this genre, particularly MOBAs, and was built using the **Mechanics–Dynamics–Aesthetics (MDA)** design framework to guide the gameplay experience and balance player interaction.

The assignment was to assemble and work within a group of four to five members, each member having a unique role, in an effort to simulate a typical work environment in the game design industry.

Together, we were tasked with creating a fully realized, functional game of our own choosing within three months. The expected outcome was a final product that could stand alongside small-scale indie titles in terms of quality and completeness.

**Each member of the team took on a dedicated role:**

* 🧩 **Project Manager:** Oversaw development milestones, scheduling, and team coordination.
* 🎮 **Game Designer:** Responsible for core mechanics, character abilities, and arena flow.
* 🎨 **Art & Animation:** Created visual assets, effects, and character models and animations.
* 🏗️ **Asset Creation:** Developed environmental and prop models, ensuring consistency in art direction.
* 💻 **Programming (Lead – Myself):** Built and maintained the core gameplay systems, including player control, combat logic, and the underlying state management.

---

## 🔧 **Main Focus (Revisit)**

In revisiting *Arena-Six*, my primary goal was to improve the internal architecture of the **Finite State Machine (FSM)** that governed player actions and transitions.

Originally, the FSM was tightly coupled and difficult to maintain, with logic scattered in the wrong places (such as within player controllers). State transitions were hard-coded, and adding new states required modifying existing ones, which made the system fragile and error-prone.

This went against the design principles I had originally tried to model after: the *Pluggable AI with Scriptable Objects* tutorial series from Unity.

That approach promotes building behaviour systems where individual states or actions can be added, removed, or swapped without breaking the overall structure.

With this revisit, my goal was to rebuild the FSM so that each state operated independently, communicated through consistent interfaces, and could easily support new combat states or mechanics in the future, all while adhering more closely to the design principles behind the *Pluggable AI with Scriptable Objects* architecture that originally inspired it.

---

## 🧠 **Design Approach: Finite State Machines and the Pluggable System**

A **Finite State Machine (FSM)** is one of the most common ways to control how a game character behaves. For example, deciding when to idle, attack, dodge, or take damage.

FSMs are used across many genres because they make behaviour predictable, structured, and easy to visualize. However, there are several ways to implement them, each with different trade-offs.

### ⚙️ **Common Implementation Approaches**

**1️⃣ Code-Driven FSM (Traditional)**
In this approach, every state and transition is written directly in code, usually as a series of `if` or `switch` statements inside a single script.
At the time, my level of experience was mostly limited to this method.

* ✅ *Strengths:* Easy to prototype, no extra setup required.
* ⚠️ *Limitations:* Quickly becomes large and hard to maintain; adding or changing states often breaks existing logic.

**2️⃣ Graph-Based FSM (Visual Editors)**
Tools like Unity’s *Animator Controller*, *PlayMaker*, or *NodeCanvas* allow designers to build FSMs visually using nodes and wires.

* ✅ *Strengths:* Highly visual and great for collaboration between designers and programmers.
* ⚠️ *Limitations:* Logic can become fragmented across graphs and difficult to debug; performance or version-control issues can appear on larger projects.

**3️⃣ Pluggable FSM with Scriptable Objects**
In this model, behaviours are written as small, reusable scripts and saved as **Scriptable Object** assets in Unity.
Each *State* holds a list of *Actions* (what to do) and *Decisions* (when to transition).

* ✅ *Strengths:* Combines code clarity with designer flexibility; modular, data-driven, and scalable.
* ⚠️ *Limitations:* Requires slightly more upfront setup and careful asset management.

---

## 💡 **Why This Approach Fit Arena-Six**

Although the *Pluggable AI with Scriptable Objects* pattern was originally designed for AI behaviour, I believed it could also be applied effectively to player interactions.

For *Arena-Six*, our goal was to build a fast-paced, action-focused player system composed of many short-lived states, such as *Idle*, *Move*, *Dash*, *Shoot*, *Melee*, *Lock-On*, *Hurt*, *Emote*, and others.

Because of this, I knew the code-driven approach I was accustomed to wouldn’t scale, but early in development, my inexperience caused me to blend that familiar approach with the Pluggable FSM system, creating a hybrid that was neither fully modular nor maintainable.

I ended up hard-coding transitions directly inside the controller, which quickly became difficult to manage and limited how easily we could expand or adjust gameplay.

In the end, the game was working and fully functional by the time we submitted it, but under the hood, it was a complete mess, filled with tangled logic and duplicated code that was hard to follow or modify.

In hindsight, a stronger understanding of the Pluggable FSM concept would have allowed me to design the system as it was truly intended:

* ⚙️ Each behaviour (*Action* or *Decision*) functioning as an independent, reusable asset.
* 🧩 States assembled like building blocks, making the FSM easier to extend, debug, and reuse.
* 🎨 Designers able to iterate on gameplay logic without code changes.

If implemented with this mindset, the project would have been both manageable within our 3-month timeframe and structured around professional, production-ready design principles, standards I’ve been working towards while revisiting and refactoring the codebase.

---

## 🧩 **Challenges & Solutions**

### 1️⃣ **Blending Two Systems**

**Challenge:**
In the original version of *Arena-Six*, I combined my early code-driven habits with the Pluggable FSM system, creating a tangled hybrid. Transitions were still hard-coded inside the controller, while some states tried to follow the Pluggable structure. This made it inconsistent and hard to maintain.
**Solution:**
When revisiting the project, I fully separated concerns. The *PlayerController* became responsible only for input and state delegation, while each *Action* and *Decision* handled its own logic and animation triggers. This made the system cleaner, easier to extend, and far more predictable.

### 2️⃣ **Overcomplicating Early Design**

**Challenge:**
During the original build, I often added extra logic inside states to “make things work.” The FSM quickly grew dense, and debugging even small issues became frustrating.
**Solution:**
I approached the refactor with a *less-is-more* mindset, focusing on clarity and responsibility boundaries. Each state now performs one job well, and transitions are event-based rather than chained conditions. This made debugging simpler and behaviour easier to reason about.

### 3️⃣ **Lack of Clear Data Ownership**

**Challenge:**
Important gameplay data, for example, health, dash stamina, and weapon charge was scattered across scripts and modified from multiple places.
**Solution:**
I reorganized the code around **data ownership**:

* 🧍‍♂️ *PlayerStats* now manages player-related data (health, dash timing, etc.).
* 🔫 *GunStats* owns all weapon logic (ammo, firing delay, charge states).
  This resulted in clearer data flow and fewer hidden dependencies.

### 4️⃣ **Animation and Feedback Coupling**

**Challenge:**
Originally, animations, sounds, and effects were all triggered manually in the controller or tied to state names. Adding a new ability meant updating multiple files.
**Solution:**
Each *Action* or *Decision* now triggers its own animations, sounds, and effects where appropriate (for example, *Dash*, *Hurt*, or *HeavyShot*). This localizes feedback control and reduces the chance of unintended overlap between behaviours.

### 5️⃣ **Time Pressure and Scope**

**Challenge:**
Working within a three-month deadline meant the team had to prioritize functionality over structure. My focus was on making sure the game worked and met deliverables, even if the underlying code wasn’t clean.
**Solution:**
Although I didn’t have the time or experience to address these issues during the project, revisiting the code later became the solution itself.
It allowed me to properly separate responsibilities, rebuild the FSM with a modular architecture, and understand how design constraints like time can influence technical decisions.

---

## 🌱 **Outcomes & Lessons Learned**

1. ✅ *A System That Finally Worked as Intended*
2. 🧠 *Architecture Shapes Creativity*
3. 🤝 *Modularity Improves Collaboration*
4. 🧩 *Refactoring Is a Learning Tool, Not Just a Cleanup*
5. 💡 *Quality Comes From Process, Not Just Output*

Each point has been faithfully preserved, only styled for clarity and visual appeal.

---

## 🔮 **Future Improvements**

While the refactored FSM achieved the modularity and structure I initially wanted, there are still several systems I’d like to revisit and refine in the future, particularly the various managers that control the game’s global behaviour.

* 🧠 **Centralized Game Manager**
  
At the moment, many of the game’s high-level responsibilities such as match flow, state resets, and player initialization, are handled locally within scripts that should ideally remain focused on gameplay.
Creating a proper GameManager would allow for clearer control over the game loop, reduce duplication, and make it easier to coordinate systems like round restarts, timers, and overall game states.

* 🎵 **Audio Manager**
  
Audio cues are currently triggered at the action level, which works for simple setups but becomes difficult to manage as sound complexity increases. A centralized AudioManager could handle playback, priority, and variation logic, while still allowing actions to simply request sounds when needed.

* 🧾 **UI and Feedback Management**
  
The user interface and feedback systems (HUD, crosshairs, health bars, damage indicators) are partly coupled to player scripts.
A dedicated UIManager could handle these elements more efficiently, separating data presentation from gameplay logic and making it easier to maintain or expand the UI.

* 🔁 **Persistent Systems Framework**
  
In future iterations, I’d like to implement a persistent systems layer, managers that persist across scenes or game modes.
This would streamline loading, transitions, and global data handling, paving the way for scalable features like settings, save data, or character progression.

---

## 🏁 **Conclusion**

Revisiting Arena-Six became far more than a code cleanup exercise, it was a chance to measure how much I’ve grown as a developer. What started as a rushed university project evolved into a personal study of structure, scalability, and intentional design.

By rebuilding the FSM and improving the game’s internal architecture, I learned the importance of designing for clarity, not convenience. 

I also realized that professional development isn’t just about mastering syntax or frameworks, it’s also about learning to think critically about how systems fit together, how teams collaborate, and how structure shapes creativity.

This project now stands as a reflection of that growth: the messy foundation that taught me why **architecture matters**, and how disciplined, modular design can transform a student prototype into a system that feels professional and production-ready.

---



