using System;
using System.Collections.Generic;

namespace ApplicationSecurity.Domain.IdentityAccessManagementEntities;

public partial class SingleSignOnUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public bool ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public DateTime? DateInactive { get; set; }

    public virtual User User { get; set; } = null!;
}
