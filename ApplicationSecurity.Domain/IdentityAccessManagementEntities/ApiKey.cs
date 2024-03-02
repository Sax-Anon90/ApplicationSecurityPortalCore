using System;
using System.Collections.Generic;

namespace ApplicationSecurity.Domain.IdentityAccessManagementEntities;

public partial class ApiKey
{
    public int Id { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public string ClientSecret { get; set; } = null!;

    public string ExpiryDate { get; set; } = null!;

    public bool ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public DateTime? DateInactive { get; set; }
}
