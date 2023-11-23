using Backend.Data;
using Backend.Dtos.Cliente;
using Backend.Dtos.Veiculo;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;


        public VeiculoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstVeiculo = _appDbContext.Veiculos.ToList();

            if (lstVeiculo == null)
            {
                return NotFound();
            }

            var lstVeiculoReadDto = new List<ReadVeiculoDto>();

            foreach (var veiculo in lstVeiculo)
            {
                lstVeiculoReadDto.Add(new ReadVeiculoDto()
                {
                   Id = veiculo.Id,
                   Marca = veiculo.Marca,
                   Modelo = veiculo.Modelo,
                   Placa = veiculo.Placa,
                   TipoVeiculo = veiculo.TipoVeiculo,
                   ValorDiaria = veiculo.ValorDiaria
                });
            }

            return Ok(lstVeiculoReadDto);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var veiculo = _appDbContext.Veiculos.FirstOrDefault(x => x.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            var readVeiculoDto = new ReadVeiculoDto()
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Placa = veiculo.Placa,
                TipoVeiculo = veiculo.TipoVeiculo,
                ValorDiaria = veiculo.ValorDiaria
            };

            return Ok(readVeiculoDto);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVeiculoDto veiculoDto)
        {
            Veiculo veiculo = new Veiculo()
            {
                Modelo = veiculoDto.Modelo,
                TipoVeiculo = veiculoDto.TipoVeiculo,
                Marca = veiculoDto.Marca,
                Placa = veiculoDto.Placa,
                ValorDiaria = veiculoDto.ValorDiaria
            };

            await _appDbContext.AddAsync(veiculo);
            await _appDbContext.SaveChangesAsync();

            var readVeiculoDto = new ReadVeiculoDto()
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Placa = veiculo.Placa,
                TipoVeiculo = veiculo.TipoVeiculo,
                ValorDiaria = veiculo.ValorDiaria
            };

            return CreatedAtAction(nameof(Get), new { id = readVeiculoDto.Id }, readVeiculoDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateVeiculoDto veiculoDto)
        {
            var veiculo = _appDbContext.Veiculos.FirstOrDefault(x => x.Id == id);

            if (veiculo == null)
            {
                return NotFound();
            }

            veiculo.Modelo = veiculoDto.Modelo;
            veiculo.ValorDiaria = veiculoDto.ValorDiaria;
            veiculo.Placa = veiculoDto.Placa;
            veiculo.Marca = veiculoDto.Marca;
            veiculo.TipoVeiculo = veiculoDto.TipoVeiculo;

            _appDbContext.Update(veiculo);

            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var veiculo = _appDbContext.Veiculos.FirstOrDefault(x => x.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _appDbContext.Remove(veiculo);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}