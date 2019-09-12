using System.Runtime.Serialization;

namespace ProgramService
{
   //[DataContract(Name="info")]
    public class CourseInfo
    {
        //[DataMember(Name="active")]
        //public bool Active { get; set; }
        public long id;
        public string name;
        public int credit;
        public CourseInfo(){}
        public CourseInfo(long id, string name, int credit){
            this.id = id;
            this.name = name;
            this.credit = credit;
        }

        public bool Found(long id){
            if(this.id == id) return true;
            else return false;
        }
    }
    
}