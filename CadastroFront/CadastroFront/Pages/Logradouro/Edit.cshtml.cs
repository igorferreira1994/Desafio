using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CadastroFront.Model;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace CadastroFront.Pages
{
    public class EditLogModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        Uri baseAdress = new Uri("http://localhost:5010/");
        private readonly HttpClient _httpClient;

        public EditLogModel()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAdress;
        }
        [BindProperty]
        public Logradouros Logradouros { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Logradouro").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var logradouros = JsonConvert.DeserializeObject<List<Logradouros>>(data);
                var logradouro = logradouros.Where(x => x.IdLogradouro == id).FirstOrDefault();
                if (logradouro != null)
                    Logradouros = logradouro;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonContent = JsonConvert.SerializeObject(Logradouros);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = _httpClient.PatchAsync(_httpClient.BaseAddress + "Cliente", contentString).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
            }

            return RedirectToPage("./Index");
        }

    }
}
