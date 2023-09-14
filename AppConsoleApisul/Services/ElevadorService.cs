using AppConsoleApisul.Interfaces;
using AppConsoleApisul.Models;

namespace AppConsoleApisul.Services;

public class ElevadorService : IElevadorService
{
    private readonly List<UsuarioResposta> _usuariosResposta;

    public ElevadorService(List<UsuarioResposta> usuariosResposta)
    {
        _usuariosResposta = usuariosResposta;
    }

    public List<int> andarMenosUtilizado()
    {
        var contagemAndares = _usuariosResposta
            .GroupBy(g => g.andar)
            .Select(u => new { Andar = u.Key, Contagem = u.Count() })
            .OrderBy(u => u.Contagem);

        var menorContagem = contagemAndares.First().Contagem;

        var andaresMenosUtilizados = contagemAndares
            .Where(c => c.Contagem == menorContagem)
            .Select(c => c.Andar)
            .ToList();

        return andaresMenosUtilizados;
    }

    public List<char> elevadorMaisFrequentado()
    {
        var contagemElevadores = _usuariosResposta
            .GroupBy(g => g.elevador)
            .Select(e => new { Elevador = e.Key, Contagem = e.Count() })
            .OrderByDescending(e => e.Contagem);

        var maiorContagem = contagemElevadores.First().Contagem;


        var elevadoresMaisFrequentados = contagemElevadores
            .Where(e => e.Contagem == maiorContagem)
            .Select(e => e.Elevador)
            .ToList();

        return elevadoresMaisFrequentados;
    }

    public List<char> elevadorMenosFrequentado()
    {
        Dictionary<char, int> elevadorContagem = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'B', 0 },
            { 'C', 0 },
            { 'D', 0 },
            { 'E', 0 }
        };

        foreach (var usuario in _usuariosResposta)
        {
            char elevador = usuario.elevador;
            elevadorContagem[elevador]++;
        }

        int menorContagem = elevadorContagem.Min(kv => kv.Value);

        var elevadoresMenosFrequentados = elevadorContagem
            .Where(kv => kv.Value == menorContagem)
            .Select(kv => kv.Key)
            .ToList();

        return elevadoresMenosFrequentados;
    }

    public float percentualDeUsoElevadorA()
    {
        int totalServicos = _usuariosResposta.Count;
        int servicosElevadorA = _usuariosResposta.Count(u => u.elevador == 'A');

        if (totalServicos == 0)
        {
            return 0;
        }

        float percentualUsoElevadorA = (float)servicosElevadorA / totalServicos * 100;
        return percentualUsoElevadorA;
    }

    public float percentualDeUsoElevadorB()
    {
        int totalServicos = _usuariosResposta.Count;
        int servicosElevadorB = _usuariosResposta.Count(u => u.elevador == 'B');

        if (totalServicos == 0)
        {
            return 0;
        }

        float percentualUsoElevadorB = (float)servicosElevadorB / totalServicos * 100;

        return percentualUsoElevadorB;
    }

    public float percentualDeUsoElevadorC()
    {
        int totalServicos = _usuariosResposta.Count;
        int servicosElevadorC = _usuariosResposta.Count(u => u.elevador == 'C');

        if (totalServicos == 0)
        {
            return 0;
        }

        float percentualUsoElevadorC = (float)servicosElevadorC / totalServicos * 100;

        return percentualUsoElevadorC;
    }

    public float percentualDeUsoElevadorD()
    {
        int totalServicos = _usuariosResposta.Count;
        int servicosElevadorD = _usuariosResposta.Count(u => u.elevador == 'D');

        if (totalServicos == 0)
        {
            return 0;
        }

        float percentualUsoElevadorD = (float)servicosElevadorD / totalServicos * 100;

        return percentualUsoElevadorD;
    }

    public float percentualDeUsoElevadorE()
    {
        int totalServicos = _usuariosResposta.Count;
        int servicosElevadorE = _usuariosResposta.Count(u => u.elevador == 'E');

        if (totalServicos == 0)
        {
            return 0;
        }

        float percentualUsoElevadorE = (float)servicosElevadorE / totalServicos * 100;

        return percentualUsoElevadorE;
    }

    public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
    {
        var elevadoresFrequentes = elevadorMaisFrequentado();

        var dadosElevadorMaisFrequentado = _usuariosResposta
            .Where(d => elevadoresFrequentes.Contains(d.elevador))
            .ToList();

        var contagemTurno = dadosElevadorMaisFrequentado
            .GroupBy(d => d.turno)
            .Select(g => new { Turno = g.Key, Contagem = g.Count() })
            .OrderByDescending(t => t.Contagem);

        int maiorContagem = contagemTurno.First().Contagem;

        var periodosMaiorFluxo = contagemTurno
            .Where(t => t.Contagem == maiorContagem)
            .Select(t => t.Turno)
            .ToList();

        return periodosMaiorFluxo;
    }

    public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
    {
        Dictionary<char, int> periodoContagem = new Dictionary<char, int>
        {
            { 'M', 0 },
            { 'V', 0 },
            { 'N', 0 }
        };

        foreach (var usuario in _usuariosResposta)
        {
            char turno = usuario.turno;
            periodoContagem[turno]++;
        }

        int maiorContagem = periodoContagem.Max(p => p.Value);

        var periodosMaiorUtilizacao = periodoContagem
            .Where(p => p.Value == maiorContagem)
            .Select(p => p.Key)
            .ToList();

        return periodosMaiorUtilizacao;
    }

    public List<char> periodoMenorFluxoElevadorMenosFrequentado()
    {
        var elevadoresFrequentes = elevadorMaisFrequentado();

        var dadosElevadorMenosFrequentado = _usuariosResposta
            .Where(d => !elevadoresFrequentes.Contains(d.elevador))
            .ToList();

        var contagemTurno = dadosElevadorMenosFrequentado
            .GroupBy(d => d.turno)
            .Select(g => new { Turno = g.Key, Contagem = g.Count() })
            .OrderBy(t => t.Contagem);

        int menorContagem = contagemTurno.First().Contagem;

        var periodosMenorFluxo = contagemTurno
            .Where(t => t.Contagem == menorContagem)
            .Select(t => t.Turno)
            .ToList();

        return periodosMenorFluxo;
    }
}
