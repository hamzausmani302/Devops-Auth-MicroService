using System.ComponentModel.DataAnnotations;

public class UserRefreshToken
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public User User { get; set; }
    [Required]
    public string RefreshToken { get; set; }
    public bool isActive { get; set; }

}