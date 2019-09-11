using Microsoft.AspNetCore.Mvc;

namespace ProgramService
{
    [Route("/programs")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository context;

        public ProgramController(IProgramRepository repo)
        {
            context = repo;
            context.Initialize();
        }
        [HttpGet]
        public IActionResult List()
        {
            var result = context.List();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetProgram")]
        public IActionResult GetByProgramId(long id)
        {
            var result = context.FindById(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProgramInfo program)
        {
            var created = context.Create(program);
            return CreatedAtRoute("GetProgram", new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ProgramInfo program)
        {
            var updated = context.Update(id, program);
            if (updated != null)
                return Ok(updated);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if(context.FindById(id)==null)
            return NotFound();

            context.Delete(id);

            return NoContent();
        }
    }
}