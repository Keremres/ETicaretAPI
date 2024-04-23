using Business.Abstracts;
using Core.Entities.Concretes;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class UserManager : IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public List<OperationClaim> GetClaims(User user)
    {
        return _userDal.GetClaims(user);
    }

    public void Add(User user)
    {
        _userDal.Add(user);
    }

    public User GetByMail(string email)
    {
        return _userDal.Get(u => u.Email == email);

    }
}