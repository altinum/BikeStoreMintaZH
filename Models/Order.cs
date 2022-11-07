using System;
using System.Collections.Generic;

namespace BikeStoreMintaZH.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderSk { get; set; }
        public int? CustomerFk { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int StoreFk { get; set; }
        public int StaffFk { get; set; }

        public virtual Customer? CustomerFkNavigation { get; set; }
        public virtual Staff StaffFkNavigation { get; set; } = null!;
        public virtual Store StoreFkNavigation { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
