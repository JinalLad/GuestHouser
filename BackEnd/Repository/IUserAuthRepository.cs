using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Repository
{
    public interface IUserAuthRepository
    {
        void Insert(t_user obj);
        t_user Login(vmLogin data);
    }
}