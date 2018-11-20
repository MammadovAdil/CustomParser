using Ma.CustomParser.Abstract;
using System;
using System.Collections.Generic;

namespace Ma.CustomParser.Models
{
  /// <summary>Configurations for custom parser.</summary>
  public class CustomParserConfiguration
  {
    /// <summary>Add HTML parser to configurations.</summary>
    /// <exception cref="ArgumentNullException">
    /// When htmlParser is null.
    /// </exception>
    /// <typeparam name="TTarget">Type of target.</typeparam>
    /// <param name="htmlParser">Instance of HTML parser.</param>
    public void AddParser<TTarget>(IHtmlParser<TTarget> htmlParser)
        where TTarget : class
    {
      if (htmlParser == null)
        throw new ArgumentNullException(nameof(htmlParser));

      var key = typeof(TTarget);
      CustomParserStorage.Instance.HtmlParserConfigurations[key] = htmlParser;
    }

    /// <summary>Add HTML parser to configurations.</summary>
    /// <exception cref="ArgumentNullException">
    /// When htmlParser is null.
    /// </exception>
    /// <typeparam name="TTarget">Type of target.</typeparam>
    /// <param name="htmlParser">Instance of asynchronous HTML parser.</param>
    public void AddParser<TTarget>(IAsyncHtmlParser<TTarget> htmlParser)
        where TTarget : class
    {
      if (htmlParser == null)
        throw new ArgumentNullException(nameof(htmlParser));

      var key = typeof(TTarget);
      CustomParserStorage.Instance.HtmlParserConfigurations[key] = htmlParser;
    }

    /// <summary>Add JSON parser to configurations.</summary>
    /// <exception cref="ArgumentNullException">
    /// When jsonParser is null.
    /// </exception>
    /// <typeparam name="TTarget">Type of target.</typeparam>
    /// <param name="jsonParser">Instance of Json parser.</param>
    public void AddParser<TTarget>(IJsonParser<TTarget> jsonParser)
        where TTarget : class
    {
      if (jsonParser == null)
        throw new ArgumentNullException(nameof(jsonParser));

      var key = typeof(TTarget);
      CustomParserStorage.Instance.JsonParserConfigurations[key] = jsonParser;
    }

    /// <summary>Add JSON parser to configurations.</summary>
    /// <exception cref="ArgumentNullException">
    /// When jsonParser is null.
    /// </exception>
    /// <typeparam name="TTarget">Type of target.</typeparam>
    /// <param name="jsonParser">Instance of asynchronous Json parser.</param>
    public void AddParser<TTarget>(IAsyncJsonParser<TTarget> jsonParser)
        where TTarget : class
    {
      if (jsonParser == null)
        throw new ArgumentNullException(nameof(jsonParser));

      var key = typeof(TTarget);
      CustomParserStorage.Instance.JsonParserConfigurations[key] = jsonParser;
    }


    /// <summary>Get HTML parser according to target type.</summary>
    /// <typeparam name="TTarget">Type of parse target.</typeparam>
    /// <returns>HTML parser.</returns>
    public IHtmlParser<TTarget> GetHtmlParser<TTarget>()
        where TTarget : class
    {
      var storage = CustomParserStorage.Instance.HtmlParserConfigurations;
      Type key = typeof(TTarget);

      CheckParserStorage(storage.Keys, key);

      var parser = storage[key] as IHtmlParser<TTarget>;
      return parser;
    }

    /// <summary>Get asynchronous HTML parser according to target type.</summary>
    /// <typeparam name="TTarget">Type of parse target.</typeparam>
    /// <returns>Asynchronous HTML parser.</returns>
    public IAsyncHtmlParser<TTarget> GetAsyncHtmlParser<TTarget>()
        where TTarget : class
    {
      var storage = CustomParserStorage.Instance.HtmlParserConfigurations;
      Type key = typeof(TTarget);

      CheckParserStorage(storage.Keys, key);

      var parser = storage[key] as IAsyncHtmlParser<TTarget>;
      return parser;
    }

    /// <summary>Get Json parser according to target type.</summary>
    /// <typeparam name="TTarget">Type of parse target.</typeparam>
    /// <returns>Json parser.</returns>
    public IJsonParser<TTarget> GetJsonParser<TTarget>()
        where TTarget : class
    {
      var storage = CustomParserStorage.Instance.JsonParserConfigurations;
      Type key = typeof(TTarget);

      CheckParserStorage(storage.Keys, key);

      var parser = storage[key] as IJsonParser<TTarget>;
      return parser;
    }

    /// <summary>Get asynchronous Json parser according to target type.</summary>
    /// <typeparam name="TTarget">Type of parse target.</typeparam>
    /// <returns>Asynchronous Json parser.</returns>
    public IAsyncJsonParser<TTarget> GetAsyncJsonParser<TTarget>()
        where TTarget : class
    {
      var storage = CustomParserStorage.Instance.JsonParserConfigurations;
      Type key = typeof(TTarget);

      CheckParserStorage(storage.Keys, key);

      var parser = storage[key] as IAsyncJsonParser<TTarget>;
      return parser;
    }

    /// <summary>Check if storage contains parser for type.</summary>
    /// <param name="parserKeyCollection">Collection of keys for parser collection.</param>
    /// <param name="parserKey">Type to check for in storage.</param>
    private void CheckParserStorage(ICollection<Type> parserKeyCollection, Type parserKey)
    {
      if (!parserKeyCollection.Contains(parserKey))
        throw new InvalidOperationException(string.Format(
            "Parser storage does not contain parser for specified type ({0}).",
            parserKey.Name));
    }
  }
}
