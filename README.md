# NameSorter Application

## 1. Purpose

NameSorter is a **console application** that reads a list of names from a text file, sorts them by **last name first, then given names**, and outputs the sorted list to the console and a file.

- Input: A text file containing one name per line.
- Output: Sorted names to console and text file.
- Handles names with 1–3 given names.

---

## 2. Features

- **Sort Names:** Orders names by last name, then by given names.
- **File I/O Abstraction:** Uses `IFileProvider` for reading/writing files — enables testability.
- **TDD-friendly Architecture:** Functionalities implemented as per unit tests.
- **Console Application:** Easy execution with a input file path and output file path argument.
- **Robust Handling:** Automatically creates output file if missing.

---

## 3. Architecture Overview

```
NameSorter
│
│─ Models
│   └─ Person.cs           # Represents a person with given names and last name
│─ Services
    └─ INameSortingService.cs # Interface for last and given names
│   └─ NameSortingService.cs # Sort logic by last and given names
│─ Utilities
│      └─ IFileProvider.cs    # Interface for file operations
│      └─ FileProvider.cs     # Implementation for reading/writing files│
│─ Program.cs              # Entry point; wires dependencies
│
NameSorterTests
│
│─ PersonTests.cs           # Test person│
│─ NameSortingServiceTests.cs # Test Sort logic by last and given names
│─ FileProviderTests.cs     # Test Implementation for reading/writing files
```

- **Dependency Injection:** `NameSorterRunner` depends on `IFileProvider` and `INameSortingService`.
- **Mockable:** Use Moq or InMemoryFileProvider in tests to avoid real file I/O.

                    ┌────────────────────────────┐
                    │        Program.cs          │
                    │----------------------------│
                    │ - Configures DI container  │
                    │ - Resolves NameSorterRunner│
                    └──────────────┬─────────────┘
                                   │
                                   ▼
                    ┌────────────────────────────┐
                    │     NameSorterRunner        │
                    │-----------------------------│
                    │ + Run(input, output)        │
                    │-----------------------------│
                    │  Uses:                      │
                    │   • IFileProvider           │
                    │   • INameSortingService     │
                    └──────────────┬─────────────┘
                          ▲                ▲
     ┌────────────────────┘                └────────────────────┐
     │                                                         │
     │                                                         │
┌──────────────┐                                    ┌────────────────────┐
│ IFileProvider│                                    │INameSortingService │
│--------------│                                    │--------------------│
│ +ReadAllLines│                                    │ +SortNames(people) │
│ +WriteAllLines│                                   └───────────┬────────┘
└───────┬──────┘                                               │
        │                                                      │
        │                                                      │
┌──────────────────────┐                           ┌────────────────────────┐
│     FileProvider     │                           │   NameSortingService   │
│----------------------│                           │------------------------│
│ Implements file I/O  │                           │ Implements sorting     │
│ (System.IO access)   │                           │ (OrderBy/ThenBy logic) │
└──────────────────────┘                           └────────────────────────┘



---

## 4. Usage

### 4.1 Running from Command Line

```bash
dotnet run --project NameSorter '<<input file path>>', '<<output file path>>'
```

- Output displayed in console.
- Sorted names written to `<<output file path>>` in working directory.

### 4.2 Example

**Input (`unsorted-names-list.txt`):**
```
Janet Parsons
Vaughn Lewis
Adonis Julius Archer
Shelby Nathan Yoder
```

**Output (`sorted-names-list.txt`):**
```
Adonis Julius Archer
Vaughn Lewis
Janet Parsons
Shelby Nathan Yoder
```

---

## 5. Key Classes

### `Person`
- Represents a person’s full name.
- Splits given names and last name for sorting.

### `NameSortingService` / `INameSortingService`
- Sorts a collection of `Person` objects.
- Implements **stable sorting**: last name, then given names.

### `IFileProvider` / `FileProvider`
- `ReadAllLines(path)` – returns lines from a file.
- `WriteAllLines(path, lines)` – writes lines; creates file & directory if missing.
- Enables **mocking** for tests.

### `NameSorterRunner`
- Reads names using `IFileProvider`.
- Sorts them using `INameSortingService`.
- Writes sorted names back using `IFileProvider`.

---

## 6. Testing / TDD Notes

- **Unit Tests:**
  - `NameSortingServiceTests`: test sorting logic with hardcoded names.
  - `NameSorterRunnerTests`: test name sorting functionality using `IFileProvider` & `INameSortingService` mocks.
  - `FileProviderTests`: test file read and write functionality.
  - `PersonTests`: test person class implementation.
  
- **Mock Example (Moq):**
```csharp
var inputLines = new[] { "Vaughn Lewis", "Marin Alvarez", "Beau Tristan Bentley" };

var mockFileProvider = new Mock<IFileProvider>();
mockFileProvider.Setup(f => f.ReadAllLines("input.txt")).Returns(inputLines);

var readLines = mockFileProvider.Object.ReadAllLines("input.txt");
```

- **Best Practices:**
  - Test only your business logic, not `System.IO`.
  - Use small, single-responsibility tests.
  - Capture writes via callbacks in mocks.

---

## 7. Dependencies

- .NET Core 8.0+
- [Moq](https://github.com/moq/moq4) (for unit tests)
- NUnit (test framework)

---

## 8. Running Tests

```bash
dotnet test
```

- Tests cover sorting logic and other functionalities.
- No real file system access required; all I/O is mocked.

---

## 9. Notes / Best Practices

1. `WriteAllLines` automatically creates the file and directories.
2. Use `IFileProvider` for all file interactions to remain testable.
3. Keep tests small and descriptive — one behavior per test.
4. Follow **SOLID principles** for maintainability.

