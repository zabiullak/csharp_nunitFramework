using System;
using System.Collections.Generic;
using System.Text;

namespace FreeCodeCamp.xUnitTest.Models.Response
{
    public partial class User
    {
        public Details Data { get; set; }
        public Support Support { get; set; }
    }

    public partial class UserDetail
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
    public partial class ListUsers
    {
        public int Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public long TotalPages { get; set; }
        public List<Details> Data { get; set; }
        public Support Support { get; set; }
    }

    public partial class Details
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Avatar { get; set; }
    }

    public partial class Support
    {
        public Uri Url { get; set; }
        public string Text { get; set; }
    }
}
