using System;
using System.Collections.Generic;
using System.Linq;

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

    public virtual ICollection<PartnersProduct> PartnersProducts { get; set; } = [];
    public int Discount
    {
        get
        {
            //Считаем сумму количества проданных продуктов и в зависимости от количества возвращаем скидку
            switch (PartnersProducts.Select(partnerProduct => partnerProduct.ProductQuantity).Sum())
            {
                case < 10000: return 0;
                case < 50000: return 5;
                case < 300000: return 10;
                case > 300000: return 15;
            }
            return 0;
        }
    }
}
