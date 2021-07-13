using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using App.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception("Deu ruim");
            return View();
        }

        [ClaimsAuthorize("Home","PodeTestar")]
        //[Authorize(Roles = "Admin,Manager")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretExcluir()
        {
            return View();
        }

        [Authorize(Policy = "PodeLer")]
        public IActionResult Exibir()
        {
            return View();
        }

        [Route("/Error/{statusCode:int:minlength(3):maxlength(3)}")]
        public IActionResult Error(int statusCode)
        {
            var errorModel = new ErrorViewModel
            {
                StatusCode = statusCode
            };

            if (statusCode >= 500)
            {
                errorModel.Titulo = "Erro =(";
                errorModel.Mensagem = "Desculpe, houve um erro!\nNossa equipe foi avisada e resolveremos o mais rápido possível!";
            } else if (statusCode == 403)
            {
                errorModel.Titulo = "Sem acesso";
                errorModel.Mensagem = "Por favor, verifique se o usuário logado tem permissão de acesso à este recurso!";
            } else if (statusCode == 404)
            {
                errorModel.Titulo = "Página não encontrada";
                errorModel.Mensagem = "Oops, a página solicitada não foi encontrada!";
            }
            else
            {
                errorModel.Titulo = "Erro =(";
                errorModel.Mensagem = "Algo deu errado!";
            }

            return View("Error", errorModel);
        }
    }
}
