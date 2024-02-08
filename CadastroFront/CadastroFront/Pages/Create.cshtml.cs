﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CadastroFront.Model;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Net.Http.Headers;

namespace CadastroFront.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        Uri baseAdress = new Uri("http://localhost:5010/");
        private readonly HttpClient _httpClient;

        public CreateModel()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAdress;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Cliente == null)
            {
                return Page();
            }

            var jsonContent = JsonConvert.SerializeObject(Cliente);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Cliente", contentString).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
            }

            return RedirectToPage("./Index");
        }
    }
}
