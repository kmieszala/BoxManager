using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace BoxManager.WebUI.Controllers;

[Route("api/[controller]")]
public class HomeController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Test()
    {
        return Ok(JsonSerializer.Serialize("Test ok"));
    }
}