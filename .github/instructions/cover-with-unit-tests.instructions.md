# Unit Testing Best Practices

Visual marker for this instruction: 🧪

## Purpose
This document outlines the workflow for achieving comprehensive unit test coverage, including equivalence class analysis and data-driven testing patterns.

## Workflow

### 1. Analyze Implementation for Equivalence Classes
Before writing tests, examine the implementation code to identify all distinct code paths and logical branches:

**Example from FizzBuzz.cs:**
- Multiple of 15 (both 3 and 5) → "FizzBuzz"
- Multiple of 3 only → "Fizz"
- Multiple of 5 only → "Buzz"
- Not multiple of 3 or 5 → number as string
- Edge cases: 0, negative numbers, boundaries

### 2. Identify Missing Test Coverage
Compare existing tests against identified equivalence classes to find gaps:
- List what's currently tested ✅
- List what's missing ❌
- Prioritize critical paths and edge cases

### 3. Add Tests for Each Equivalence Class
Write at least 2 test cases per equivalence class to validate the pattern holds:
```csharp
// Example: Multiple tests per class
[InlineData(3, "Fizz")]   // First case
[InlineData(6, "Fizz")]   // Validates pattern
```

### 4. Refactor to Data-Driven Tests
Use xUnit `[Theory]` with `[InlineData]` instead of multiple `[Fact]` methods:

**Before (verbose):**
```csharp
[Fact]
public void Test_Case1() { /* ... */ }

[Fact]
public void Test_Case2() { /* ... */ }
```

**After (concise):**
```csharp
[Theory]
[InlineData(input1, expected1)]
[InlineData(input2, expected2)]
public void Test_ReturnsExpectedValue(int input, string expected)
{
    var result = SystemUnderTest.Method(input);
    Assert.Equal(expected, result);
}
```

### 5. Verify Tests Pass
**CRITICAL**: Always run tests after making changes:
```powershell
dotnet test
```

Only hand control back to the user after confirming:
- ✅ All tests pass
- ✅ Code compiles successfully
- ✅ No warnings or errors

## Benefits of This Approach

### Equivalence Class Analysis
- Ensures comprehensive coverage of all code paths
- Identifies edge cases systematically
- Prevents gaps in test coverage

### Data-Driven Testing
- **Concise**: 70%+ reduction in lines of code
- **Maintainable**: Easy to add new test cases
- **Readable**: All test scenarios visible at a glance
- **Independent**: Each data row runs as a separate test

## Example Result
From the FizzBuzz implementation:
- Started with 1 test
- Analyzed for equivalence classes
- Added 8 more tests (9 total)
- Refactored to 1 Theory with 9 InlineData attributes
- Reduced from ~60 lines to ~17 lines
- All tests passing ✅

## When to Use

### Use [Theory] with [InlineData] when:
- Testing the same logic with different inputs
- Multiple similar test cases exist
- Input/output pairs are simple values

### Keep separate [Fact] methods when:
- Test setup differs significantly between cases
- Complex object initialization required
- Testing completely different behaviors
