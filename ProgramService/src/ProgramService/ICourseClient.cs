using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgramService
{
    public interface ICourseClient
    {
        Task<IEnumerable<CourseInfo>> GetAllCourses();
    }
}