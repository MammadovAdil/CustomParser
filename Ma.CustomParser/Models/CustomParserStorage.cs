using Ma.CustomParser.Abstract;
using System;
using System.Collections.Generic;

namespace Ma.CustomParser.Models
{
  /// <summary>
  /// Storage for custom parser configurations.
  /// </summary>
  internal class CustomParserStorage
  {
    private static Lazy<CustomParserStorage> lazy =
        new Lazy<CustomParserStorage>(() => new CustomParserStorage());

    public static CustomParserStorage Instance { get { return lazy.Value; } }

    public CustomParserStorage()
    {
      HtmlParserConfigurations = new Dictionary<Type, IHtmlParser>();
      JsonParserConfigurations = new Dictionary<Type, IJsonParser>();
    }

    internal Dictionary<Type, IHtmlParser> HtmlParserConfigurations { get; private set; }
    internal Dictionary<Type, IJsonParser> JsonParserConfigurations { get; private set; }
  }
}
