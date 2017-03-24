# **MarvinEde.CoreExtensions** adds handy functionality to many core types without adding any dependencies.

## Table of Contents
<!-- TOC depthFrom:2 depthTo:6 withLinks:1 updateOnSave:1 orderedList:1 -->

1. [Table of Contents](#table-of-contents)
2. [Concept of presence and blankness](#concept-of-presence-and-blankness)
3. [object](#object)
	1. [IsIn(enumerable)](#isinenumerable)
4. [IDictionary](#idictionary)
	1. [Fetch(key)](#fetchkey)
5. [Object](#object)
	1. [Swap(a, b)](#swapa-b)
6. [List](#list)
	1. [EachSlice](#eachslice)
	2. [EachColumn](#eachcolumn)
7. [IEnumerable](#ienumerable)
	1. [Sum()](#sum)
8. [Exception](#exception)
	1. [GetInnermostException()](#getinnermostexception)
	2. [GetFirstInnerException<T>()](#getfirstinnerexceptiont)
	3. [GetLastInnerException<T>()](#getlastinnerexceptiont)
9. [Stream](#stream)
	1. [ReadBytes](#readbytes)

<!-- /TOC -->
## Concept of presence and blankness
To many types such as string, or IEnumerable, the methods `IsPresent()` and `IsBlank()` are added. Depending on the type you ask, this can mean different things: A collection is blank if it empty, a string is empty if it is empty or only contains white space characters or if it contains an empty JSON. For any particular object, the two methods never return the same result.

## object

### IsIn(enumerable)

Asks an object whether it is in an enumerable or not.
You can now write `myCollection.Contains(myObject)` as `myObject.IsIn(myCollection)`


## IDictionary

### Fetch(key)
Tries to get a value from a dictionary and falls back on a default if it is not found.
You can call it in three ways:

1. Without a default. In this case the default will the default if the value type.

  ```csharp
  var myDictionary = new Dictionary<string, double>(){{"Test", 47.11}};

  myDictionary.Fetch("Test"); // 47.11
  myDictionary.Fetch("Oops"); // 0.0
  ```

2. With a given default
  ```csharp
  myDictionary.Fetch("Test", -1); // 47.11
  myDictionary.Fetch("Oops", -1); // -1
  ```

3. With a lazy default. This will only be evaluated if the the key was not found. This is handy for expensive calculations.
  ```csharp
  myDictionary.Fetch("Test", () => CalculateEveryDecimalPlaceOfPi()) // 47.11 // The expensive method will not be called
  myDictionary.Fetch("Oops", () => CalculateEveryDecimalPlaceOfPi()) // 3.14159265... // The expensive method was called
  ```

## Object

### Swap(a, b)
Swaps two references, handling the temporary variable for you
```csharp
string a = "a";
string b = "b";
this.Swap(ref a, ref b);
// a == "b"
// b == "a"
```

## List

### EachSlice
Iterates over a list in pairs, that do not overlap. It has one overload with a function (Select) and one with an action (foreach).
```csharp
List<int> list = new List<int>() {1, 2, 3, 4};
list.EachSlice() // [Tuple[1,2], Tuple[3,4]]
```

### EachColumn
Iterates over a list in pairs, that do overlap. It has one overload with a function (Select) and one with an action (foreach).
```csharp
List<int> list = new List<int>() {1, 2, 3, 4};
list.EachColumn() // [Tuple[1,2], Tuple[2,3], Tuple[3,4]]
```

## IEnumerable

### Sum()
Adds up all elements. Works for `int, long, short, double, float, BigInteger`

## Exception

### GetInnermostException()
In case there are deeply nested exceptions, this methods returns the innermost exception
```csharp
using SysEx = System.Exception;
var nestedException = new SysEx("1", new SysEx("2", new SysEx("3")));
nestedException.GetInnermostException().Message // "3"
```

### GetFirstInnerException<T>()
Looks for the first exception, that is T in the nested exceptions. Returns null if none was found.
```csharp
using SysEx = System.Exception;
var differentTypeException = new System.Exception("System.Exception", new AException("a1", new BException("b", new AException("a2"))));
differentTypeException.GetFirstInnerException<AException>().Message // "a1"
differentTypeException.GetFirstInnerException<BException>().Message // "b1"
```


### GetLastInnerException<T>()
Works just like [GetFirstInnerException<T>()](#getfirstinnerexceptiont), but looks for the last exception that is T.
```csharp
using SysEx = System.Exception;
var differentTypeException = new System.Exception("System.Exception", new AException("a1", new BException("b", new AException("a2"))));
differentTypeException.GetLastInnerException<AException>().Message // "a2"
```

## Stream
### ReadBytes
Reads the whole Stream into a byte array.
```csharp
byte[] bytes;
using(var file = System.IO.File.OpenRead("path/to/file"))
{
    bytes = file.ReadBytes();
}
```
