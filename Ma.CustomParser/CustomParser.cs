using HtmlAgilityPack;
using Ma.CustomParser.Abstract;
using Ma.CustomParser.Models;
using System;
using System.Threading.Tasks;

namespace Ma.CustomParser
{
  /// <inheritdoc />
  public class CustomParser : ICustomParser
  {
    /// <summary>Parser configurations.</summary>
    public CustomParserConfiguration Configuration { get; private set; }

    /// <summary>Initialize custom parser.</summary>
    public CustomParser()
    {
      Configuration = new CustomParserConfiguration();
    }

    /// <inheritdoc />
    public TTarget ParseHtml<TTarget>(HtmlNode htmlNode)
        where TTarget : class
    {
      if (htmlNode == null)
        throw new ArgumentNullException(nameof(htmlNode));

      var htmlParser = Configuration.GetHtmlParser<TTarget>();
      return htmlParser != null
        ? htmlParser.Parse(htmlNode)
        : ParseSynchWithAsncHtmlParser<TTarget>(htmlNode);
    }

    private TTarget ParseSynchWithAsncHtmlParser<TTarget>(HtmlNode htmlNode)
      where TTarget : class
    {
      var asyncHtmlParser = Configuration.GetAsyncHtmlParser<TTarget>();
      return asyncHtmlParser?.ParseAsync(htmlNode).Result;
    }

    /// <inheritdoc />
    public Task<TTarget> ParseHtmlAsync<TTarget>(HtmlNode htmlNode)
        where TTarget : class
    {
      if (htmlNode == null)
        throw new ArgumentNullException(nameof(htmlNode));

      var asyncHtmlParser = Configuration.GetAsyncHtmlParser<TTarget>();
      return asyncHtmlParser != null
        ? asyncHtmlParser.ParseAsync(htmlNode)
        : ParseAsyncWithHtmlParser<TTarget>(htmlNode);
    }

    private Task<TTarget> ParseAsyncWithHtmlParser<TTarget>(HtmlNode htmlNode)
      where TTarget : class
    {
      var htmlParser = Configuration.GetHtmlParser<TTarget>();
      return Task.Run(() => htmlParser.Parse(htmlNode));
    }

    /// <inheritdoc />
    public TTarget ParseJson<TTarget>(string json)
        where TTarget : class
    {
      if (json == null)
        throw new ArgumentNullException(nameof(json));

      var jsonParser = Configuration.GetJsonParser<TTarget>();
      return jsonParser != null 
        ? jsonParser.Parse(json) 
        : ParseSynchWithAsncJsonParser<TTarget>(json);
    }

    private TTarget ParseSynchWithAsncJsonParser<TTarget>(string json)
      where TTarget : class
    {
      var asyncJsonParser = Configuration.GetAsyncJsonParser<TTarget>();
      return asyncJsonParser?.ParseAsync(json).Result;
    }


    /// <inheritdoc />
    public Task<TTarget> ParseJsonAsync<TTarget>(string json)
        where TTarget : class
    {
      if (json == null)
        throw new ArgumentNullException(nameof(json));

      var asyncJsonParser = Configuration.GetAsyncJsonParser<TTarget>();
      return asyncJsonParser != null
        ? asyncJsonParser.ParseAsync(json)
        : ParseAsyncWithJsonParser<TTarget>(json);
    }

    private Task<TTarget> ParseAsyncWithJsonParser<TTarget>(string json)
      where TTarget : class
    {
      var jsonParser = Configuration.GetJsonParser<TTarget>();
      return Task.Run(() => jsonParser.Parse(json));
    }
  }
}
