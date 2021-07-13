using System;
using Microsoft.Extensions.Primitives;

namespace App.Models
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
    }
}
