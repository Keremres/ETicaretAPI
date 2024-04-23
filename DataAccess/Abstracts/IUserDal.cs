﻿using Core.DataAccess;
using Core.Entities;
using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface IUserDal : IEntityRepository<User,int>
{
    List<OperationClaim> GetClaims(User user);
}
