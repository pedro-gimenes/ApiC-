using Microsoft.AspNetCore.Mvc;
using ApiCursos.models;
using ApiCursos.repositories.interfaces;
using ApiCursos.dto;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiCursos.controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public IActionResult AlunoIndex()
        {
            List<AlunoModel> aluno = _alunoRepository.buscarTodos();
            return View(aluno);
        }
    
        public async Task<IActionResult> adicionar(AlunoModel alunoModel)
        {
            AlunoModel aluno = await _alunoRepository.adicionarAluno(alunoModel);
            return View(aluno);
        }

        public async Task<IActionResult> editar(AlunoModel aluno, int RA)
        {
        if (ModelState.IsValid)
        {
            await _alunoRepository.atualizarAluno(aluno, RA);
            return RedirectToAction("AlunoIndex");
        }
        {
            return View(aluno);
        }
    }
        public async Task<IActionResult> apagarConfirmacao(int RA)
        {
            bool apagagado = await _alunoRepository.retirarAluno(RA);
            return View(apagagado);
        }

        [HttpGet("Buscar Alunos")]
        public ActionResult<List<AlunoModel>> buscar()
        {
            var alunos = _alunoRepository.buscarTodos();
            return  Ok(alunos);
        }

        [HttpGet("{RA}")]
        public async Task<ActionResult<AlunoModel>> buscarPorRa(int RA)
        {
            
            if (ModelState.IsValid)
            {
                await _alunoRepository.buscarPorRa(RA);
                return RedirectToAction("AlunoIndex");
            }
            return View(RA);
        }

        [HttpPost("AdicionarAluno")]
        public IActionResult adicionarAluno( AlunoModel alunoModel)
        {
            if(ModelState.IsValid)
            {
                _alunoRepository.adicionarAluno(alunoModel);
                return RedirectToAction("AlunoIndex");
            }
            return View(alunoModel);
        }
        [HttpDelete("{RA}")]
        public async Task<ActionResult<AlunoModel>> apagar(bool apagado, int RA)
        {
            if(ModelState.IsValid)
            {
            await _alunoRepository.retirarAluno(RA);
            return RedirectToAction("AlunoIndex");
            }
            return View(apagado);

        }
        [HttpPost("AdicionarCurso")]
        public async Task<ActionResult<CursoModels>> adicionarCurso([FromBody] CursoModels cursoModels)
        {
            if(ModelState.IsValid)
            {
                await _alunoRepository.adicionarCurso(cursoModels);
                return RedirectToAction("CursoIndex");
            }
            return View(cursoModels);
        }

        [HttpPut("{RA}")]
        public async Task<ActionResult<AlunoModel>> atualizarAluno([FromBody] AlunoModel alunoModel, int Ra)
        {
            if(ModelState.IsValid)
            {
            alunoModel.RA = Ra;
            await _alunoRepository.atualizarAluno(alunoModel, Ra);
            return RedirectToAction("AlunoIndex");
            }
            return View(alunoModel);
        }

        [HttpPost("AdicionarAlunoCurso")]
        public async Task<ActionResult<AlunoCursoRequest>> adicionarAlunoCurso([FromBody] AlunoCursoRequest request)
        {
            if (request == null || request.Aluno == null || request.Curso == null)
            {
                BadRequest("Dados do aluno ou do curso não podem ser nulos.");
                return RedirectToAction("CursoIndex");
        }

        try
        {
            var alunoCadastradoCurso = await _alunoRepository.adicionarAlunoCurso(request.Aluno, request.Curso);

            if (ModelState.IsValid)
            {
                await _alunoRepository.adicionarAlunoCurso(request.Aluno, request.Curso);
            }
            return View("AdicionarAlunoNoCurso", request);
        }
        catch (Exception ex)
        {
            BadRequest($"Erro ao adicionar aluno ao curso: {ex.Message}");
            return RedirectToAction("Index");
        }
        }
    }
    }

