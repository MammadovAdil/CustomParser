# Ma.CustomParser

Custom parsers to help to parse HTML and JSON content. 

Implement your HTML parser classes from `IHtmlParser<>` interface.
Implement your Json parser classes from `IJsonParser<>` interface.

Add following method to the project where you have html or json parser classes,
and call it when program starts to register all parsers:

```cs
/// <summary>
/// Register all custom Json and HTML parser classes.
/// </summary>
public static void RegisterCustomParsers()
{
	List<Type> customParserInterfaceTypes = new List<Type>
	{
		typeof(IHtmlParser<>),
		typeof(IJsonParser<>)
	};

	// Get all custom parser which implement above interfaces.
    var customParserTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(m => m.GetInterfaces().Any(i => i.IsGenericType
            && customParserInterfaceTypes.Contains(i.GetGenericTypeDefinition())));

    foreach (Type customParserType in customParserTypes)
    {
        dynamic customParser = Activator.CreateInstance(customParserType);
        CustomParser.Configuration.AddParser(customParser);
    }
}
```