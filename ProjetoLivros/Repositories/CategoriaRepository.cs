using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> ListarTodos()
        {
            return _context.Categoria
           .Select(c => new Categoria
           {
               CategoriaId = c.CategoriaId,
               NomeCategoria = c.NomeCategoria,
           }).ToList();
        }
    }
}
