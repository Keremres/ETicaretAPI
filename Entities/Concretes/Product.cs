using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Product : BaseEntity<int>
{
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public long Price { get; set; }


    public ICollection<Order> Orders { get; set; }
    public ICollection<Category> Categories { get; set; }

}
