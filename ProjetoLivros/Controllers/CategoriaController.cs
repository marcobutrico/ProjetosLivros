using Microsoft.AspNetCore.Mvc;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private ICategoriaController _categoriaRepository;

        public CategoriaController(ICategoriaController categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]

    }
}
