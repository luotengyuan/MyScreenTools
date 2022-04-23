using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    public class WordResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("simple_means")]
        public SimpleMeans SimpleMeans { get; set; }
    }
}