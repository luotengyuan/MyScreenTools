using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    public class DictionaryMeansBean
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("word_result")]
        public WordResult WordResult { get; set; }
    }
}