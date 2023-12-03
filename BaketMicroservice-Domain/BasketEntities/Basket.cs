using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaketMicroservice_Domain.BasketEntities
{
    public class Basket : BaseEntity
    {
        public int ProductId { get; set; }
        public Decimal Total { get; set; }
        public Decimal Tax { get; set; }
        public Decimal ShippingCharges { get; set; }
    }
}
