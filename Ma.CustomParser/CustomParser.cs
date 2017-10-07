using HtmlAgilityPack;
using Ma.CustomParser.Abstract;
using Ma.CustomParser.Models;
using System;

namespace Ma.CustomParser
{
    /// <summary>
    /// Custom parser to parse content to specified type.
    /// </summary>
    public static class CustomParser
    {
        /// <summary>
        /// Parser configurations.
        /// </summary>
        public static CustomParserConfiguration Configuration { get; set; }

        static CustomParser()
        {
            Configuration = new CustomParserConfiguration();
        }

        /// <summary>
        /// Parse HtmlNode to specified target model.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// When htmlNode is null.
        /// </exception>
        /// <typeparam name="TTarget">Type of model to parse to.</typeparam>
        /// <param name="htmlNode">HtmlNode to parse.</param>
        /// <returns>Parsed target model.</returns>
        public static TTarget ParseHtml<TTarget>(HtmlNode htmlNode)
            where TTarget : class
        {
            if (htmlNode == null)
                throw new ArgumentNullException(nameof(htmlNode));

            // Get parser from configuration.
            IHtmlParser<TTarget> htmlParser = Configuration.GetHtmlParser<TTarget>();
            TTarget model = htmlParser.Parse(htmlNode);
            return model;
        }

        /// <summary>
        /// Parse Json string to specified target model.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// When json is null.
        /// </exception>
        /// <typeparam name="TTarget">Type of model to parse to.</typeparam>
        /// <param name="json">Json string to parse.</param>
        /// <returns>Parsed target model.</returns>  
        public static TTarget ParseJson<TTarget>(string json)
            where TTarget : class
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));

            // Get parser from configuration.
            IJsonParser<TTarget> htmlParser = Configuration.GetJsonParser<TTarget>();
            TTarget model = htmlParser.Parse(json);
            return model;
        }
    }
}
