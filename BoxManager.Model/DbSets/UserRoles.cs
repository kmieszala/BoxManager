using BoxManager.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoxManager.Model.DbSets;

public class UserRoles
{
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Role")]
    public RolesEnum RoleId { get; set; }

    public virtual Users User { get; set; }

    public virtual Role Role { get; set; }
}