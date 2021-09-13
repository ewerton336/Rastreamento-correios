using Correios.Pacotes.Models;
using Correios.Pacotes.Services;
using System;
using System.Collections.Generic;
using Correios.Pacotes;

namespace Correios.Pacotes.Exemplos
{
    class Program
    {
        static void Main(string[] args)
        {
            var executar = new BLL.ExecutarTarefas();
            executar.RodarTarefas();
        }
    }
}


