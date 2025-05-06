using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ICategoriaRepository
    {

        //Listar todas as Categorias
        //Get
        List<Categoria> ListarTodos();

        //Listar Categorias por Id
        //GetById
        Categoria BuscarPorId(int id);

        //Criar categoria
        //Create
        void Cadastrar(Categoria categoria);

        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada a categoria correspondente
        void Atualizar(int id, Categoria categoria);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta a categoria correspondente
        void Deletar(int id);

    }
}
