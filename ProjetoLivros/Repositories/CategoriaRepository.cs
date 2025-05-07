using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Context;
using ProjetoLivros.Interface;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    //1 - herdar e implementar
    //2 - injetar contexto
    public class CategoriaRepository : ICategoriaRepository
    {
        //injecao de contexto
        // -------------

        private LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }

        public Categoria? Categoria => throw new NotImplementedException();

        public Categoria? Atualizar(int id, Categoria categoria)
        {
            //1 - Procuro que quero apagar
            var categoriaEncontrada = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            //2 - Se nao achei, retorno nulo
            if (categoriaEncontrada == null) return null;
            //3 Se achei, apago
            categoriaEncontrada.NomeCategoria = categoria.NomeCategoria;
            _context.SaveChanges();

            return categoria;
        }

        public Categoria? Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public Categoria? Deletar(int id)
        {
            //1 - Procuro que quero apagar
            var categoria = _context.Categorias.Find(id);
            //2 - Se nao achei, retorno nulo
            if (categoria == null) return null;
            //3 Se achei, apago
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }

        // -------------

        //buscando o metodo assincrono
        public List<Categoria> ListarTodos()
        {
            return _context.Categorias.ToList();
        }

        //buscando o metodo assincrono
        public async Task<List<Categoria>> ListarTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        void ICategoriaRepository.Cadastrar(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}