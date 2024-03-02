using System;
using System.Collections.Generic;

namespace ApplicationSecurity.Domain.IdentityAccessManagementEntities;

public partial class CustomerApplication
{
    public int Id { get; set; }

    public int CustomerForApplicationId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public DateTime? DateInactive { get; set; }

    public virtual CustomerForApplication CustomerForApplication { get; set; } = null!;

    public virtual ICollection<RoleGroup> RoleGroups { get; set; } = new List<RoleGroup>();
}
