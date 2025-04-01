using System.ComponentModel.DataAnnotations;

namespace ApiCursos.models
{
    public class AlunoModel
    {
        [Required(ErrorMessage = "Digite o nome do aluno")]
        public string? Name{get;set;}
        
        [Required(ErrorMessage = "Digite o RA do aluno")]
        public int? RA{get;set;}
    }
}