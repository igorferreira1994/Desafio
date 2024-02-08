
using CadastroFront.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CadastroFront.Pages
{
    public class IndexLogModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        Uri baseAdress = new Uri("http://localhost:5010/");
        private readonly HttpClient _httpClient;
        public List<Logradouros> Logradouro = new List<Logradouros>();

        public IndexLogModel()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAdress;
        }       

        public void OnGet()
        {            
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Logradouro").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Logradouro = JsonConvert.DeserializeObject<List<Logradouros>>(data);
            }
        }
    }
}
