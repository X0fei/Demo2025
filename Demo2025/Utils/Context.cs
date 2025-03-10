using Demo2025.Context;
using Demo2025.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2025.Utils
{
    public static class Context
    {
        public static User21Context DbContext { get; set; } = new();
        public static List<Partner> Partners { get; set; } = [.. DbContext.Partners
            .Include(partners => partners.PartnerTypeNavigation)
            .Include(partner => partner.PartnersProducts)];
        public static List<PartnerType> PartnerTypes { get; set; } = [.. DbContext.PartnerTypes];
    }
}
