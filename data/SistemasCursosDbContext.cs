using Microsoft.EntityFrameworkCore;
using ApiCursos.data.map;
using ApiCursos.models;



namespace ApiCursos.data
{
    public class SistemaCursosDBContex : DbContext
    {
        public SistemaCursosDBContex(DbContextOptions<SistemaCursosDBContex> options)
            : base(options)
        {
        }

        public DbSet<AlunoModel> Alunos {get; set;}
        public DbSet<CursoModels> Cursos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}