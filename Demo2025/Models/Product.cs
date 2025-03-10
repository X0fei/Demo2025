using System;
using System.Collections.Generic;

namespace Demo2025.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProductType { get; set; }

    public string Article { get; set; } = null!;

    public decimal MinimalCost { get; set; }

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();

    public virtual ProductType ProductTypeNavigation { get; set; } = null!;
}
