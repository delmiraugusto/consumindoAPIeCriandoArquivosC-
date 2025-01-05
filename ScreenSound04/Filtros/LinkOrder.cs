using ScreenSound04.Model;

namespace ScreenSound04.Filtros;
internal class LinkOrder
{
    public static void ExibirListaDeArtistasOrdernados(List<Musica> musicas)
    {
        var ArtistasOrdenados = musicas
            .OrderBy(musica => musica.Artista)
            .Select(musica => musica.Artista)
            .Distinct()
            .ToList();

        Console.WriteLine("Lista de artistas ordenados");
        foreach (var artista in ArtistasOrdenados) {
            Console.WriteLine($"- {artista}");
        }
    }
}
