﻿using Core.Entities.Concretes;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IUserService
{
    List<OperationClaim> GetClaims(User user);
    void Add(User user);
    User GetByMail(string mail);
}
