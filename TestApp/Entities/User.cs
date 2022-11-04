using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public partial class User
    {
        [Required] public string Email { get; set; } = null!;
        [Required] public string Displayname { get; set; } = null!;
        public int Id { get; set; }
    }
}