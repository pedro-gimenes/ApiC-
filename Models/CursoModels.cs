
using System.ComponentModel.DataAnnotations;

namespace ApiCursos.models
{
    public class CursoModels
    {
        [Required(ErrorMessage = "Digite o RA do aluno")]
        public int Id { get; set;}
        
        [Required(ErrorMessage = "Digite o nome do curso")]
        public string? NomeDoCurso { get; set;}

        public static implicit operator CursoModels(AlunoModel v)
        {
            throw new NotImplementedException();
        }

        public CursoModels()
        {

        }
    }
}