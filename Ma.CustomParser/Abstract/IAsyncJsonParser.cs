using System.Threading.Tasks;

namespace Ma.CustomParser.Abstract
{
  /// <summary>Interface for asynchronous Json parser.</summary>
  /// <typeparam name="TTarget">Target type to parse Json content to.</typeparam>
  public interface IAsyncJsonParser<TTarget> : IJsonParser
    where TTarget : class
  {
    /// <summary>Parse Json content to specified type asynchronously.</summary>
    /// <param name="json">Json content to parse.</param>
    /// <returns>Task to get pasrsed TTarget.</returns>
    Task<TTarget> ParseAsync(string json);
  }
}
