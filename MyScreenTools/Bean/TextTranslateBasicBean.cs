using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    public class TextTranslateBasicBean
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result")]
        public Result Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("log_id")]
        public long LogId { get; set; }
    }
}