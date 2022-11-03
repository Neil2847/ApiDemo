using System;
using System.Collections.Generic;

namespace TestApp.Entities
{
    public partial class User
    {
        public string Email { get; set; } = null!;
        public string Displayname { get; set; } = null!;
        public int Id { get; set; }
    }
}
