# GitHub Copilot Instructions for Custom Hit Marker (Continued)

## Mod Overview and Purpose

The "Custom Hit Marker (Continued)" mod for RimWorld is an updated version of the original mod by Dalrae. The primary purpose of this mod is to visually display a hit marker on successful attacks in the game, enhancing the combat experience with a simple yet effective graphical indicator. This mod is aimed at players who want a more immersive and informative feedback system during combat situations.

## Key Features and Systems

- **Hit Marker Display:** The core feature of the mod is its ability to create a visual hit marker on successful hits, providing immediate feedback to the player about the effectiveness of their attacks.
- **Selective Activation:** As of the update on April 14, 2019, mining activities will no longer trigger hit markers, ensuring that markers are only shown during actual combat scenarios.
- **Harmony Integration:** Utilizes Harmony patches to inject custom behavior into existing game mechanics without modifying core game files.
- **Error Handling and Support:** Includes suggestions for troubleshooting and community support through Discord for error reporting.

## Coding Patterns and Conventions

- **C# Naming Conventions:** 
  - Classes and methods follow PascalCase (e.g., `CustomHitMarker`, `TriggerHitMarking`).
  - Local variables and private fields use camelCase.
  - Constants are in ALL_UPPERCASE.

- **Code Structure:**
  - Each logical component is isolated into its own class file for clarity and maintainability.
  - Use descriptive naming to convey method functionality and improve readability.

## XML Integration

- **XML Definitions:** The mod includes XML files defining the necessary `SoundDef` and `ThingDef` elements. These definitions are crucial for integrating the visual and audio aspects of the hit marker with the game engine.
- **File Structure:** 
  - Located in the `Defs` directory, key XML configurations are organized to keep the mod extensible and compatible with future updates.
  - Ensure that XML def names are unique to prevent conflicts with other mods.

## Harmony Patching

- **Patch Locations:** Harmony patches are applied in various parts of the game, primarily targeting damage calculation and entity interactions.
  - `Pawn_Kill.cs` uses a postfix patch to add behavior after a kill event.
  - `Thing_TakeDamage.cs` uses a postfix patch to customize the damage-taking events.
  
- **Patch Safety:** Always ensure patches are wrapped in try-catch blocks to prevent runtime errors from breaking the game.

## Suggestions for Copilot

When using GitHub Copilot to assist with this mod development, consider the following suggestions to enhance productivity:

1. **Predictive Completion:** Use Copilot to suggest and complete repetitive code patterns, such as similar method definitions or XML tag structures.
   
2. **Documentation Generation:** Leverage Copilot to generate XML documentation comments for your methods and classes to maintain self-documenting code practices.
   
3. **Error Handling:** Get suggestions for robust error handling practices, including suggestions for logging and debugging outputs.
   
4. **Harmony Patch Creation:** Copilot can provide skeletons for new prefix/postfix patches, saving time and ensuring correct use of Harmony APIs.

By integrating these practices and utilizing GitHub Copilot effectively, the development and maintenance of the "Custom Hit Marker (Continued)" mod can be optimized significantly.

## Contribution and Support

- **Troubleshooting Steps:** Enable only this mod and its required dependencies to isolate issues. Gradually enable other mods to identify conflicts.
- **Community Support:** Post error logs via the Log Uploader tool, and join our Discord channel for real-time support. Avoid using discussion threads for error reporting to ensure timely responses.
- **Contribution:** Share solutions or improvements by contributing to the GitHub repository to help enhance the mod for all users.

By following these instructions and recommendations, developers can effectively contribute to and expand the functionality of the "Custom Hit Marker (Continued)" mod. Happy modding!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

