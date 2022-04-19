using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    class OcrBasicBean
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("words_result")]
        public List<WordsResultItem> WordsResult { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("words_result_num")]
        public int WordsResultNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("log_id")]
        public long LogId { get; set; }
    }
}
