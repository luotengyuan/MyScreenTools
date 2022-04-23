using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    public class TransResultItem2
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("src_tts")]
        public string SrcTts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dict")]
        public string Dict { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dst")]
        public string Dst { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dst_tts")]
        public string DstTts { get; set; }

        /// <summary>
        /// 清除
        /// </summary>
        [JsonProperty("src")]
        public string Src { get; set; }
    }
}