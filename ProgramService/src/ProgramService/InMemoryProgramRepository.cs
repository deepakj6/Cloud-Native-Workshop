using System.Collections.Generic;
using System.Linq;

namespace ProgramService
{
    public class InMemoryProgramRepository : IProgramRepository
    {
        public readonly Dictionary<long, ProgramInfo> db = new Dictionary<long, ProgramInfo>();
        private bool IsInitialized = false;

        public void Initialize()
        {
            if (!IsInitialized)
            {
                db.Add(1, new ProgramInfo { Id = 1, Name = "UG-Mechanical", Courses = new List<long> { 1, 2 } });
                db.Add(2, new ProgramInfo { Id = 2, Name = "PG-Mechanical", Courses = new List<long> { 3, 4 } });
                db.Add(3, new ProgramInfo { Id = 3, Name = "UG-Computer Science", Courses = new List<long> { 5, 6 } });
                db.Add(4, new ProgramInfo { Id = 4, Name = "PG- Computer Engg", Courses = new List<long> { 7, 8 } });
                db.Add(5, new ProgramInfo { Id = 5, Name = "PG-Rural Development", Courses = new List<long> { 9, 10,11,12 } });
                IsInitialized = true;
            }
        }

        public ProgramInfo Create(ProgramInfo program)
        {
            var id = db.Count + 1;
            program.Id = id;
            db.Add(id, program);
            return db[id];
        }

        public void Delete(long id)
        {
            if (db.ContainsKey(id))
                db.Remove(id);
        }

        public ProgramInfo FindById(long id)
        {
            if (db.ContainsKey(id))
            {
                return db[id];
            }
            else return null;
        }

        public IEnumerable<ProgramInfo> List()
        {
            return db.Values.ToList();
        }

        public ProgramInfo Update(long id, ProgramInfo program)
        {
            if (db.ContainsKey(id))
            {
                program.Id = id;
                db[id] = program;
                return db[id];
            }
            else return null;
        }
    }
}