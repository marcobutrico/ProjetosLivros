using ProjetoLivros.Models;

namespace ProjetoLivros.Interface
{
    public interface ICategoriaRepository
    {
        //Assincrono - denominado de Tasks
        //Com o objetivo de liberar o processamento em funcao da busca de dados 

        //Listar todas as Categorias
        //Get
        Task<List<Categoria>> ListarTodosAsync();

        //Metodo sincrono
        List<Categoria> ListarTodos();

        //Criar categoria
        //Create
        void Cadastrar(Categoria categoria);
        Categoria? Categoria { get; }       //se achar, retorna categoria, ou nulo se nao achar

        //U - Update por Id - Update {id} e o que vai ser atualizado
        //Recebe um Id e atualizada a categoria correspondente
        Categoria? Atualizar(int id, Categoria categoria);

        //CRUD
        //D - Deletar por Id - Delete {id} 
        //Recebe um Id e deleta a categoria correspondente
        Categoria? Deletar(int id);

    }
}
