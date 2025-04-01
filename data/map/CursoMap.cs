using ApiCursos.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursos.data.map{
        public class CursoMap : IEntityTypeConfiguration<CursoModels>
    {
        public void Configure(EntityTypeBuilder<CursoModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeDoCurso).IsRequired();
        }
    }
}