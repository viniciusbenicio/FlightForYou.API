using AutoMapper;
using FlightForYou.API.Data;
using FlightForYou.API.Data.Dtos;
using FlightForYou.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightForYou.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PassagemController : ControllerBase
    {
        private PassagemContext _context;
        private IMapper _mapper;

        public PassagemController(PassagemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona uma passagem para ser comprada por algum usuário
        /// </summary>
        /// <param name="passagemdto">Objeto necessário para criação de uma passagem no banco de dados</param>
        /// <returns></returns>
        /// <response code="201">Caso a criação seja realizada com sucesso</response>
        [HttpPost]
        public IActionResult AddPassagem([FromBody] PassagemDto passagemdto)
        {
            Passagem passagem = _mapper.Map<Passagem>(passagemdto);
            _context.Passagens.Add(passagem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPassagemId),
                new { id = passagem.Id },
                passagem);
            
        }

        /// <summary>
        /// Remove uma passagem adicionada que poderia ser comprada por algum usuário
        /// </summary>
        /// <param name="id">Id da passagem que será deletada</param>
        /// <returns></returns>
        /// <response code="200">Caso o delete seja feito com sucesso</response>
        [HttpDelete("{id}")]
        public IActionResult DeletePassagem(int id)
        {
            var passagem = _context.Passagens.FirstOrDefault(p => p.Id == id);
            if (passagem == null)
                return NotFound();

            _context.Remove(passagem);
            _context.SaveChanges();
            return NoContent(); 
        }

        [HttpGet("{id}")]
        public IActionResult GetPassagemId(int id)
        {
            var passagem = _context.Passagens.FirstOrDefault(p => p.Id == id);

            if(passagem == null)
                 return NotFound();
            var passagemDto = _mapper.Map<PassagemDto>(passagem);
            return Ok(passagemDto);

        }


    }
}
