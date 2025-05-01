namespace ProjetoLivros.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; private set; }
        public string Senha { get; set; }

        public string? Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public int TipoUsuarioId { get; set; }

        //Quem irá preencher é o Entity Framework
        public TipoUsuario? TipoUsuario { get; set; }

    }
}
