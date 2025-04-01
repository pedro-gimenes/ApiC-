using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApiCursos.Models;
using ApiCursos.models;

namespace ApiCursos.Controllers;

public class HomeController : Controller
{


    public IActionResult Index()
    {
        AlunoModel aluno = new AlunoModel();

        aluno.Name = "Pedro";
        aluno.RA = aluno.RA;
        return View(aluno);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
