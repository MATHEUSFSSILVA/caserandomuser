
using System.Globalization;
using System.Text;
using caserandomuser.Context;
using caserandomuser.Entities;
using caserandomuser.Models;
using caserandomuser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace caserandomuser.Controller
{   
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ApiService _apiService;

        public HomeController(AppDbContext context, ApiService apiService)
        {
            _context = context;
            _apiService = apiService;
        }


        [HttpGet("Index")]
        public async Task<IEnumerable<CadastrosEntity>> ListarUsuariosCadastrados()
        {
           var usuarios = await _context.Cadastros
                .Include(c => c.Name)
                .Include(c => c.Location)
                    .ThenInclude(c => c.Street)
                .Include(c => c.Location)
                    .ThenInclude(c => c.Coordinates)
                .Include(c => c.Location)
                    .ThenInclude(c => c.Timezone)
                .Include(c => c.Login)
                .Include(c => c.Dob)
                .Include(c => c.Registered)
                .Include(c => c.Id)
                .Include(c => c.Picture)
                .ToListAsync();

            Console.WriteLine("Usuários Cadastrados:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.IdInt}, Nome: {usuario.Name.First} {usuario.Name.Last}, Localização: {usuario.Location.City}");
            }

            return usuarios;
        }


        [HttpGet("gerarnovousuario/{id}")]
        public async Task<ActionResult<ApiResponse>> GerarNovoUsuario(string id)
        {   
            int numUsuarios;
            bool ehInteiro = int.TryParse(id, out numUsuarios);

            if (!ehInteiro)
            {
                numUsuarios = 1;   
            }
            else if (numUsuarios > 2)
            {
                return BadRequest("Máximo de 2 usuários por vez.");
            }


            var response = await _apiService.ObterRespostaApiAsync(numUsuarios);

            if (response == null)
            {
                return BadRequest($"A resposta da Api foi nula.");
            }
            
            if (response.Results == null)
            {
                return NotFound("Nenhum usuário foi gerado.");
            }

            return Ok(response.Results);
        }


        [HttpPost("cadastrarusuario")]
        public async Task<ActionResult> CadastrarUsuarioNoBancoDeDados(List<CadastrosEntity> listaUsuarios)
        {
            if (!listaUsuarios.Any())
            {
                return BadRequest("Lista vazia.");
            }

            else
            {
                await _context.Cadastros.AddRangeAsync(listaUsuarios);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }


        [HttpGet("pesquisarusuario/{id}")]
        public async Task<ActionResult> PesquisarUsuarioPorId(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Id Inválido.");
            }

            var usuario = await _context.Cadastros
                .Include(c => c.Name)
                .Include(c => c.Location)
                    .ThenInclude(c => c.Street)
                .Include(c => c.Location)
                    .ThenInclude(c => c.Coordinates)
                .Include(c => c.Location)
                    .ThenInclude(c => c.Timezone)
                .Include(c => c.Login)
                .Include(c => c.Dob)
                .Include(c => c.Registered)
                .Include(c => c.Id)
                .Include(c => c.Picture)
                .FirstOrDefaultAsync(c => c.IdInt == id);
            
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(usuario);
        }


        [HttpPut("editarusuario")]
        public async Task<ActionResult> EditarUsuario(CadastrosEntity usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Usuário inválido.");
            }

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário atualizado.");
        }


        [HttpDelete("deletarusuario/{id}")]
        public async Task<ActionResult> DeletarUsuario(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido.");
            }

            var usuarioCadastros = await _context.Cadastros.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioCoordinates = await _context.Coordinateses.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioDobs = await _context.Dobs.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioIds = await _context.Ids.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioLocations = await _context.Locations.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioLogins = await _context.Logins.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioNames = await _context.Names.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioPictures = await _context.Pictures.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioRegistereds = await _context.Registereds.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioStreets = await _context.Streets.FirstOrDefaultAsync(c => c.IdInt == id);
            var usuarioTimezones = await _context.Timezones.FirstOrDefaultAsync(c => c.IdInt == id);

            if (usuarioCadastros == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _context.Cadastros.Remove(usuarioCadastros);
            _context.Coordinateses.Remove(usuarioCoordinates);
            _context.Dobs.Remove(usuarioDobs);
            _context.Ids.Remove(usuarioIds);
            _context.Locations.Remove(usuarioLocations);
            _context.Logins.Remove(usuarioLogins);
            _context.Names.Remove(usuarioNames);
            _context.Pictures.Remove(usuarioPictures);
            _context.Registereds.Remove(usuarioRegistereds);
            _context.Streets.Remove(usuarioStreets);
            _context.Timezones.Remove(usuarioTimezones);
            
            await _context.SaveChangesAsync();

            return Ok("Usuário deletado.");
        }
    }
}