using FreeCodeCamp.xUnitTest.Helper;
using FreeCodeCamp.xUnitTest.Models.Request;
using FreeCodeCamp.xUnitTest.Models.Response;
using FreeCodeCamp.xUnitTest.Repositories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FreeCodeCamp.xUnitTest.Tests
{
    public class ReqResDotIn
    {
        private readonly ReqRes_repo _reqresRepo = new ReqRes_repo();
        /*[Fact]
        public async Task GetUsersLists()
        {
            var res = await API_calls.GetUsersData();
            int statusCode = (int)res.StatusCode;
            //FW.Log.Info($"Status Code =>{statusCode}");
            Assert.That(statusCode, Is.EqualTo(200));
            Assert.That(res.IsSuccessful, Is.True);
        }*/

        [Fact]
        public async Task GetUsers()
        {
            RestResponse res = await _reqresRepo.GetUsers();
            //ListUsers res_data = res.Content as ListUsers;
            //Assert.Equal(2, res_data.Page);
            int status = (int)res.StatusCode;
            Assert.Equal(200, status);
        }

        [Theory]
        [InlineData("CreateUser1.json")]
        [InlineData("CreateUser2.json")]
        [InlineData("CreateUser3.json")]
        public async Task CreateNewUserAsync(string jsonFileName)
        {
            CreateUserReq PayLoad = Utils.ParseJson<CreateUserReq>(jsonFileName);
            RestResponse res = await _reqresRepo.Create(PayLoad);
            
            int statusCode = (int)res.StatusCode;
            Assert.Equal(201, statusCode);
        }
    }
}
