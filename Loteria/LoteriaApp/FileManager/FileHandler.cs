namespace FileManager;

public class FileHandler
{
    public static void CriarPasta(string caminho)
    {
        try
        {
            Directory.CreateDirectory(caminho);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar a pasta: {ex.Message}");
        }
    }

    public static void CriarArquivo(string caminho, string conteudo)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine(conteudo);
            }
            Console.WriteLine($"Arquivo criado em: {caminho}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar o arquivo: {ex.Message}");
        }
    }
}