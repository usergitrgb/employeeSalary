using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using DTO;
using Newtonsoft.Json;

namespace WebApiEployee.Controllers
{
    public class webApiEmployeeController : ApiController
    {
        // GET: api/webApiEmployee
        public async Task<IHttpActionResult> Get()
        {
            
            try
            {
                string url = ConfigurationManager.AppSettings["WebapiEmployees"].ToString();

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();

                List<DTOEmployee> result = JsonConvert.DeserializeObject<List<DTOEmployee>>(resp);

                return Ok(result);

            }
            catch (HttpRequestException e)
            {
                return null;
            }

            
        }

        // GET: api/webApiEmployee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/webApiEmployee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/webApiEmployee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/webApiEmployee/5
        public void Delete(int id)
        {
        }
    }
}
