using Microsoft.AspNetCore.Mvc;
using Projekt.Services;
using Projekt.Web.DTOs;

namespace Projekt.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDTO request)
    {
        _userService.CreateUser(request.FullName, request.Email);
        return Ok("Uživatel byl úspěšně vytvořen.");
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userService.GetAllUsers());
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            _userService.DeleteUser(id);
            return Ok($"Uživatel s ID {id} byl úspěšně smazán.");
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}