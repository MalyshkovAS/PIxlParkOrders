using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

namespace WebApplication2
{
    public class PixlParkApi
    {
        private string publicKey
        {
            get
            {
                return "38cd79b5f2b2486d86f562e3c43034f8";
            }
        }
        private string privateKey
        {
            get
            {
                return "8e49ff607b1f46e1a5e8f6ad5d312a80";
            }
        }
        private string reqToken { get; set; }
        private string password { get; set; }
        private string accessToken { get; set; }

        string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
        private void GetReqToken()
        {
            WebClient webClient = new WebClient();
            string URL = "http://api.pixlpark.com/oauth/requesttoken";
            string response = webClient.DownloadString(URL);
            JObject jsonObj = JObject.Parse(response);
            reqToken = jsonObj.GetValue("RequestToken").ToString();

        }
        public void GetAccessToken()
        {
            GetReqToken();
            password = Hash(reqToken + privateKey);
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("oauth_token", reqToken);
            webClient.QueryString.Add("grant_type", "api");
            webClient.QueryString.Add("username", publicKey);
            webClient.QueryString.Add("password", password);
            string URL = "http://api.pixlpark.com/oauth/accesstoken";
            string response = webClient.DownloadString(URL);
            JObject jsonObj = JObject.Parse(response);
            accessToken = jsonObj.GetValue("AccessToken").ToString();
        }
        public Root GetOrderList()
        {

            WebClient webClient = new WebClient();
            webClient.QueryString.Add("oauth_token", accessToken);
            string URL = "http://api.pixlpark.com/orders";
            string response = webClient.DownloadString(URL);

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);
            return myDeserializedClass;
        }
    }
}
