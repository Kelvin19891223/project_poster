using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetAlert
{
    class API_Con
    {
        public async Task<bool> login(String user, String passwd)
        {
            try
            {
                string endp = "https://identitysso.betfair.com/api/login";
                string data = "{" +
                        $"\"username\":\"{user}\"," +
                        $"\"password\":\"{passwd}\"" +
                               "}";
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("X-Application", "9ANo4w4ohUy2JXGA");
                header.Add("Content-Type", "application/x-www-form-urlencoded");
                string resp = await WRequest.post_response(endp, data, header);


                var json = JObject.Parse(resp);                
                return true;
            }
            catch (Exception ex)
            {
                MainApp.log_error("Login failed." + ex.Message);
            }
            return false;
        }

    }
}
