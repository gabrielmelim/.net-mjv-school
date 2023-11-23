using Backend.Data;
using Backend.Dtos.Cliente;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ClienteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Obter todos os clientes",
            Description = "Retorna uma lista de todos os clientes.",
            OperationId = "GetClientes",
            Tags = new[] { "Clientes" }
        )]
        [SwaggerResponse(200, "Lista de clientes", typeof(IEnumerable<Cliente>))]
        public IActionResult Get()
        {
            var lstClientes = _appDbContext.Clientes;

            if (lstClientes == null)
            {
                return NotFound();
            }

            var lstClientesReadDto = new List<ReadClienteDto>();

            foreach (var cliente in lstClientes)
            {
                lstClientesReadDto.Add(new ReadClienteDto()
                {
                    Id = cliente.Id,
                    Email = cliente.Email,
                    Nome = cliente.Nome,
                });
            }

            return Ok(lstClientesReadDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _appDbContext.Clientes.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            var readClienteDto = new ReadClienteDto()
            {
                Id = cliente.Id,
                Email = cliente.Email,
                Nome = cliente.Nome,
            };

            return Ok(readClienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteDto clienteDto)
        {
            Cliente cliente = new Cliente()
            {
                Nome = clienteDto.Nome,
                Email = clienteDto.Email
            };

            await _appDbContext.AddAsync(cliente);
            await _appDbContext.SaveChangesAsync();

            var readClienteDto = new ReadClienteDto()
            {
                Id = cliente.Id,
                Email = cliente.Email,
                Nome = cliente.Nome,
            };

            return CreatedAtAction(nameof(Get), new { id = readClienteDto.Id }, readClienteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            var cliente = _appDbContext.Clientes.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nome = clienteDto.Nome;
            cliente.Email = clienteDto.Email;

            _appDbContext.Update(cliente);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = _appDbContext.Clientes.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _appDbContext.Remove(cliente);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}