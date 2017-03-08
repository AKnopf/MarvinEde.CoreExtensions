# **MarvinEde.CoreExtensions** adds handy functionality to many core types without adding any dependencies.

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
