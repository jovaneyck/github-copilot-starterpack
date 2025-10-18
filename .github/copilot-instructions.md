# GitHub Copilot Starterpack

This repository demonstrates best practices for configuring AI coding agents through instruction files, custom prompts etc.

### Technology Stack
- **.NET 9.0**: Target framework
- **xUnit v3**: Modern testing framework with Microsoft Testing Platform
- **C# 13**: Implicit usings, nullable reference types enabled
- **PowerShell**: Default shell for automation

### ⚠️ CRITICAL: Always Verify Before Returning Control
**Before completing any task and returning control to the user, you MUST:**
1. Ensure the code compiles without errors
2. Run `dotnet test` to verify all tests pass
3. Report any compilation errors or test failures and fix them before finishing

This is non-negotiable. Never leave the user with broken code or failing tests.

# Visual markers

Every type of instruction should use a visual marker that you include in all your responses. The default visual marker for general instructions in this project is: 🤖