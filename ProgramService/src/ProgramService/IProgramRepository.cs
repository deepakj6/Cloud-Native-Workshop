using System.Collections.Generic;

namespace ProgramService
{
    public interface IProgramRepository
    {
        //query courses to check which courses would be part of the program
        //Create course and professor
        //Program = id + set of courses
        IEnumerable<ProgramInfo> List();
        ProgramInfo FindById(long id);
        ProgramInfo Create(ProgramInfo program);
        ProgramInfo Update(long id, ProgramInfo program);        
        void Delete(long id);
        void Initialize();
    }
}