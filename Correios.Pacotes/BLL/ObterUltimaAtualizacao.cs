using Correios.Pacotes.Models;
using Correios.Pacotes.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using Correios.Pacotes;
using System.Threading.Tasks;
using System.Threading;
using Correios.Pacotes.DAO;
namespace Correios.Pacotes
{
    public class ObterUltimaAtualizacao
    {
        public ObterUltimaAtualizacao()
            {
            crudPacotes = new CrudPacotes(Helper.DBConnectionOracle);
            }
        private readonly CrudPacotes crudPacotes;
        public void ObterUltima()
        {
            while (true)
            {
                var pacotesDao = new DAO.CrudPacotes(Helper.DBConnectionOracle);
                IEnumerable<Pacote> listaPacotes = pacotesDao.GetRastreios();
                Console.WriteLine($"Pacotes pendentes: {listaPacotes.Count()}");
                Rastreador rastreador = new Rastreador();

                foreach (Pacote codigoRastreio in listaPacotes)
                {
                    Pacote pacote = rastreador.ObterPacote(codigoRastreio.Codigo);

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(DateTime.Now.ToString() + $" @@@@@@ ÚLTIMA ATUALIZAÇÃO DO PACOTE {codigoRastreio.Codigo} @@@@@@@ \n ");
                    Console.ResetColor();
                    Console.WriteLine("Data - Localização - StatusCorreio - Observação");

                    if (pacote.Historico.Count > 0 && (pacote.Historico[0].StatusCorreio.Contains("saiu") || pacote.Historico[0].StatusCorreio.Contains("retirada")))
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($@" {pacote.Historico[0].Data} {pacote.Historico[0].Localizacao} {pacote.Historico[0].StatusCorreio} {pacote.Historico[0].Observacao}" + "\n\n");
                        Console.ResetColor();
                    }
                    else if (pacote.Historico.Count > 0)
                    {
                        Console.WriteLine($@" {pacote.Historico[0].Data} {pacote.Historico[0].Localizacao} {pacote.Historico[0].StatusCorreio} {pacote.Historico[0].Observacao}" + "\n\n");
                    }
                    if (pacote.Historico.Count > 0 && (pacote.Historico[0].StatusCorreio.Contains("entregue ao destinatário")))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($@" {pacote.Historico[0].Data} {pacote.Historico[0].Localizacao} {pacote.Historico[0].StatusCorreio} {pacote.Historico[0].Observacao}" + "\n\n");
                        Console.WriteLine("Pedido Entregue. Encerrando pendência de rastreamento.");
                        Console.ResetColor();
                        crudPacotes.EncerrarPacoteEntregue(codigoRastreio.ID);
                    }


                }
                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }
    }
}
