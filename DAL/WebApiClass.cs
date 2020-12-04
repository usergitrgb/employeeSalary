using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DTO;
using System.Configuration;
using System.Net.Http.Headers;

namespace DAL
{
    public class WebApiClass
    {
        static readonly HttpClient client = new HttpClient();


        public async Task<List<DTOEmployee>> GetEmployees()
        {
            try
            {
                DTOEmployee dTOEmployee = new DTOEmployee();
                string url = Properties.Settings.Default.urlBase;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();

                List<DTOEmployee> result = JsonConvert.DeserializeObject<List<DTOEmployee>>(resp);

                return result;

            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

    }
}
