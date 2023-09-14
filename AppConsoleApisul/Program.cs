using AppConsoleApisul.Models;
using AppConsoleApisul.Services;
using System.Text.Json;

try
{
    Console.WriteLine("created by: Humberto Ramone Borges Barbosa");

    var filePath = "input.json";

    if (File.Exists(filePath))
    {
        var json = File.ReadAllText(filePath);

        var listaUsuarioResposta = JsonSerializer.Deserialize<List<UsuarioResposta>>(json);
        if (listaUsuarioResposta is null) return;

        var elevadorService = new ElevadorService(listaUsuarioResposta);

        //A
        Console.WriteLine("Andares menos utilizado(s).");
        foreach (var andar in elevadorService.andarMenosUtilizado())
        {
            Console.WriteLine($"Andar: {andar}");
        }

        //B
        Console.WriteLine("Elevador mais frequentado.");
        foreach (var elevadorMaisFrequentado in elevadorService.elevadorMaisFrequentado())
        {
            Console.WriteLine($"Elevador: {elevadorMaisFrequentado}");
        }

        //B
        Console.WriteLine("Turno com o maior período de fluxo.");
        foreach (var turnoMaisFrequentado in elevadorService.periodoMaiorFluxoElevadorMaisFrequentado())
        {
            Console.WriteLine($"Turno: {turnoMaisFrequentado}");
        }

        //C
        Console.WriteLine("Elevador menos frequentado.");
        foreach (var elevadorMenosFrequentado in elevadorService.elevadorMenosFrequentado())
        {
            Console.WriteLine($"Elevador: {elevadorMenosFrequentado}");
        }

        //C
        Console.WriteLine("Turno com o menor período de fluxo.");
        foreach (var turnoMenosFrequentado in elevadorService.periodoMenorFluxoElevadorMenosFrequentado())
        {
            Console.WriteLine($"Turno: {turnoMenosFrequentado}");
        }

        //D
        Console.WriteLine("Elevadores com maior utilização.");
        foreach (var turnoMenosFrequentado in elevadorService.periodoMaiorUtilizacaoConjuntoElevadores())
        {
            Console.WriteLine($"Elevador: {turnoMenosFrequentado}");
        }

        //E
        Console.WriteLine("Percentual do Elevador A");
        Console.WriteLine($"{elevadorService.percentualDeUsoElevadorA().ToString("F2")} %");

        Console.WriteLine("Percentual do Elevador B");
        Console.WriteLine($"{elevadorService.percentualDeUsoElevadorB().ToString("F2")} %");

        Console.WriteLine("Percentual do Elevador C");
        Console.WriteLine($"{elevadorService.percentualDeUsoElevadorC().ToString("F2")} %");

        Console.WriteLine("Percentual do Elevador D");
        Console.WriteLine($"{elevadorService.percentualDeUsoElevadorD().ToString("F2")} %");

        Console.WriteLine("Percentual do Elevador E");
        Console.WriteLine($"{elevadorService.percentualDeUsoElevadorE().ToString("F2")} %");

        return;
    }

    Console.WriteLine("Arquivo não localizado.");

}
catch (Exception ex)
{
    throw new Exception(ex.Message);
}