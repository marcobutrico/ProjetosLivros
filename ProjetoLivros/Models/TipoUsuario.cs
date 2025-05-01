namespace ProjetoLivros.Models
{
    public class TipoUsuario
    {
        public int TipoUsuarioId { get; set; }

        //Tipo de Usuario: ("Assinante", "Administrador").
        public string DescricaoTipo { get; set; }

        //Através do tipo do usuario, é possivel visualizar os usuarios
        public List<Usuario> Usuarios { get; set; } = new();
    }
}
