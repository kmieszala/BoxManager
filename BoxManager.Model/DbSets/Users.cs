using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BoxManager.Common.Enums;

namespace BoxManager.Model.DbSets;

public class Users
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(100)]
    [Required]
    public string LastName { get; set; }

    [ForeignKey("UserStatusDict")]
    public UserStatusEnum Status { get; set; }

    public int TimeBlockCount { get; set; }

    [MaxLength(64)]
    [Required]
    public string Password { get; set; }

    [MaxLength(100)]
    [Required]
    public string Email { get; set; }

    /// <summary>
    /// User registration by the administrator.
    /// </summary>
    public DateTime RegisteredDate { get; set; }

    /// <summary>
    /// First login and change password by user.
    /// </summary>
    public DateTime? ActivationDate { get; set; }

    public virtual ICollection<UserRoles> UserRoles { get; set; }
}