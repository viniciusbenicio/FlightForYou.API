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
