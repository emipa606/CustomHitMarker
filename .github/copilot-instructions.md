# .github/copilot-instructions.md

## Mod Overview and Purpose

The [Mod Name] is a RimWorld mod designed to enhance the gaming experience by introducing custom hit markers. The mod provides players with visual feedback when their characters attack or are attacked, adding an immersive layer to combat scenarios. It enriches gameplay by giving clear indicators of successful hits, making battles more engaging and easier to follow.

## Key Features and Systems

- **Custom Hit Markers**: The core feature of the mod is the addition of custom hit markers that provide visual feedback during combat. These markers help players identify successful hits and damage dealt more intuitively.
- **Static Utility Classes**: The mod utilizes static utility classes to manage and display hit markers effectively, ensuring efficient performance and easy maintenance.
- **XML Integration**: XML files are used to define new hit markers, allowing for easy customization and mod extension.

## Coding Patterns and Conventions

- **Static Classes**: The main logic is encapsulated in static classes `CustomHitMakerA`, `CustomHitMakerB`, and `CustomHitMarker`. Utilizing static classes helps in organizing code that does not alter state and is used globally across the application.
- **Consistent Naming Conventions**: Classes and methods follow PascalCase conventions, ensuring readability and consistency throughout the codebase.
- **DRY Principle**: The mod adheres to the "Don't Repeat Yourself" principle, where reusable logic is centralized in utility methods to minimize redundancy.

## XML Integration

- **Mod Configuration**: XML files are utilized for defining properties related to hit markers. This allows for a modular design where adjustments can be made without altering the core C# code.
- **Ease of Customization**: Players and other modders can easily modify XML entries to customize the appearance and behavior of hit markers.

## Harmony Patching

- **Non-Invasive Mod Development**: Harmony is employed to patch the game's methods to ensure that custom hit markers integrate seamlessly with the existing game mechanics without altering original game files.
- **Targeted Patching**: Only specific methods responsible for character hits and combat feedback are patched, ensuring minimal impact on game performance and stability.

## Suggestions for Copilot

- **Code Suggestions**:
  - Use Copilot to generate method stubs for new features or expansions to existing hit marker functionalities.
  - Utilize Copilot to explore various implementations for optimizing the display logic of hit markers.

- **XML Support**:
  - Use Copilot to suggest XML schema validation techniques, ensuring that all custom hit marker definitions comply with the required format.

- **Harmony Patching**:
  - Leverage Copilot to generate basic Harmony patch templates, streamlining the process of integrating new patches into the mod.

By adhering to the above guidelines and making effective use of GitHub Copilot, mod developers can ensure a robust, maintainable, and engaging mod experience for RimWorld players.
