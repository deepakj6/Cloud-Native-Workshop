using System.Collections.Generic;

namespace ProgramService
{
    public class ProgramInfo
    {
        public long Id {get;set;}

        public string Name{get;set;}

        public List<long> Courses{get;set;}        

        public ProgramInfo(){ }

        public ProgramInfo(string Name, List<long> Courses){            
            this.Name = Name;
            if(Courses == null) Courses = new List<long>();
            this.Courses = Courses;
        }
    }
}