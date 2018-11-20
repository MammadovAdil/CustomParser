using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Ma.CustomParser.Abstract
{
  /// <summary>Base interface for html parser.</summary>
  public interface IHtmlParser
  {
  }

  /// <summary>Html parser interface.</summary>
  /// <typeparam name="TTarget">Target type to parse html content to.</typeparam>
  public interface IHtmlParser<TTarget> : IHtmlParser
      where TTarget : class
  {
    /// <summary>Parse htmlNode to TTarget.</summary>
    /// <param name="htmlNode">HTML node to parse.</param>
    /// <returns>Parsed TTarget.</returns>
    TTarget Parse(HtmlNode htmlNode);
    
  }
}
