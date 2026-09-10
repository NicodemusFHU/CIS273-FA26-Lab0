# Lab 0 — C# Warmup

**CIS 273 — Data Structures**

## Directions

Create 4 separate projects in 1 solution for this assignment. Starter code for each project (plus a shared `UnitTests` project) is provided in this repository:

| Project | Purpose |
|---|---|
| `MergeArrays` | Section 1 — merging sorted arrays |
| `Uno` | Section 2 — Uno card game model |
| `Vector` | Section 3 — 2D vector struct |
| `Prayer` | Section 4 — prayer database model |
| `UnitTests` | Tests exercising the above projects |

## 1. Merge Sorted Arrays Efficiently 

Write a method that takes 2 sorted arrays and returns a sorted, merged array. Duplicates are **not** removed. The method should conform to this API:

```csharp
public static int[] MergeSortedArrays(int[] array1, int[] array2)
```

For example, given

```
array1 = {1, 3, 4, 9}
array2 = {2, 5, 6, 7, 9}
```

```MergeSortedArrays(array1, array2)```
should return: 
```
{1, 2, 3, 4, 5, 6, 7, 9, 9}
```

Do **not** use `Array.Sort()` or `List<T>.Sort()` to accomplish this. Merge the two sorted arrays directly (e.g., with a two-pointer approach).

Also write a generic version of the method with the same behavior:

```csharp
public static T[] MergeSortedArrays<T>(T[] array1, T[] array2) where T : IComparable<T>
```

## 2. Uno Game

Write a set of classes to model the Uno card game. Every `List<T>` property below needs to be initialized (e.g. in a constructor or as `= new();`) so a freshly-constructed object's collections are usable right away, rather than `null`.

### UnoGame

**Properties**

- `List<Player> Players`
- `List<Card> DrawStack`
- `List<Card> DiscardStack`
- `Color CurrentColor`

### Card

**Properties**

- `CardType Type`
- `Color Color`
- `int? Number`

`Wild` and `WildDraw4` cards haven't been assigned a real color yet — explicitly set `Color` to `Color.Wild` for these rather than leaving it at its default value (`Color.Red`, since `Red` is the first, zero-value member of the enum).

**Methods**

```csharp
public override string ToString()
```

- `"Red 10"`
- `"Blue Skip"`
- `"Wild"`
- `"WildDraw4"`
- `"Blue Draw2"`

```csharp
public static bool PlaysOn(Card card1, Card card2, Color? currentColor = null)
```

Does `card1` play on `card2`?

| card1 | card2 | Result |
|---|---|---|
| Red 10 | Blue 10 | `true` |
| Wild | Yellow 7 | `true` |
| Blue 5 | Blue 9 | `true` |
| Blue Skip | Red Skip | `true` |
| Blue Skip | Green 3 | `false` |
| Yellow 7 | Wild | depends on `currentColor` |

**Enumerations**

```csharp
enum CardType { Number, Wild, Draw2, WildDraw4, Skip, Reverse }
enum Color { Red, Yellow, Blue, Green, Wild }
```

### Player

**Properties**

- `string Name`
- `List<Card> Hand`

**Methods**

```csharp
public bool HasPlayableCard(Card card)
```

- Is there a card in the player's hand that will play on the given card?

```csharp
public Card GetFirstPlayableCard(Card card)
```

- Returns the first card in the player's hand that will play on the given card, or `null` if there are no playable cards in the hand.

```csharp
public Color MostCommonColor()
```

- Returns the most common color of the cards in the hand, excluding cards whose `Color` is `Color.Wild` (they don't have a real color until played).
- On a tie, return the color that comes first in this order: `Red, Yellow, Blue, Green`.

## 3. Vector Struct

Write a struct to model a 2D vector.

### Properties

- `double Magnitude` (read only) — length of the vector
- `double Direction` (read only) — angle, in degrees, of `Math.Atan2(Y, X)` converted to degrees (range `(-180, 180]`; e.g. `(-4, -4)` is `-135`, not `225`)
- `double X`
- `double Y`

### Constructor

```csharp
public Vector(double x, double y)
```

### Instance Methods

- `Vector Add(Vector v)`
- `Vector Subtract(Vector v)`
- `double Dot(Vector v)`
- `double AngleBetween(Vector v)` — the angle, in degrees, between this vector and `v`; always non-negative (range `0-180`), unlike the signed `Direction` above
- `Vector Multiply(double scalar)`
- `Vector Divide(double scalar)`
- `Vector Normalize()`
- `public override string ToString()` — e.g. `<3.45, -98.32>` or `<4, 3>`. Format `X`/`Y` with their default `double` formatting (don't force a fixed number of decimal places) so whole numbers print as `4`, not `4.0` or `4.00`.

### Static Methods

Each simply calls the matching instance method above:

- `static Vector Add(Vector v1, Vector v2)`
- `static Vector Subtract(Vector v1, Vector v2)`
- `static double Dot(Vector v1, Vector v2)`
- `static double AngleBetween(Vector v1, Vector v2)`
- `static Vector Multiply(Vector v, double scalar)`
- `static Vector Divide(Vector v, double scalar)`
- `static Vector Normalize(Vector v)`

### Operators

Overload these, each calling the matching static method above:

- `+` → `Add`
- `-` → `Subtract`
- `*` → two overloads: `Dot` (`Vector * Vector` → `double`) and `Multiply` (`Vector * double` → `Vector`)
- `/` → `Divide` (`Vector / double` → `Vector`)

This [online vector calculator](https://www.symbolab.com/solver/vector-angle-calculator/) may be helpful.

## 4. Prayer Class

Write classes to model a prayer for a prayer database.

### AuditableRecord (base class)

Record-keeping fields that any database record would need — pull them into a small base class and have `Prayer` inherit from it:

**Properties**

- `Guid Id`
- `DateTime CreatedAt`
- `DateTime UpdatedAt`

### Prayer : AuditableRecord

**Properties**

- `Title` (string)
- `Subtitle` (string)
- `Body` (string)
- `ScriptureReferences` (`List<ScriptureReference>`, each with `Book`, `Chapter`, `StartVerse`, `EndVerse`)
- `Author` (`First Name`, `Last Name`, `Email`)
- `Tags` (`List<Tag>`, each with `Name`, `Color`, `Icon`)
- `ImageUrl` (`Uri`)

### Instance Methods

```csharp
public override string ToString()
```

Format as a multi-line block, one field per line — e.g.:

```
A Prayer for Peace
by John Smith
John 14:27-31
Tags: Peace, Comfort, Anxiety
```

`Subtitle`, `ScriptureReferences`, `Author`, and `Tags` are all optional — omit a line entirely rather than printing it empty (e.g. no `by` line if there's no author, no `Tags:` line if the list is empty). When present, `Subtitle` prints as its own plain line directly under `Title`. When there's more than one scripture reference or tag, join them with `, `.
