using System.Globalization;
using ScreenSound04.Model;

namespace ScreenSound04.Filtros;
internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas
            .OrderBy(musica => musica.Genero)
            .Select
            (musicas => musicas.Genero)
            .Distinct()
            .ToList();

        foreach(var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistaPorGeneroMusical = musicas
            .Where(musica => musica.Genero.Contains(genero))
            .OrderBy(musica => musica.Artista)
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();

        Console.WriteLine($"Exibindo os Artistas pelo gênero musical: {genero}");
        foreach(var artista in artistaPorGeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeArtista)
    {
        var musicasDoArtista = musicas
            .Where(musica => musica.Artista.Equals(nomeArtista))
            .OrderBy(musica => musica.Nome)
            .Select(musica => musica.Nome)
            .Distinct()
            .ToList();

        Console.WriteLine($"{nomeArtista}:");
        foreach (var musicaArtista in musicasDoArtista)
        {
            Console.WriteLine($"- {musicaArtista}");
        }
    }

    public static void FiltrarMusicaPorAno(List<Musica> musicas, string ano)
    {
        var musicaPorAno = musicas
            .Where(musica => musica.Ano.Equals(ano))
            .OrderBy(musica => musica.Nome)
            .Select(musica => musica.Nome)
            .Distinct()
            .ToList();

        Console.WriteLine($"Música do Ano: {ano}");
        foreach (var m in musicaPorAno)
        {
            Console.WriteLine($"- {m}");
        }
    }

    public static void FiltrarPorTonalidade(List<Musica> musicas, int key)
    {
        var musicasPorTonalidade = musicas
            .Where(m => m.Chave == key)
            .OrderBy(m => m.Nome)
            .Select(m => m.Nome)
            .Distinct()
            .ToList();

        Console.WriteLine($"Músicas Da Key: {key}");

        foreach (var musica in musicasPorTonalidade)
        {
            Console.WriteLine($"- {musica}");
        }
    }
}