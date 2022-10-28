using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models;

public class User
{
    [DefaultValue("NoSet")] public string Name { get; set; } = "NoSet1";
    [DefaultValue(443)] [Required] public int Id { get; set; }
    [DefaultValue(18)] public int age { get; set; }
}