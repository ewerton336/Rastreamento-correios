using Correios.Pacotes.Models;
using Correios.Pacotes.Services;
using System;
using System.Collections.Generic;
using Correios.Pacotes;
using Correios.Pacotes.DAO;


namespace Correios.Pacotes.BLL
{
    public class ExecutarTarefas
    {
        public void RodarTarefas()
        {
           


            #region pegar codigos de rastreio no bloco de notas e colocar no banco de dados

            /* string[] linhas = System.IO.File.ReadAllLines(@"/rastreio.txt");
                     List<string> pacotes = new List<string>();

            foreach (string linha in linhas)
            {
                try
                {
                    pacotesDao.InserirPacote(linha);
                }
                catch (Exception ex)
                {
                    Console.Write($"Erro ao inserir o pacote {linha}. Erro: {ex} ");
                    continue;
                }
            }
            */

            #endregion

            //var tudo = new ListarTodosPacotes();
            //tudo.ListarTudo(pacotes);

            var ultimo = new ObterUltimaAtualizacao();

                ultimo.ObterUltima();
 
        }
    }
}
