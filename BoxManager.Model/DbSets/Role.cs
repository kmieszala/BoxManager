using BoxManager.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace BoxManager.Model.DbSets;

public class Role
{
    public Role()
    {
        UserRoles = new HashSet<UserRoles>();
    }

    [Key]
    public RolesEnum Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<UserRoles> UserRoles { get; set; }
}