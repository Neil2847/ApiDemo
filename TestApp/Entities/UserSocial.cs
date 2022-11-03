using System;
using System.Collections.Generic;

namespace TestApp.Entities
{
    public partial class UserSocial
    {
        public int UserId { get; set; }
        public int Type { get; set; }
        public string Token { get; set; } = null!;
    }
}
