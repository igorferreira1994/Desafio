using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CadastroFront.Model;
using Newtonsoft.Json;
using System.Net.Http;

namespace CadastroFront.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        Uri baseAdress = new Uri("http://localhost:5010/");
        private readonly HttpClient _httpClient;

        public DeleteModel()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAdress;
        }
        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(data);
                var cliente = clientes.Where(x => x.IdCliente == id).FirstOrDefault();
                if (cliente != null)
                    Cliente = cliente;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "Cliente?id=" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
            }

            return RedirectToPage("./Index");
        }
    }
}
