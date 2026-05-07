using System.ComponentModel.DataAnnotations;

namespace Projekt.Web.DTOs;
public class CreateUserDTO
{
    [Required(ErrorMessage = "Jméno je povinné.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email je povinný.")]
    [EmailAddress(ErrorMessage = "Neplatný formát emailu.")]
    public string Email { get; set; } = string.Empty;
}