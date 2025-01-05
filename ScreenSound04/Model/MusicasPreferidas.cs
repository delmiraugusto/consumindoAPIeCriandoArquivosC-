using System.Text.Json;

namespace ScreenSound04.Model;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }

    public List<Musica> ListaDeMusicasFavaritas { get; }

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaDeMusicasFavaritas = new List<Musica>();
    }

    public void AdicionarMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavaritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as músicas favoritas do {Nome}\n");

        foreach (Musica m in ListaDeMusicasFavaritas)
        {
            Console.WriteLine($"- {m.Nome} do {m.Artista}");
        }
        Console.WriteLine();
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = ListaDeMusicasFavaritas,
        });
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.Json";

        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"O arquivo Json foi criado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");
    }
}
