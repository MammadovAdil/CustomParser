using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Ma.CustomParser.Abstract
{
  // <summary>Asynchronous Html parser interface.</summary>
  /// <typeparam name="TTarget">Target type to parse html content to.</typeparam>
  public interface IAsyncHtmlParser<TTarget> : IHtmlParser
    where TTarget : class
  {
    /// <summary>Parse htmlNode to TTarget asynchronously.</summary>
    /// <param name="htmlNode">HTML node to parse.</param>
    /// <returns>Task to get parsed TTarget.</returns>
    Task<TTarget> ParseAsync(HtmlNode htmlNode);
  }
}
