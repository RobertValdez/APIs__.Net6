using APIs_con_.NET.Models;
using APIs_con_.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIs_con_.NET.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService cService)
        {
            categoriaService = cService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(categoriaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            categoriaService.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Categoria categoria)
        {
            categoriaService.Update(id, categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, [FromBody] Categoria categoria)
        {
            categoriaService.Delete(id, categoria);
            return Ok();
        }
    }
}