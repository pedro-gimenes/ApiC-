using ApiCursos.repositories.interfaces;
using ApiCursos.models;
using ApiCursos.data;
using Microsoft.EntityFrameworkCore;


namespace sistemaCadastro.repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly SistemaCursosDBContex _dbcontext;
        public AlunoRepository(SistemaCursosDBContex sistemaCursosDBContex)
        {
            _dbcontext = sistemaCursosDBContex;
        }
        public async Task<AlunoModel> adicionarAluno(AlunoModel aluno)
        {
            await _dbcontext.Alunos.AddAsync(aluno);
            await _dbcontext.SaveChangesAsync();

            return aluno;
        }

        public List<AlunoModel> buscarTodos()
        {
            return _dbcontext.Alunos.ToList();
            
        }
        public async Task<AlunoModel> buscarPorRa(int RA)
        {
            return await _dbcontext.Alunos.FirstOrDefaultAsync(x => x.RA == RA);
        }

        public async Task<CursoModels> adicionarCurso(CursoModels curso)
        {
            await _dbcontext.Cursos.AddAsync(curso);
            await _dbcontext.SaveChangesAsync();
            return curso;
        }

        public async Task<AlunoModel> atualizarAluno(AlunoModel aluno, int RA)
        {
            AlunoModel alunoPorRa = await buscarPorRa(RA);
            if(alunoPorRa == null)
            {
                throw new Exception($"Usuario para o RA: {RA} não foi encontrado");
            }
            alunoPorRa.Name = aluno.Name;
            alunoPorRa.RA = aluno.RA;

            _dbcontext.Alunos.Update(alunoPorRa);
            await _dbcontext.SaveChangesAsync();

            return alunoPorRa;
            
        }

        public async Task<CursoModels> adicionarAlunoCurso(AlunoModel aluno, CursoModels curso)
        {
            CursoModels alunoCadastradoCurso = await adicionarAluno(aluno);
            if(alunoCadastradoCurso == null)
            {
                throw new Exception($"Aluno {aluno.Name} não foi encontrado");
            }
            alunoCadastradoCurso.NomeDoCurso = curso.NomeDoCurso;
            alunoCadastradoCurso.Id = curso.Id;
            await _dbcontext.Cursos.AddAsync(curso);
            await _dbcontext.SaveChangesAsync();
            return alunoCadastradoCurso;
        }

        public async Task<bool> retirarAluno(int RA)
        {
            AlunoModel alunoPorRa = await buscarPorRa(RA);
            if(alunoPorRa == null)
            {
                throw new Exception($"Usuario para o RA: {RA} não foi encontrado");
            }

            _dbcontext.Alunos.Remove(alunoPorRa);
            await _dbcontext.SaveChangesAsync();
            return true;
    }
    }
}
