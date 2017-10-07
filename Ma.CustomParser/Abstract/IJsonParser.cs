using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma.CustomParser.Abstract
{
    /// <summary>
    /// Base interface for Json parser.
    /// </summary>
    public interface IJsonParser
    {
    }

    /// <summary>
    /// Interface for Json parser.
    /// </summary>
    /// <typeparam name="TTarget">Target type to parse Json content to.</typeparam>
    public interface IJsonParser<TTarget> : IJsonParser
        where TTarget : class
    {
        /// <summary>
        /// Parse Json content to specified type.
        /// </summary>
        /// <param name="json">Json content to parse.</param>
        /// <returns>Parsed TTarget.</returns>
        TTarget Parse(string json);
    }
}
