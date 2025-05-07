using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interface;
using ProjetoLivros.Repositories;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        //Injetar repository
        private readonly ICategoriaRepository _repository;


        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        // GET
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var categorias = _repository.ListarTodos();
            return Ok(categorias);
        }



    }
