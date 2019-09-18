namespace ClientCsharp
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     Quote list
    /// </summary>
    [Obfuscation(Feature = "preserve-name-binding")]
    [Obfuscation(Feature = "preserve-identity")]
    public class QuoteListModel
    {
        /// <summary>
        ///     The instrument id of the message
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string InstrumentId { get; set; }

        /// <summary>
        ///     The level of quotes within the message
        /// </summary>
        [JsonProperty(PropertyName = "lvl", Required = Required.Always)]
        public string SubscriptionLevel { get; set; }

        /// <summary>
        ///     The new quotes for this instrument
        /// </summary>
        [JsonProperty(PropertyName = "qt", Required = Required.Always)]
        public IEnumerable<QuoteModel> Quotes { get; set; }

        /// <summary>
        ///     The UTC date and time the message is obtained from the broadcast
        /// </summary>
        [JsonProperty(PropertyName = "sdt", Required = Required.Always)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime SubmissionDateTime { get; set; }
    }

    /// <summary>
    ///     The new quotes for this instrument
    /// </summary>
    public class QuoteModel
    {
        /// <summary>
        ///     How to display the quote, first occurence, or subsequent?
        /// </summary>
        [JsonProperty(PropertyName = "msg", Required = Required.Always)]
        public string MessageType { get; set; }

        /// <summary>
        ///     Quote type
        /// </summary>
        [JsonProperty(PropertyName = "typ", Required = Required.Always)]
        public string QuoteType { get; set; }

        /// <summary>
        ///     [Optional] Price
        /// </summary>
        [JsonProperty(PropertyName = "prc", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Price { get; set; }

        /// <summary>
        ///     [Optional] Volume
        /// </summary>
        [JsonProperty(PropertyName = "vol", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? Volume { get; set; }

        /// <summary>
        ///     [Optional] Order size
        /// </summary>
        [JsonProperty(PropertyName = "ord", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderCount { get; set; }

        /// <summary>
        ///     [Optional] Quote date time
        /// </summary>
        [JsonProperty(PropertyName = "dt", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? QuoteDateTime { get; set; }

        /// <summary>
        ///     [Optional] Tags mean (C)ancel, (M)arket, etc.
        /// </summary>
        [JsonProperty(PropertyName = "tags", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Tags { get; set; }
    }
}