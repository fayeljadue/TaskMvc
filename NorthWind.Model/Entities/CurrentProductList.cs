using System;
using System.Collections.Generic;

namespace NorthWind.Model.Entities;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
