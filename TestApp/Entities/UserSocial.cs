using System;
using System.Collections.Generic;

namespace TestApp.Entities
{
    public partial class UserSocial
    {
        public long UserId { get; set; }
        public int Type { get; set; }
        public string Token { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
