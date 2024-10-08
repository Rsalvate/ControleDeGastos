﻿using Core.BaseTypes;

namespace Domain.Users;
public class User : BaseClass<Guid>
{
    public User(string name,
                string email,
                string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}
