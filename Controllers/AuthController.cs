using Microsoft.AspNetCore.Mvc;
using PROJETO_LOGIN.Context;
using PROJETO_LOGIN.Entities;
 
 
namespace PROJETO_LOGIN.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly QuizContext _context;
 
        public AutenticacaoController(QuizContext dbContext)
        {
            _context = dbContext;
        }
 
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.SenhaHash == usuario.SenhaHash);
            if (user == null)
            {
                return Unauthorized(); 
            }
            return Ok(new { Message = "Logado!", UsuarioId = usuario.Id });
        }
    }
}