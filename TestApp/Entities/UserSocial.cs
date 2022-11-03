using System;
using System.Collections.Generic;

namespace TestApp.Entities
{
    public partial class UserSocial
    {
        public int Type { get; set; }
        public string Token { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
