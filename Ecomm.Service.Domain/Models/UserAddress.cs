using System;
using System.Collections.Generic;

namespace Ecomm.Service.Domain.Models;

public partial class UserAddress
{
    public int AddressId { get; set; }

    public string AddressDesc { get; set; } = null!;

    public string AddState { get; set; } = null!;

    public string City { get; set; } = null!;

    public int Pincode { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
