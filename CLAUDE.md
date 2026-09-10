# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

A CIS 273 (Data Structures) student lab assignment: `Lab0.sln` in .NET/C#. It contains 4 starter-code exercise projects plus one shared test project (all targeting `net10.0`). Most classes are stubs marked `// TODO` — the assignment is to implement the missing behavior so that `UnitTests` passes. Grading criteria and exact expected behavior for every method are spelled out in [README.md](README.md); read it before implementing or changing any project, since it is the spec, not just documentation.

## Commands

```bash
dotnet build Lab0.sln                       # build everything
dotnet run --project Uno                      # run the Uno project
dotnet test                                 # run all tests (from repo root, or cd UnitTests)
dotnet test --filter TestCategory=MergeArrays   # run just one project's tests
dotnet test --filter TestCategory=Uno
dotnet test --filter TestCategory=Vector
dotnet test --filter FullyQualifiedName~TestMergeArrays1   # run a single test method
```

Tests use MSTest (`[TestClass]`/`[TestMethod]`), and each test class is tagged with `[TestCategory("...")]` matching its project name (`MergeArrays`, `Uno`, `Vector` — `Prayer` currently has no tests). There is no linter configured in this repo.

Each exercise project (`MergeArrays`, `Uno`, `Vector`, `Prayer`) is also an `Exe` with its own empty/near-empty `Program.Main`, useful as a scratch space for manual testing, but the real correctness check is `dotnet test`.

## Architecture

The solution is 4 independent exercise projects (no cross-references between them) plus one test project that references all four via `ProjectReference`:

- **MergeArrays** — a single static method exercise (`Program.MergeSortedArrays`), both a non-generic `int[]` version and a generic `T[] where T : IComparable<T>` version. Must merge two *pre-sorted* arrays without using `Array.Sort`/`List<T>.Sort` (two-pointer merge).
- **Uno** — a 3-class card game model: `UnoGame` (holds `Players`, `DrawStack`, `DiscardStack`, `CurrentColor`), `Card` (has `Type`/`Color`/`Number`, plus the core rule method `Card.PlaysOn(card1, card2, currentColor)` and a `ToString` format that varies by `CardType`), and `Player` (hand of cards; `HasPlayableCard`, `GetFirstPlayableCard`, `MostCommonColor` all depend on `Card.PlaysOn`). Get `Card.PlaysOn` right first — the `Player` methods build on it.
- **Vector** — a `struct Vector` (2D vector: `X`, `Y`, computed `Magnitude`/`Direction`) with both instance methods (`Add`, `Subtract`, `Dot`, `AngleBetween`, `Multiply`, `Divide`, `Normalize`) and equivalent static methods, several of which are also exposed as overloaded operators (`+`, `-`, `*` for both dot product and scalar multiply, `/`). Instance and static/operator versions must all agree — see [Vector/Program.cs](Vector/Program.cs) for the intended call patterns.
- **Prayer** — a data-model exercise: `Prayer` (Title/Subtitle/Body/ScriptureReferences/Author/Tags/ImageUrl/CreatedAt/UpdatedAt) plus supporting types `Author`, `ScriptureReference`, `Tag`, currently all empty stub classes. The main work is `Prayer.ToString()`, which must conditionally omit lines for absent optional fields (`Subtitle`, `ScriptureReferences`, `Author`, `Tags`) rather than printing them empty — see the README's formatting example.

`UnitTests` is the only project that binds the others together; when changing a public API's shape (method signature, property name), check `UnitTests/*.cs` for the exact usage the tests expect, since the tests encode the assignment spec precisely (e.g. exact `ToString()` output strings, tie-breaking order in `MostCommonColor`).
