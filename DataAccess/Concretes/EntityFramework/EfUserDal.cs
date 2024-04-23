using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User,int,ETicaretAPIDbContext> , IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context = new ETicaretAPIDbContext())
        {
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, CreatedDate = userOperationClaim.CreatedDate,
                             DeletedDate = userOperationClaim.DeletedDate, Name = operationClaim.Name, UpdatedDate = userOperationClaim.UpdatedDate};
            return result.ToList();
        }
    }
}
