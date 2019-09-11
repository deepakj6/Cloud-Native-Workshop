namespace ProgramService
{
    public class Course
    {
        private long id {get;}
        private string name{get;}
        private int credit{get;}
        public Course(){}
        public Course(long id, string name, int credit){
            this.id = id;
            this.name = name;
            this.credit = credit;
        }
    }
}