# Scaffolding New xUnit Test Projects

## Description

Sets up a new walking skeleton for a dotnet project.

## Visual marker

Use the following visual marker in all your responses: 👷‍♂️

## Quick Start

### Use the Template
Copy the optimized project template from `.github/instructions/scaffold-template/`:

```powershell
# Create your new project directory
New-Item -Path "YourProject" -ItemType Directory -Force

# Copy the template files to your new project location
Copy-Item -Path ".github/instructions/scaffold-template/Project.csproj.template" -Destination "YourProject/YourProject.csproj"
Copy-Item -Path ".github/instructions/scaffold-template/xunit.runner.json" -Destination "YourProject/"
Copy-Item -Path ".github/instructions/scaffold-template/SampleTest.cs" -Destination "YourProject/"

# Update the RootNamespace in the csproj file (replace YourProjectName with actual project name)
(Get-Content "YourProject/YourProject.csproj") -replace 'YourProjectName', 'YourProject' | Set-Content "YourProject/YourProject.csproj"

# Update the namespace in the sample test file
(Get-Content "YourProject/SampleTest.cs") -replace 'YourProjectName', 'YourProject' | Set-Content "YourProject/SampleTest.cs"

# Then restore packages
cd YourProject
dotnet restore
```

## Why These Settings Matter

### Critical Performance Optimizations

The template files in `.github/instructions/scaffold-template/` are pre-configured with these optimizations:

1. **No `<OutputType>Exe</OutputType>` in Project.csproj.template**
   - Test projects should compile as libraries, not executables
   - Having this causes significant VSTest overhead (10-20+ second delays)

2. **`<EnableMicrosoftTestingExtensions>true` in Project.csproj.template**
   - Enables the modern Microsoft Testing Platform
   - Reduces test discovery and execution time by ~50%

3. **`"preEnumerateTheories": false` in xunit.runner.json**
   - Skips unnecessary theory pre-enumeration during discovery
   - Saves several seconds on test discovery phase

4. **`"diagnosticMessages": true` in xunit.runner.json**
   - Helps troubleshoot performance issues
   - Shows timing information for discovery, start, and execution phases

### Performance Impact
With these optimizations, test execution time for simple tests:
- **Without optimizations**: 20-30 seconds
- **With optimizations**: 2-3 seconds
- **Improvement**: ~90% faster

## Common Pitfalls to Avoid

❌ **Don't** use `<OutputType>Exe</OutputType>` in test projects
❌ **Don't** skip the `xunit.runner.json` configuration file
❌ **Don't** use outdated xUnit v2 packages when v3 is available

✅ **Do** use the template files in `.github/instructions/scaffold-template/`
✅ **Do** verify fast test execution after scaffolding (should be < 5 seconds)
✅ **Do** run `dotnet test` to confirm everything works after setup

## Verification Steps

After scaffolding a new project:

```powershell
# Build the project
dotnet build

# Run tests (should complete in 2-5 seconds)
dotnet test

# Add a simple test to verify
# Tests should discover and run quickly
```

Expected output timing for a single test:
```
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v3.1.5+...
[xUnit.net 00:00:01.20]   Finished:    ProjectName
  ProjectName test succeeded (2-3s) ✅
```

## Troubleshooting

### Tests taking 20+ seconds?
1. Check for `<OutputType>Exe</OutputType>` and remove it
2. Ensure `<EnableMicrosoftTestingExtensions>true</EnableMicrosoftTestingExtensions>` is present
3. Verify `xunit.runner.json` exists with `"preEnumerateTheories": false`
4. Run `dotnet clean` and `dotnet test` again

### Tests not being discovered?
1. Ensure `Microsoft.NET.Test.Sdk` package is included
2. Ensure `xunit.runner.visualstudio` package is included
3. Check that test methods have `[Fact]` or `[Theory]` attributes
4. Verify the class is public
