using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Customer : BaseEntity<int>
{
    public string CustomerName { get; set; }


    public ICollection<Order> orders { get; set; }

}
