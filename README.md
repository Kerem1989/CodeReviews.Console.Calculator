# Console Calculator

A console-based calculator application built with C# and .NET 8, following the [Microsoft Create a Calculator App](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console) tutorial (Parts 1 & 2).

This is a project from [The C# Academy](https://www.thecsharpacademy.com/).

## Features

- Basic arithmetic operations: addition, subtraction, multiplication, division
- Square root and power calculations
- Input validation for numeric entries
- Division-by-zero protection
- Operation history tracking with usage counter
- View and clear calculation history
- JSON logging of all operations to file

## How It Works

The application presents a menu-driven interface:

1. **Perform a calculation** - Enter two numbers and choose an operation
2. **View result history** - Display a numbered list of previous results
3. **View operation count** - See how many calculations have been performed
4. **Clear history** - Delete all stored results
5. **Exit** - Close the application and finalize the JSON log

## Project Structure

The solution contains two projects:

```
Kerem.Calculator/
├── CalculatorProgram/          # Console application (entry point)
│   └── Program.cs
├── CalculatorLibrary/          # Class library
│   ├── CalculatorLibrary.cs    # Calculator logic and JSON logging
│   ├── CalculatorHistory.cs    # History data model
│   └── CalculatorHistoryService.cs  # History operations
└── Kerem.Calculator.sln
```

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Running the Application

```bash
cd Kerem.Calculator
dotnet run --project CalculatorProgram
```

## Dependencies

- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) - JSON operation logging

## Lessons Learned

- Working with multiple projects in a single solution
- Writing to files using JSON serialization
- Debugging techniques in C#/.NET
- Following official Microsoft documentation
