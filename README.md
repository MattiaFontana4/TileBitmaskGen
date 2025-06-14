# TileBitmaskGen

TileBitmaskGen is a work-in-progress .NET 8 (C# 12) library for generating bitmask values and code for tile-based systems.
The solution provides both a reusable library and a WinForms application to simplify the creation and export of tile bitmask data.

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/) installed
- Windows 10/11 (the WinForms app targets `net8.0-windows`)

## Building

From the repository root run:

```bash
dotnet build
```

This compiles the solution and all projects.

## Running the WinForms application

Launch the GUI with:

```bash
dotnet run --project TileBitmaskGen
```

## Projects

- **TileBitmaskGen** – WinForms application used to create and export tile rules.
- **TileBitmaskCore** – cross-platform library that contains the bitmask generation logic.
- **TestProject** – Unit tests covering the bitmask generator logic.

## Running tests

Execute the unit tests with:

```bash
dotnet test
```
