using Abp.Application.Services;
using Abp.Logging;
using Abp.Reflection.Extensions;
using JPGZService.Configuration;
using JPGZService.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JPGZService.CommonUtils
{
    public class HttpClientHelper
    {       
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponse(string url, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        public static string RestfulGet(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            // Get response
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream
                StreamReader reader = new StreamReader(response.GetResponseStream());
                // Console application output
                return reader.ReadToEnd();
            }
        }

        public static T GetResponse<T>(string url)
           where T : class, new()
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData">post数据Byte</param>
        /// <returns></returns>
        public static string PostResponse(string url, Byte[] postData, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //MultipartEntity reqEntity = new MultipartEntity();


            HttpContent httpContent = new ByteArrayContent(postData);

            //  httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // httpContent.Headers.ContentType.CharSet = "utf-8";

            HttpClient httpClient = new HttpClient();
            //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData">post数据</param>
        /// <returns></returns>
        public static string PostResponse(string url, string postData, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Method", "Post");
            httpClient.DefaultRequestHeaders.Add("UserAgent",
              "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("KeepAlive", "false");

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            statusCode = response.StatusCode.ToString();
            LogHelper.Logger.Info("statusCode" + statusCode);

            LogHelper.Logger.Info("Result" + response.Content.ReadAsStringAsync().Result);
            while (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        private static object FormUrlEncodedContent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发起post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">url</param>
        /// <param name="postData">post数据</param>
        /// <returns></returns>
        public static T PostResponse<T>(string url, string postData)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();

            T result = default(T);

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;
                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }


        /// <summary>
        /// 反序列化Xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlString)
            where T : class, new()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(xmlString))
                {
                    return (T)ser.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("XmlDeserialize发生异常：xmlString:" + xmlString + "异常信息：" + ex.Message);
            }

        }

        public static string PostResponse(string url, string postData, string token, string appId, string serviceURL, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";

            httpContent.Headers.Add("token", token);
            httpContent.Headers.Add("appId", appId);
            httpContent.Headers.Add("serviceURL", serviceURL);


            HttpClient httpClient = new HttpClient();
            //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }

            return null;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="form">post数据Byte</param>
        /// <returns></returns>
        public static T PostResponse<T>(string url, Form form)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            using (var client = new HttpClient())
            {
                using (var content =
                    new MultipartFormDataContent())
                {
                    try
                    {
                        var fileContent = new ByteArrayContent(form.CommitDataBytes);
                        content.Add(fileContent, "file", form.FileName);

                        var result = client.PostAsync(form.CommitUrl, content).Result;
                        Task<string> t = result.Content.ReadAsStringAsync();
                        string s = t.Result;
                        return JsonConvert.DeserializeObject<T>(s);
                    }
                    catch (Exception e)
                    {
                        LogHelper.Logger.Info("请求" + e.Message);
                        throw;
                    }
                }
            }
            ////MultipartEntity reqEntity = new MultipartEntity();


            //HttpContent httpContent = new ByteArrayContent(form.CommitDataBytes);

            ////  httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //// httpContent.Headers.ContentType.CharSet = "utf-8";

            //HttpClient httpClient = new HttpClient();
            ////httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");

            //HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            //statusCode = response.StatusCode.ToString();
            //if (response.IsSuccessStatusCode)
            //{
            //    string result = response.Content.ReadAsStringAsync().Result;
            //    return result;
            //}

            //return null;
        }
        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="postData"></param>        
        /// <returns></returns>
        public static string HttpPostRequst(string url, string postData, string ActionUrl)
        {
            byte[] bs = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest result = (HttpWebRequest)WebRequest.Create(url + ActionUrl);
            result.ContentType = "application/json";
            result.ContentLength = bs.Length;
            result.Method = "POST";

            using (Stream reqStream = result.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
            }
            using (WebResponse wr = result.GetResponse())
            {
                string reader = new StreamReader(wr.GetResponseStream(),
                    Encoding.UTF8).ReadToEnd();
                return reader;
            }
        }
        /// <summary>
        /// 接口保存图片
        /// </summary>
        /// <param name="pic_width"></param>
        /// <param name="pic_height"></param>
        /// <param name="bitMapData"></param>
        /// <param name="saveType"></param>
        /// <returns></returns>
        public static string saveLearningImage(int pic_width, int pic_height, string bitMapData, int saveType = 4)
        {
            Assembly entry = Assembly.GetEntryAssembly();
            //找到当前执行文件所在路径
            string dir = Path.GetDirectoryName(entry.Location);
            var configuration = AppConfigurations.Get(dir);
            string url = configuration.GetSection("SaveImageUrl").Value;            
            var requstData = new
            {
                pic_width = pic_width,
                pic_height = pic_height,                
                bitMapData = bitMapData,
                saveType = saveType
            };            
            var img = HttpPostRequst(url, JsonConvert.SerializeObject(requstData), "");
            return img.Trim('"');
        }
    }
}
