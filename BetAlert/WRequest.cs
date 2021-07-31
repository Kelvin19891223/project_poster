using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BetAlert
{
    internal class MyWebClient : WebClient
    {
        // Overrides the GetWebRequest method and sets keep alive to false
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest req = (HttpWebRequest)base.GetWebRequest(address);
            req.KeepAlive = false;
            return req;
        }
    }
    public class WRequest
    {

        private static readonly HttpClient client = new HttpClient();
        public static async System.Threading.Tasks.Task<string> post_response(string end_point, Object post_data, Dictionary<string, string> header = null, string data_type = "json")
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, end_point);
                if (header != null)
                {
                    foreach (var pair in header)
                    {
                        request.Headers.Add(pair.Key, pair.Value);
                    }
                }
                if (post_data != null)
                {
                    if (data_type.ToLower() == "json")
                    {
                        request.Content = new StringContent(post_data.ToString(), Encoding.UTF8, "application/json");//CONTENT-TYPE header
                    }
                    else
                    {
                        request.Content = new FormUrlEncodedContent((Dictionary<string, string>)post_data);
                    }
                }
                
                var response = await client.SendAsync(request);
                
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                MainApp.log_error($"WRequest: {end_point} \n {post_data.ToString()} \n {data_type}\n" + ex.Message + "\n" + ex.StackTrace);
                return "";
            }
        }
        public static async System.Threading.Tasks.Task<string> put_response(string end_point, Object put_data, Dictionary<string, string> header = null, string data_type = "json")
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, end_point);
                if (header != null)
                {
                    foreach (var pair in header)
                    {
                        request.Headers.Add(pair.Key, pair.Value);
                    }
                }
                if (put_data != null)
                {
                    if (data_type.ToLower() == "json")
                    {
                        request.Content = new StringContent(put_data.ToString(), Encoding.UTF8, "application/json");//CONTENT-TYPE header
                    }
                    else
                    {
                        request.Content = new FormUrlEncodedContent((Dictionary<string, string>)put_data);
                    }
                }
                var response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                MainApp.log_error($"WRequest: {end_point} \n {put_data.ToString()} \n {data_type}\n" + ex.Message + "\n" + ex.StackTrace);
                return "";
            }
        }
        public static async System.Threading.Tasks.Task<string> get_response(string end_point, Dictionary<string, string> header = null, string param = "", Object body = null, string data_type = "json")
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(end_point),
                };
                if (header != null)
                {
                    foreach (var pair in header)
                    {
                        request.Headers.Add(pair.Key, pair.Value);
                    }
                }
                if (param != "")
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", param);
                }

                if (body != null)
                {
                    if (data_type.ToLower() == "json")
                    {
                        request.Content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");//CONTENT-TYPE header
                    }
                    else
                    {
                        request.Content = new FormUrlEncodedContent((Dictionary<string, string>)body);
                    }
                }

                var response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                MainApp.log_error($"WRequest: {end_point} \n Token: {param}\n" + ex.Message + "\n" + ex.StackTrace);
                return "";
            }
        }
     
        public static async System.Threading.Tasks.Task<string> post_authentication_response(string end_point, string username, string password, Object post_data, Dictionary<string, string> header = null, string data_type = "json")
        {
            try
            {
                HttpClient pclient = new HttpClient();
                var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
                pclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, end_point);
                if (header != null)
                {
                    foreach (var pair in header)
                    {
                        request.Headers.Add(pair.Key, pair.Value);
                    }
                }
                if (post_data != null)
                {
                    if (data_type.ToLower() == "json")
                    {
                        request.Content = new StringContent(post_data.ToString(), Encoding.UTF8, "application/json");//CONTENT-TYPE header
                    }
                    else
                    {
                        request.Content = new FormUrlEncodedContent((Dictionary<string, string>)post_data);
                    }
                }

                var response = await pclient.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                MainApp.log_error($"WRequest: {end_point} \n {post_data.ToString()} \n {data_type}\n" + ex.Message + "\n" + ex.StackTrace);
                return "";
            }
        }
    }
}
