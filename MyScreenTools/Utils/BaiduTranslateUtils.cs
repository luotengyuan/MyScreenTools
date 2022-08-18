using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace 屏幕工具
{
    class BaiduTranslateUtils
    {
        // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
        // 返回token示例
        public static String TOKEN = "24.adda70c11b9786206253ddb70affdc46.2592000.1493524354.282335-1234567";

        // 百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务
        private static String clientId = Properties.Settings.Default.TranslateApiKey;
        // 百度云中开通对应服务应用的 Secret Key
        private static String clientSecret = Properties.Settings.Default.TranslateSecretKey;

        public static string GetAccessToken()
        {
            if (clientId == null || clientSecret == null)
            {
                return null;
            }
            try
            {
                String authHost = "https://aip.baidubce.com/oauth/2.0/token";
                HttpClient client = new HttpClient();
                List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
                paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
                paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

                HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 百度云文本翻译通用版
        /// </summary>
        /// <param name="token"></param>
        /// <param name="text"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="termIds"></param>
        /// <returns></returns>
        public static string TextTranslateBasic(string token, string text, string from, string to, string termIds)
        {
            if (token == null || text == null || from == null || to == null)
            {
                return null;
            }
            try
            {
                String authHost = "https://aip.baidubce.com/rpc/2.0/mt/texttrans/v1?access_token=" + token;

                JObject obj = new JObject();
                obj.Add("q", text);
                obj.Add("from", from);
                obj.Add("to", to);
                obj.Add("termIds", termIds == null ? "" : termIds);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(authHost);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, authHost);
                request.Content = new StringContent(obj.ToString(),
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                HttpResponseMessage response = client.SendAsync(request).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 百度云文本翻译词典版
        /// </summary>
        /// <param name="token"></param>
        /// <param name="text"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="termIds"></param>
        /// <returns></returns>
        public static string TextTranslateDictionary(string token, string text, string from, string to, string termIds)
        {
            if (token == null || text == null || from == null || to == null)
            {
                return null;
            }
            try
            {
                String authHost = "https://aip.baidubce.com/rpc/2.0/mt/texttrans-with-dict/v1?access_token=" + token;

                JObject obj = new JObject();
                obj.Add("q", text);
                obj.Add("from", from);
                obj.Add("to", to);
                obj.Add("termIds", termIds == null ? "" : termIds);

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(authHost);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, authHost);
                request.Content = new StringContent(obj.ToString(),
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                HttpResponseMessage response = client.SendAsync(request).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
