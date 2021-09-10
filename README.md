# Correios.Pacotes
![alt text](https://i.imgur.com/Mlst3gD.png)




Obtenha informações dos seus pacotes ou encomendas dos correios brasileiros.

 
###### Este componente funciona com Qualquer Plataforma .Net.

* .NET Framework 4.6.1 +
* .NET Core
* Xamarin
* Xamarin.Forms


**NuGet**

|Name|Info|
| ------------------- | :------------------: |
|Correios.Pacotes|[![NuGet](https://buildstats.info/nuget/Correios.Pacotes)](https://www.nuget.org/packages/Correios.Pacotes/)|


Exemplo

```csharp

 namespace Correios.Pacotes
{
    public class ListarTodosPacotes
    {
        public void ListarTudo()
        {
            Rastreador rastreador = new Rastreador();

            List<string> pacotes = new List<string> { "LE372339114SE", "LB302566998HK", "LE374432695SE", "LE374813610SE", "LE375761255SE", "LE375757653SE" };

            foreach (string item in pacotes)
            {
                Pacote pacote = rastreador.ObterPacote(item);

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"@@@@@@ RASTREIO DO PACOTE {item} @@@@@@@ \n");
                Console.ResetColor();

                Console.WriteLine("Data - Localização - StatusCorreio - Observação");
                foreach (Status status in pacote?.Historico)
                {
                    if (status.StatusCorreio.ToString().Contains("saiu"))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($@" {status.Data} {status.Localizacao} {status.StatusCorreio} {status.Observacao}");
                        Console.ResetColor();
                    }
                    else
                    {

                        Console.WriteLine($@" {status.Data} {status.Localizacao} {status.StatusCorreio} {status.Observacao}");
                    }
                    Console.WriteLine("###############################################################");
                }
                Console.WriteLine("\n \n");
            }
            Console.ReadLine();
        }
    }
}

```

