using APIs_con_.NET.Models;

namespace APIs_con_.NET.Services
{
    public class TareaService : ITareaService
    {
         TareasContext context;

         public TareaService(TareasContext dbcontext)
         {
            context = dbcontext;
         }

         public IEnumerable<Tarea> Get()
         {
            return context.Tareas;
         }

         public async Task Save(Tarea Tarea)
         {
            context.Add(Tarea);
            await context.SaveChangesAsync();

         }

        public async Task Update(Guid id, Tarea Tarea)
         {
            var TareaActual = context.Tareas.Find(id);

            if (TareaActual != null)
            {
                TareaActual.Titulo = Tarea.Titulo;
                TareaActual.Descripcion = Tarea.Descripcion;
                TareaActual.PrioridadTarea = Tarea.PrioridadTarea;
                TareaActual.FechaCreacion = Tarea.FechaCreacion;
                TareaActual.Categoria = Tarea.Categoria;
                TareaActual.Resumen = Tarea.Resumen;
                
                await context.SaveChangesAsync();
            }
         }

        public async Task Delete(Guid id, Tarea Tarea)
         {
            var TareaActual = context.Tareas.Find(id);

            if (TareaActual != null)
            {
                context.Remove(TareaActual);
                await context.SaveChangesAsync();
            }
         }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea Tarea);
        Task Update(Guid id, Tarea Tarea);
        Task Delete(Guid id, Tarea Tarea);
    }
}