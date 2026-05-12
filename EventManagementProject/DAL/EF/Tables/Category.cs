using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
