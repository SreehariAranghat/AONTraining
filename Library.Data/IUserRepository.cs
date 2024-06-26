﻿using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User FromEmail(string email);
    }
}
