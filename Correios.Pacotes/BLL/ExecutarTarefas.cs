using Correios.Pacotes.Models;
using Correios.Pacotes.Services;
using System;
using System.Collections.Generic;
using Correios.Pacotes;
using Correios.Pacotes.DAO;
using Correios.Pacotes.Models;


namespace Correios.Pacotes.BLL
{
    public class ExecutarTarefas
    {
        public void RodarTarefas()
        {

            string[] linhas = System.IO.File.ReadAllLines(@"/rastreio.txt");

            var pacotesDao = new DAO.CrudPacotes(Helper.DBConnectionOracle);

            List<string> pacotes = new List<string>();

            foreach (string linha in linhas)
            {
                pacotesDao.InserirPacote(linha);
            }


            var listaPacotes = pacotesDao.GetRastreios();

            //var tudo = new ListarTodosPacotes();
            //tudo.ListarTudo(pacotes);

            var ultimo = new ObterUltimaAtualizacao();
            ultimo.ObterUltima(pacotes);
        }
    }
}
