using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Livraria.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Livraria.Mvc.Controllers
{
    public class LivroController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _LivrariaAPI;

        public LivroController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _LivrariaAPI = _httpClientFactory.CreateClient("LIVRARIA_API");
        }

        public IActionResult Index()
        {
            var response = _LivrariaAPI.GetAsync(_LivrariaAPI.BaseAddress + $"api/Livro/listar").Result;
            if (response.IsSuccessStatusCode)
            {
                var retorno = response.Content.ReadAsStringAsync().Result;
                var livros = JsonConvert.DeserializeObject<List<LivroViewModel>>(retorno);
                return View(livros);
            }
            return View(new List<LivroViewModel>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LivroViewModel livroViewModel)
        {
            return View();
        }
    }
}