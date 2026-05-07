// Data Transfer Object pro čistý vstup dat od uživatele
using System.ComponentModel.DataAnnotations;

namespace Projekt.Web.DTOs;
public class CreateTaskDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}