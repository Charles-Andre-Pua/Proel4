using System;
using System.Collections.Generic;

namespace Pua_UserManagement.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
