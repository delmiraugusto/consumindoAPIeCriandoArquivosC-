using System.Text.Json;
using ScreenSound04.Model;
using ScreenSound04.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        //musicas[0].ExibirDetalhesDaMusica();
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinkOrder.ExibirListaDeArtistasOrdernados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "pop");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "Billie Eilish");
        //LinqFilter.FiltrarMusicaPorAno(musicas, "2014");
        LinqFilter.FiltrarPorTonalidade(musicas, 1);


        var musicasPreferidasDoDelmir = new MusicasPreferidas("Delmir");

        musicasPreferidasDoDelmir.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoDelmir.AdicionarMusicasFavoritas(musicas[10]);
        musicasPreferidasDoDelmir.AdicionarMusicasFavoritas(musicas[100]);
        musicasPreferidasDoDelmir.AdicionarMusicasFavoritas(musicas[144]);
        musicasPreferidasDoDelmir.AdicionarMusicasFavoritas(musicas[177]);

        musicasPreferidasDoDelmir.ExibirMusicasFavoritas();

        musicasPreferidasDoDelmir.GerarArquivoJson();

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}