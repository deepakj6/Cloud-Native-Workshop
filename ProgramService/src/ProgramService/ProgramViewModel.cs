using System.Collections.Generic;

namespace ProgramService
{
    public class ProgramViewModel
    {
        public long Id {get;set;}

        public string Name{get;set;}

        public IEnumerable<Course> courses;

        public ProgramViewModel()
        {
            
        }
    }
}