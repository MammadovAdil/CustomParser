using Ma.CustomParser.Abstract;
using System;

namespace Ma.CustomParser.Models
{
    /// <summary>
    /// Configurations for custom parser.
    /// </summary>
    public class CustomParserConfiguration
    {
        /// <summary>
        /// Add HTML parser to configurations.
        /// </summary>
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

            Type key = typeof(TTarget);
            CustomParserStorage.Instance.HtmlParserConfigurations[key] = htmlParser;
        }

        /// <summary>
        /// Add JSON parser to configurations.
        /// </summary>
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

            Type key = typeof(TTarget);
            CustomParserStorage.Instance.JsonParserConfigurations[key] = jsonParser;
        }


        /// <summary>
        /// Get HTML parser according to target type.
        /// </summary>
        /// <typeparam name="TTarget">Type of parse target.</typeparam>
        /// <returns>HTML parser.</returns>
        public IHtmlParser<TTarget> GetHtmlParser<TTarget>()
            where TTarget : class
        {
            var storage = CustomParserStorage.Instance.HtmlParserConfigurations;
            Type key = typeof(TTarget);

            if (!storage.ContainsKey(key))
                throw new InvalidOperationException(string.Format(
                    "HTML parser storage does not contain parser for specified type ({0}).",
                    key.Name));

            IHtmlParser<TTarget> parser = storage[key] as IHtmlParser<TTarget>;
            return parser;
        }

        /// <summary>
        /// Get Json parser according to target type.
        /// </summary>
        /// <typeparam name="TTarget">Type of parse target.</typeparam>
        /// <returns>Json parser.</returns>
        public IJsonParser<TTarget> GetJsonParser<TTarget>()
            where TTarget : class
        {
            var storage = CustomParserStorage.Instance.JsonParserConfigurations;
            Type key = typeof(TTarget);

            if (!storage.ContainsKey(key))
                throw new InvalidOperationException(string.Format(
                    "JSON parser storage does not contain parser for specified type ({0}).",
                    key.Name));

            IJsonParser<TTarget> parser = storage[key] as IJsonParser<TTarget>;
            return parser;
        }
    }
}
