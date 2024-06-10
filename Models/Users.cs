using System.ComponentModel.DataAnnotations;

namespace TugasAkhir_VsCode.Models;

public class Users {
    [Key]
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public DateTime? BgEffDate { get; set; }
    public string? Status { get; set; }
    public string? Role_User { get; set; }
}