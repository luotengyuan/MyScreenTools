using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    public class TransResultItem
    {
        /// <summary>
        /// 你好，纽约
        /// </summary>
        [JsonProperty("dst")]
        public string Dst { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("src")]
        public string Src { get; set; }
    }
}