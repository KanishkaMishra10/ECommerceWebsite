using System;
using System.Collections.Generic;

namespace Ecomm.Service.Domain.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string OderStatus { get; set; } = null!;

    public DateTime? DeliveryDate { get; set; }

    public int ProductId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
