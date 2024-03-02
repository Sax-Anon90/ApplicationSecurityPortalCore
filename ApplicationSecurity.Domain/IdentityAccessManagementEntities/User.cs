using System;
using System.Collections.Generic;

namespace ApplicationSecurity.Domain.IdentityAccessManagementEntities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? UserName { get; set; }

    public string? DisplayName { get; set; }

    public string? TelNo { get; set; }

    public string? MobileNo { get; set; }

    public string Email { get; set; } = null!;

    public string UserCode { get; set; } = null!;

    public string? IdNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PasswordHash { get; set; }

    public string? ResetPasswordHash { get; set; }

    public DateTime? PasswordSetUpExpiryDate { get; set; }

    public DateTime? PasswordResetExpiryDate { get; set; }

    public int UserTypeId { get; set; }

    public bool ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public DateTime? DateInactive { get; set; }

    public virtual ICollection<SingleSignOnUser> SingleSignOnUsers { get; set; } = new List<SingleSignOnUser>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual UserType UserType { get; set; } = null!;
}
