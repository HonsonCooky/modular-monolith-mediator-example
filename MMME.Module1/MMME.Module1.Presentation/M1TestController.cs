using Microsoft.AspNetCore.Mvc;

namespace MMME.Module1.Presentation;

[Route("api/[controller]")]
public class M1TestController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Test()
    {
        return "Test";
    }

}