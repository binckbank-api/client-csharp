namespace ClientCsharp
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    ///     The news message
    /// </summary>
    [Obfuscation(Feature = "preserve-name-binding")]
    [Obfuscation(Feature = "preserve-identity")]
    public class NewsMessageModel
    {
        /// <summary>
        ///     The culture of the message
        /// </summary>
        [JsonProperty(PropertyName = "cul", Required = Required.Always)]
        public string Culture { get; set; }

        /// <summary>
        ///     Headline of the message
        /// </summary>
        [JsonProperty(PropertyName = "head", Required = Required.Always)]
        public string Headline { get; set; }

        /// <summary>
        ///     [Optional] Body of the message
        /// </summary>
        [JsonProperty(PropertyName = "body", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Body { get; set; }

        /// <summary>
        ///     Indication whether the body is in HTML format
        /// </summary>
        [JsonProperty(PropertyName = "fmt", Required = Required.Always)]
        public string Format { get; set; }

        /// <summary>
        ///     Date and time the publisher published the message
        /// </summary>
        [JsonProperty(PropertyName = "dt", Required = Required.Always)]
        public DateTime PublishedDateTime { get; set; }

        /// <summary>
        ///     [Optional] The instruments for which this news message contains news (if any)
        /// </summary>
        [JsonProperty(PropertyName = "iids", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Instruments { get; set; }
    }
}
