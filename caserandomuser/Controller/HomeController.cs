
using System.Globalization;
using System.Text;
using caserandomuser.Context;
using caserandomuser.Entities;
using caserandomuser.Models;
using caserandomuser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

            return usuarios;
        }


        [HttpGet("gerarnovousuario")]
        public async Task<ActionResult<ApiResponse>> GerarNovoUsuario()
        {   
            var response = await _apiService.ObterRespostaApiAsync();

            if (response == null)
            {
                return BadRequest($"A resposta da Api foi nula.");
            }
            
            if (response.Results == null)
            {
                return NotFound("Nenhum usuário foi gerado.");
            }

            if (!response.Results.Any())
            {
                return NotFound("Lista usuários vazia.");
            }

            return Ok(response.Results[0]);
        }


        [HttpPost("cadastrarusuario")]
        public async Task<ActionResult> CadastrarUsuarioNoBancoDeDados([FromBody]CadastrosEntity usuarioCadastrar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Usuário inválido.");
            }

            _context.Cadastros.Add(usuarioCadastrar);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Usuário Cadastrado: ID: {usuarioCadastrar.IdInt}, Nome:{usuarioCadastrar.Name}.");
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


        [HttpPatch("editarusuario")]
        public async Task<ActionResult> EditarUsuario([FromBody]CadastrosEntity usuario)
        {

            Console.WriteLine(JsonConvert.SerializeObject(usuario));
            
            if (!ModelState.IsValid)
            {
                return BadRequest("Usuário inválido.");
            }
            
            try 
            {
                _context.Cadastros.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Erro ao atualizar o usuário: {dbEx.Message}");
            }

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