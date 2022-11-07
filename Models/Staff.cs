using System;
using System.Collections.Generic;

namespace BikeStoreMintaZH.Models
{
    public partial class Staff
    {
        public Staff()
        {
            InverseManagerFkNavigation = new HashSet<Staff>();
            Orders = new HashSet<Order>();
        }

        public int StaffSk { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public byte Active { get; set; }
        public int StoreFk { get; set; }
        public int? ManagerFk { get; set; }

        public virtual Staff? ManagerFkNavigation { get; set; }
        public virtual Store StoreFkNavigation { get; set; } = null!;
        public virtual ICollection<Staff> InverseManagerFkNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
