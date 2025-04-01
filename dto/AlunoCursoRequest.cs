using ApiCursos.models;

namespace ApiCursos.dto;
public class AlunoCursoRequest
{
    public AlunoModel Aluno { get; set; }
    public CursoModels Curso { get; set; }

    public AlunoCursoRequest()
        {
            Aluno = new AlunoModel();
            Curso = new CursoModels();
        }
}
