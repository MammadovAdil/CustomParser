# Ma.CustomParser

Custom parsers to help to parse HTML and JSON content. 

Implement your HTML parser classes from `IHtmlParser<>` or `IAsyncHtmlParser<>` interface.
Implement your Json parser classes from `IJsonParser<>` or `IAsyncJsonParser<>` interface.

Add following method to the project where you have html or json parser classes,
and call it when program starts to register all parsers:

```cs
/// <summary>
/// Register all custom Json and HTML parser classes.
/// </summary>
public static void RegisterCustomParsers(ICustomParser parser)
{
    var customParserInterfaceTypes = new List<Type>
    {
        typeof(IHtmlParser<>),
        typeof(IAsyncHtmlParser<>),
        typeof(IJsonParser<>),
        typeof(IAsyncJsonParser<>)
    };

    // Get all custom parser which implement above interfaces.
    var itemParserTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(m => m.GetInterfaces().Any(i => i.IsGenericType
            && customParserInterfaceTypes.Contains(i.GetGenericTypeDefinition())));

    foreach (Type itemParserType in itemParserTypes)
    {
    dynamic itemParser = Activator.CreateInstance(itemParserType);
    parser.Configuration.AddParser(itemParser);
    }
}
```