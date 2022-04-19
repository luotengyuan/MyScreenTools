using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace 屏幕工具.Bean
{
    class WordsResultItem
    {
        /// <summary>
        /// //图片文件路径
        /// </summary>
        [JsonProperty("words")]
        public string Words { get; set; }
    }
}
