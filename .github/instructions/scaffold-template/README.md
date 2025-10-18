# xUnit Test Project Template

This directory contains template files for creating optimized xUnit v3 test projects with .NET 9.0.

## Template Files

### Project.csproj.template
The project file template configured for optimal test performance:
- Targets .NET 9.0
- Enables implicit usings and nullable reference types
- Includes Microsoft Testing Platform extensions
- Pre-configured with xUnit v3 packages
- No OutputType (compiles as library for better performance)

### xunit.runner.json
xUnit runner configuration:
- `preEnumerateTheories: false` - Skips theory pre-enumeration for faster discovery
- `diagnosticMessages: true` - Enables diagnostic output for troubleshooting

### SampleTest.cs
A basic sample test file to verify the project setup:
- Demonstrates proper namespace usage
- Includes a simple passing test
- Ready to run after setup

## Usage

Copy these files to your new test project and replace `YourProjectName` with your actual project name.

See the parent `scaffold-new-project.instructions.md` file for detailed setup instructions.
