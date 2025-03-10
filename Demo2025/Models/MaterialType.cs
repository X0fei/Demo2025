using System;
using System.Collections.Generic;

namespace Demo2025.Models;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal MarriagePercentage { get; set; }
}
