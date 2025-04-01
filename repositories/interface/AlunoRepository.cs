using ApiCursos.models;


namespace ApiCursos.repositories.interfaces
{
    public interface IAlunoRepository
    {
        Task<AlunoModel> atualizarAluno(AlunoModel aluno, int RA);
        Task<CursoModels> adicionarAlunoCurso(AlunoModel aluno, CursoModels curso);
        Task<AlunoModel> buscarPorRa(int RA);
        List<AlunoModel> buscarTodos();
        Task<AlunoModel> adicionarAluno(AlunoModel aluno);
        Task<CursoModels> adicionarCurso(CursoModels curso);
        Task<bool> retirarAluno(int RA);
    }
}