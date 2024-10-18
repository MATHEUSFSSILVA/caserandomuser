using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using caserandomuser.Entities;
using caserandomuser.Models;
using caserandomuser.Services;
using Microsoft.AspNetCore.Mvc;

namespace caserandomuser.Controller
{   
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ApiService _apiService;

        public HomeController(HttpClient httpClient, ApiService apiService)
        {
            _httpClient = httpClient;
            _apiService = apiService;
        }


        [HttpGet("gerarnovousuario/{id}")]
        public async Task<ActionResult<ApiResponse>> GerarNovoUsuario(string id)
        {
            var response = await _apiService.ObterRespostaApiAsync(id);

            if (response == null)
            {
                return BadRequest($"A resposta da Api foi nula.");
            }
            
            if (response.Results == null)
            {
                return NotFound("Nenhum usuário foi gerado.");
            }

            return Ok(response);
        }
    }
}