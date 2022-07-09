using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.xUnitTest.Helper
{
    public class Utils
    {
        private static string TestDataFolderLocation => Path.GetFullPath(@"../../../TestData/");
        public async static Task<RestResponse> GetResponseAsync(RestRequest request)
        {
            return await new RestClient().ExecuteAsync(request);
        }

        internal static RestRequest CreateGetRequest(string url)
        {
            var request = new RestRequest(url, Method.Get);
            request.AddHeaders(new Dictionary<string, string>
            {
                {"Accept","application/json" },
                {"Content-Type", "application/json" }
            });
            return request;
        }

        internal static RestRequest CreatePostRequest<T>(string url, T user) where T:class
        {
            var request = new RestRequest(url, Method.Post);
            request.AddHeaders(new Dictionary<string, string>
            {
                {"Accept","application/json" },
                {"Content-Type", "application/json" }
            });
            request.AddBody(user);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public static T ParseJson<T>(string file)
        {
            file = string.Format($"{TestDataFolderLocation}{file}");
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }
    }
}
