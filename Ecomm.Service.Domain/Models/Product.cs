using System;
using System.Collections.Generic;

namespace Ecomm.Service.Domain.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int CategoryId { get; set; }

    public int StockQuantity { get; set; }

    public int UserId { get; set; }

    public int Discount { get; set; }

    public decimal Price { get; set; }

    public string Color { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
