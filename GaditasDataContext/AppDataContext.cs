using System.Linq;
using Gaditas.Entities;
using Microsoft.EntityFrameworkCore;
using Gaditas.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GaditasDataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<PlanoAluno> Planos_Alunos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<ModalidadeAluno> Modalidades_Alunos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}