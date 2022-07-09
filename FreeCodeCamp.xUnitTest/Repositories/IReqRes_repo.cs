using FreeCodeCamp.xUnitTest.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.xUnitTest.Repositories
{
    public interface IReqRes_repo
    {
        Task<IEnumerable<ListUsers>> GetUsers();
        Task<User> GetUser(int id);
        Task<UserDetail> Create(UserDetail user);
        Task<UserDetail> Update(UserDetail user);
        Task Delete();
    }
}
