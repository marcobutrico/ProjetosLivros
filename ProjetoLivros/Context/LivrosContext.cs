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
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //String de conexao
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0L5VRFL\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        //---------------------------------------------------------------

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
              //Representacao da tabela
              entity =>
              {
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
                  entity.HasOne(t => t.TipoUsuario)
                 .WithMany(u => u.Usuarios)
                 .HasForeignKey(t => t.TipoUsuarioId)
                 .OnDelete(DeleteBehavior.Cascade);

              }
              );

            //---------------------------------------------------------------

            modelBuilder.Entity<TipoUsuario>(entity =>
            {

                //Primary Key
                entity.HasKey(t => t.TipoUsuarioId);

                //Tipo de Usuario: ("Assinante", "Administrador").
                entity.Property(u => u.DescricaoTipo)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                //Descricao nao pode se repetir, ser unico
                entity.HasIndex(t => t.DescricaoTipo)
                .IsUnique();


            });

            //---------------------------------------------------------------


            modelBuilder.Entity<Livro>(entity =>
            {

                //Primary Key
                entity.HasKey(l => l.LivroId);

                entity.Property(l => l.Titulo)
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

                entity.Property(l => l.Autor)
               .IsRequired()
               .HasMaxLength(200)
               .IsUnicode(false);

                entity.Property(l => l.Descricao)
               .HasMaxLength(250)
               .IsUnicode(false);

                entity.Property(l => l.DataPublicacao)
                .IsRequired();

                //Relacionamento
                //Livro - Categoria
                //No nosso exemplo cada livro so pode 1 categorias
                //A categoria pode ter varias categorias
                //Relacionamento
                entity.HasOne(l => l.Categoria)
               .WithMany(c => c.Livros)
               .HasForeignKey(l => l.CategoriaId)
               .OnDelete(DeleteBehavior.Cascade);

            });


            //---------------------------------------------------------------


            modelBuilder.Entity<Categoria>(entity =>
            {
                //Primary Key
                entity.HasKey(c => c.CategoriaId);

                entity.Property(l => l.NomeCategoria)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            });



            //---------------------------------------------------------------

            modelBuilder.Entity<Assinatura>(entity =>
            {

                //Primary Key
                entity.HasKey(a => a.AssinaturaId);

                entity.Property(a => a.DataInicio)
               .IsRequired();

                entity.Property(a => a.DataFim)
               .IsRequired();

                entity.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                //Relacionamento
                entity.HasOne(a => a.Usuario)
               .WithMany()                      //(u=> u.Assinaturas)
               .HasForeignKey(a => a.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);


            });



            //---------------------------------------------------------------











        }

    }
}