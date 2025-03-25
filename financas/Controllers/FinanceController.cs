using financas.Data.Service;
using financas.Models;
using Microsoft.AspNetCore.Mvc;

namespace financas.Controllers;
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : ControllerBase 
    {
        private readonly IFinanceService _context;
        public FinanceController(IFinanceService context)
        {
            _context = context;
        }

        [HttpGet("dados")]
        public async Task<IActionResult> DataBaseGet(){
            var data = await _context.DataBaseGet();
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] FinancasModel dados)
        {
            if (dados.Description != null || dados.Type != null || dados.Amount < 0 ){
                try
                {
                    await _context.Add(dados);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else {
                throw new Exception("Um ou mais campos nao foram preenchidos");
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _context.Delete(id);
                return Ok();
            } 
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, FinancasModel edit)
        {
            try
            {
                await _context.Update(id, edit);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


