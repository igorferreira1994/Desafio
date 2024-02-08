using CadastroFront.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CadastroFront.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        Uri baseAdress = new Uri("http://localhost:5010/");
        private readonly HttpClient _httpClient;
        public List<Cliente> clientes = new List<Cliente>();

        public IndexModel()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAdress;
        }

        public void OnGet()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(data);
            }
        }
    }
}
