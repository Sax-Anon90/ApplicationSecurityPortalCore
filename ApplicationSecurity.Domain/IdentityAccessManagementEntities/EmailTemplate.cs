using System;
using System.Collections.Generic;

namespace ApplicationSecurity.Domain.IdentityAccessManagementEntities;

public partial class EmailTemplate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string TemplateHtml { get; set; } = null!;

    public bool ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public DateTime? DateInactive { get; set; }
}
