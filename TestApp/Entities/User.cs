using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TestApp.Entities
{
    public partial class User
    {
        public long Id { get; set; }
        [Required] public string Email { get; set; } = null!;
        [Required] public string DisplayName { get; set; } = null!;
    }
}