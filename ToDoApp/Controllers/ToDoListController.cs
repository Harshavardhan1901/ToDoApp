using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ListDbContext _todoDbContext;

        public ToDoListController(ListDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<IEnumerable<List>> GetList()
        {
            return await _todoDbContext.List.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List>> GetListById(int id)
        {
            var task = await _todoDbContext.List.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPost]
        [Route("AddList")]
        public async Task<List> AddList(List objList)
        {
            _todoDbContext.List.Add(objList);
            await _todoDbContext.SaveChangesAsync();
            return objList;
        }

        [HttpPatch]
        [Route("UpdateList/{id}")]
        public async Task<List> UpdateList(List objList)
        {
            _todoDbContext.Entry(objList).State = EntityState.Modified;
            await _todoDbContext.SaveChangesAsync();
            return objList;
        }

        [HttpDelete]
        [Route("DeleteList/{id}")]
        public bool DeleteList(int id)
        {
            bool a = false;
            var ToDoList = _todoDbContext.List.Find(id);
            if (ToDoList != null)
            {
                a = true;
                _todoDbContext.Entry(ToDoList).State = EntityState.Deleted;
                _todoDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;

        }
    }
}
