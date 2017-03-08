MarvinEde.CoreExtensions adds handy functionality to many core types without adding any dependencies.


IEnumerable and IQueryable

TODO


IDictionary#Fetch
Tries to get a value from a dictionary and falls back on a default if it is not found.
You can call it in three ways:

1) Without a default. In this case the default will the default if the value type.

var myDictionary = new Dictionary<string, double>(){{"Test", 47.11}};

myDictionary.Fetch("Test"); // 47.11
myDictionary.Fetch("Oops"); // 0.0

2) With a given default

myDictionary.Fetch("Test", -1); // 47.11
myDictionary.Fetch("Oops", -1); // -1


3) With a lazy default. This will only be evaluated if the the key was not found. This is handy for expensive calculations.

myDictionary.Fetch("Test", () => CalculateEveryDecimalPlaceOfPi()) // 47.11 // The expensive method will not be called
myDictionary.Fetch("Oops", () => CalculateEveryDecimalPlaceOfPi()) // 3.14159265... // The expensive method was called