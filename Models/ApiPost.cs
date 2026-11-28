using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TylerSupportPortal.Tests.Models
{
    public class ApiPost
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Body { get; set; } = string.Empty;
    }
}
