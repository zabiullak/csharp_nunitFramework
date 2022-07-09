using FreeCodeCamp.xUnitTest.Helper;
using FreeCodeCamp.xUnitTest.Models.Request;
using FreeCodeCamp.xUnitTest.Models.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.xUnitTest.Repositories
{
    public class ReqRes_repo 
    {
        private const string BASE_URL = "https://reqres.in";
        private const string Get_Users = "/api/users?page=2";
        private const string Get_user = "/api/users/";
        private const string Post_user = "/api/users";
        private const string Delete_user = "/api/users/2";

        public async Task<RestResponse> Create(CreateUserReq user)
        {
            string url = string.Format($"{BASE_URL}{Post_user}");
            RestRequest request = Utils.CreatePostRequest<CreateUserReq>(url, user);
            RestResponse response = await Utils.GetResponseAsync(request);
            return response;
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RestResponse> GetUsers()
        {
            // var client = ;
            string url = string.Format($"{BASE_URL}{Get_Users}");
            
            RestRequest request = Utils.CreateGetRequest(url);
            RestResponse response = await Utils.GetResponseAsync(request);
            return response;
        }

        public Task<UserDetail> Update(UserDetail user)
        {
            throw new NotImplementedException();
        }

    }
}
