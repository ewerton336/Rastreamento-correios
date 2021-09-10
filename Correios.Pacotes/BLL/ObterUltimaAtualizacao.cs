using Correios.Pacotes.Models;
using Correios.Pacotes.Services;
using System;
using System.Collections.Generic;
using Correios.Pacotes;

namespace Correios.Pacotes
{
    public class ObterUltimaAtualizacao
    {
        public void ObterUltima()
        {
            Rastreador rastreador = new Rastreador();

            List<string> pacotes = new List<string> { "LE372339114SE", "LB302566998HK" };


            foreach (string codigoRastreio in pacotes)
            {
                Pacote pacote = rastreador.ObterPacote(codigoRastreio);

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"@@@@@@ ÚLTIMA ATUALIZAÇÃO DO PACOTE {codigoRastreio} @@@@@@@ \n ");
                Console.ResetColor();
                Console.WriteLine("Data - Localização - StatusCorreio - Observação");

                if (pacote.Historico[0].StatusCorreio.Contains("saiu"))
                {
                    
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($@" {pacote.Historico[0].Data} {pacote.Historico[0].Localizacao} {pacote.Historico[0].StatusCorreio} {pacote.Historico[0].Observacao}" + "\n\n");
                    Console.ResetColor();
                }
                else { 
                Console.WriteLine($@" {pacote.Historico[0].Data} {pacote.Historico[0].Localizacao} {pacote.Historico[0].StatusCorreio} {pacote.Historico[0].Observacao}" + "\n\n");
                }
            }
            Console.ReadLine();
        }
    }
}
