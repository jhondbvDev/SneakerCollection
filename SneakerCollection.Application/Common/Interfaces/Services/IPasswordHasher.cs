﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application.Common.Interfaces.Services
{
    public  interface IPasswordHasher
    {
        string Hash(string password);
        bool VerifyPassword(string password,string passwordHash);
    }
}
