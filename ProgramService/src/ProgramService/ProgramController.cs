using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProgramService
{
    [Route("/programs")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository context;
        private readonly ICourseClient courseClient;
        private HttpClient http;
        private List<CourseInfo> courses = new List<CourseInfo>();
        

        public ProgramController(IProgramRepository repo, ICourseClient courseClient)
        {
            context = repo;
            this.courseClient = courseClient;         
            context.Initialize();
            http = new HttpClient
                {
                    BaseAddress = new Uri("http://courses-service-nice-gazelle.cfapps.io")
                };
        }

        public async Task GetAllCourses()
        {
            http.DefaultRequestHeaders.Accept.Clear();                       
            var uri = http.BaseAddress + "/course";          
            var task = await http.GetAsync(uri);            
            var result = await task.Content.ReadAsAsync(typeof(List<CourseInfo>));   
            courses = (List<CourseInfo>)result;        
            return;
            //courses = result;
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
            if(!AllCoursesPresent(program.Courses)){
                return NotFound();
            }
            var created = context.Create(program);
            return CreatedAtRoute("GetProgram", new { id = created.Id }, created);
        }

        private bool AllCoursesPresent(List<long> postedCourses)
        {
            GetAllCourses().GetAwaiter().GetResult();
            foreach(var id in postedCourses)
            {
                //Check in the courses whether posted courses are listed/exists to validate and proceed.
                if(courses.Find(p=> p.Found(id)==true)==null) return false;
            }
            return true;
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