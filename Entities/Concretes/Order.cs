using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Order : BaseEntity<int>
{
    public string Description { get; set; }
    public string Address { get; set; }


    public ICollection<Product> products { get; set; }
    public Customer customer { get; set; }


}
