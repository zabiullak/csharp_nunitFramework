using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FreeCodeCamp.xUnitTest
{
    public class RestSharp_v107
    {
        [Fact]
        public async Task IndexAsync_GET()
        {
            var url = "https://reqres.in/api/users?page=2";
            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            var Output = response.Content;
            //return View();
            Console.WriteLine(Output);
        }

        [Fact]
        public async Task IndexAsync_POST()
        {
            var url = "https://reqres.in/api/users";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                name = "Mohamad Zabiulla",
                job = "Test Engineer"
            };
            var bodyy = JsonConvert.SerializeObject(body);
            request.AddBody(bodyy, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
        }
        [Fact]
        public async Task IndexAsync_PUT()
        {
            var url = "https://reqres.in/api/users";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Put);
            request.AddHeader("Content-Type", "application/json");
            var body = new
            {
                name = "Mohamad Zabiulla",
                job = "------"
            };
            var bodyy = JsonConvert.SerializeObject(body);
            request.AddBody(bodyy, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
        }
        [Fact]
        public async Task IndexAsync_DELETE()
        {
            var url = "https://reqres.in/api/users?page=2";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Delete);
            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
        }
    }
}
