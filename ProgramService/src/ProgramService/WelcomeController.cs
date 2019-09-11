using Microsoft.AspNetCore.Mvc;

namespace ProgramService
{
    [Route("/welcome")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public string get() => "Welcome to Cloud Native Workshop!";
    }
}