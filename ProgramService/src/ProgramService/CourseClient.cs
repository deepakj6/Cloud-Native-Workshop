using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ProgramService
{
    public class CourseClient : ICourseClient
    {
        private readonly HttpClient client;

        public CourseClient(HttpClient httpClient)
        {
            client = httpClient;
        }
       
        public async Task<IEnumerable<CourseInfo>> GetAllCourses()
        {
            client.DefaultRequestHeaders.Accept.Clear();           
            //Task<HttpResponseMessage> task =  client.GetAsync(client.BaseAddress + "/course"); 
            var uri = client.BaseAddress + "/course";          
            var task = await client.GetAsync(uri);            
            var data = await task.Content.ReadAsAsync(typeof(List<CourseInfo>));
            var result = data;

            //var streamTask = client.GetStreamAsync(client.BaseAddress + "/course");
            //var response = await streamTask;
            //var result = streamTask.Result;
            
            //var streamTask = client.GetStreamAsync($"project?projectId={projectId}");            

            //var serializer = new DataContractJsonSerializer(typeof(CourseInfo));
            //var finalResult = serializer.ReadObject(result) as IEnumerable<CourseInfo>;
            //return serializer.ReadObject(await streamTask) as IEnumerable<CourseInfo>;
            return null;
        }
    }
}