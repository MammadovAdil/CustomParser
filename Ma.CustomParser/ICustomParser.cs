using HtmlAgilityPack;
using Ma.CustomParser.Models;
using System.Threading.Tasks;

namespace Ma.CustomParser
{
  /// <summary>Custom parser interface.</summary>
  public interface ICustomParser
  {
    /// <summary>Parser configurations.</summary>
    CustomParserConfiguration Configuration { get; }

    /// <summary>Parse HtmlNode to specified target model.</summary>
    /// <typeparam name="TTarget">Type of model to parse to.</typeparam>
    /// <param name="htmlNode">HtmlNode to parse.</param>
    /// <returns>Parsed target model.</returns>
    TTarget ParseHtml<TTarget>(HtmlNode htmlNode)
      where TTarget : class;

    /// <summary>Parse HtmlNode to specified target model asynchronously.</summary>
    /// <typeparam name="TTarget">Type of model to parse to.</typeparam>
    /// <param name="htmlNode">HtmlNode to parse.</param>
    /// <returns>Task to get parsed target model.</returns>
    Task<TTarget> ParseHtmlAsync<TTarget>(HtmlNode htmlNode)
      where TTarget : class;

    /// <summary>Parse Json string to specified target model.</summary>
    /// <typeparam name="TTarget">Type of model to parse to.</typeparam>
    /// <param name="json">Json string to parse.</param>
    /// <returns>Parsed target model.</returns>  
    TTarget ParseJson<TTarget>(string json)
      where TTarget : class;

    /// <summary>Parse Json string to specified target model asynchronously.</summary>
    /// <typeparam name="TTarget">Type of model to parse to.</typeparam>
    /// <param name="json">Json string to parse.</param>
    /// <returns>Task to get parsed target model.</returns> 
    Task<TTarget> ParseJsonAsync<TTarget>(string json)
      where TTarget : class;
  }
}
