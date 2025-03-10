using System;
using System.Collections.Generic;

namespace Demo2025.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int PartnerType { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Tin { get; set; } = null!;

    public int Rating { get; set; }

    public string? Director { get; set; }

    public virtual PartnerType PartnerTypeNavigation { get; set; } = null!;

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = new List<PartnersProduct>();
}
