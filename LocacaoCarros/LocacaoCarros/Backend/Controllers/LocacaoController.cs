using Backend.Data;
using Backend.Dtos.Cliente;
using Backend.Dtos.Locacao;
using Backend.Models;
using Business.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICalculoValorLocacao _calculoValorLocacao;

        public LocacaoController(AppDbContext appDbContext, ICalculoValorLocacao calculoValorLocacao)
        {
            _appDbContext = appDbContext;
            _calculoValorLocacao = calculoValorLocacao;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstLocacoes = _appDbContext.Locacoes;

            if (lstLocacoes == null)
            {
                return NotFound();
            }

            var lstLocacaoReadDto = new List<ReadLocacaoDto>();

            foreach (var locacao in lstLocacoes)
            {
                // Formata o ValorTotalLocacao para ter duas casas decimais
                locacao.ValorTotalLocacao = Math.Round(locacao.ValorTotalLocacao, 2);
                
                lstLocacaoReadDto.Add(new ReadLocacaoDto()
                {
                   Id = locacao.Id,
                   DataColeta = locacao.DataColeta,
                   DataEntrega = locacao.DataEntrega,
                   IdCliente = locacao.IdCliente,
                   IdVeiculo = locacao.IdVeiculo,
                   ValorTotalLocacao = locacao.ValorTotalLocacao
                });
            }

            return Ok(lstLocacaoReadDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var locacao = _appDbContext.Locacoes.FirstOrDefault(x => x.Id == id);

            if (locacao == null)
            {
                return NotFound();
            }

            var readLocacaoDto = new ReadLocacaoDto()
            {
                Id = locacao.Id,
                DataColeta = locacao.DataColeta,
                DataEntrega = locacao.DataEntrega,
                IdCliente = locacao.IdCliente,
                IdVeiculo = locacao.IdVeiculo,
                ValorTotalLocacao = locacao.ValorTotalLocacao
            };

            return Ok(readLocacaoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLocacaoDto locacaoDto)
        {
            var veiculo = _appDbContext.Veiculos.FirstOrDefault(x => x.Id == locacaoDto.IdVeiculo);

            if (veiculo == null)
            {
                return BadRequest();
            }

            double valorTotal = _calculoValorLocacao.CalcularValorLocacao(locacaoDto.DataColeta, locacaoDto.DataEntrega, veiculo.ValorDiaria);

            Locacao locacao = new Locacao()
            {
                IdCliente = locacaoDto.IdCliente,
                IdVeiculo = locacaoDto.IdVeiculo,
                DataColeta = locacaoDto.DataColeta,
                DataEntrega= locacaoDto.DataEntrega,
                ValorTotalLocacao = valorTotal,
            };

            await _appDbContext.AddAsync(locacao);
            await _appDbContext.SaveChangesAsync();

            var readLocacaoDto = new ReadLocacaoDto()
            {
                Id = locacao.Id,
                DataColeta = locacao.DataColeta,
                DataEntrega = locacao.DataEntrega,
                IdCliente = locacao.IdCliente,
                IdVeiculo = locacao.IdVeiculo,
                ValorTotalLocacao = locacao.ValorTotalLocacao
            };


            return CreatedAtAction(nameof(Get), new { id = readLocacaoDto.Id }, readLocacaoDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var locacao = _appDbContext.Locacoes.FirstOrDefault(x => x.Id == id);

            if (locacao == null)
            {
                return NotFound();
            }

            _appDbContext.Remove(locacao);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
