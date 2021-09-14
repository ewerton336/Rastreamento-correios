using Correios.Pacotes.Models;
using Correios.Pacotes.Services;
using System;
using System.Collections.Generic;
using Correios.Pacotes;
using System.Threading.Tasks;
using System.Threading;

namespace Correios.Pacotes
{
    public class ObterUltimaAtualizacao
    {
        public void ObterUltima(List<string> pacotes)
        {
            while (true)
            {
             
                Rastreador rastreador = new Rastreador();

                foreach (string codigoRastreio in pacotes)
                {
                    Pacote pacote = rastreador.ObterPacote(codigoRastreio);

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(DateTime.Now.ToString() + $" @@@@@@ ÚLTIMA ATUALIZAÇÃO DO PACOTE {codigoRastreio} @@@@@@@ \n ");
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
                    
                }
                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }
    }
}
