using APIs_con_.NET.Models;
using APIs_con_.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIs_con_.NET.Controllers
{
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        ITareaService TareaService;

        public TareaController(ITareaService cService)
        {
            TareaService = cService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(TareaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea Tarea)
        {
            TareaService.Save(Tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Tarea Tarea)
        {
            TareaService.Update(id, Tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, [FromBody] Tarea Tarea)
        {
            TareaService.Delete(id, Tarea);
            return Ok();
        }
    }
}