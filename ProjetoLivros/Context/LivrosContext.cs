using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{
    //precisa ter o Entity Framework
    public class LivrosContext : DbContext
    {
        //Cada tabela -> DBSet para cada tabela

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Assinatura> Assinatura { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        //ctor - Construtor
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {
        }
        
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //String de conexao
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0L5VRFL\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
                //Representacao da tabela
                entity => {
                    //Primary Key
                    entity.HasKey(u => u.UsuarioId);

                    entity.Property(u => u.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    //Email unico
                    entity.HasIndex(u => u.Email)
                    .IsUnique();

                    entity.Property(u => u.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);


                    entity.Property(u => u.Telefone)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    entity.Property(u => u.DataCadastro)
                    .IsRequired();

                    entity.Property(u => u.DataAtualizacao)
                    .IsRequired();

                    //Relacionamento
                    entity.HasOne(u => u.TipoUsuario)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(u => u.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                }


                );


        }


        }
}
