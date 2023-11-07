
using System.Security.Cryptography;
using LoteriaLibrary;
using Security;

class Program
{
    static void Main()
    {
        byte[] chaveDescriptografia = null;

        while (true)
        {
            Console.WriteLine("Bem-vindo à Lotérica App");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Fazer jogos");
            Console.WriteLine("2. Descriptografar arquivo");
            Console.WriteLine("3. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Informe seu nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Informe a quantidade de dinheiro: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal dinheiro))
                    {
                        int custoPorJogo = 5;
                        int numeroDeJogos = (int)(dinheiro / custoPorJogo);

                        if (numeroDeJogos > 0)
                        {
                            Console.WriteLine($"Você pode fazer {numeroDeJogos} jogos");
                            var random = new Random();
                            var numerosSorteados = new HashSet<HashSet<int>>();
                            var resultadosJogos = new List<string>();

                            for (int i = 0; i < numeroDeJogos; i++)
                            {
                                HashSet<int> numerosSorte = Loteria.GerarNumerosSorte(random, numerosSorteados);
                                numerosSorteados.Add(numerosSorte);
                                
                                string resultadoJogo = $"Jogo {i + 1}: {string.Join(", ", numerosSorte.OrderBy(n => n))}";
                                resultadosJogos.Add(resultadoJogo);
                            }

                            Console.WriteLine("Resultados dos jogos:");
                            foreach (var resultado in resultadosJogos)
                            {
                                Console.WriteLine(resultado);
                            }

                            string pastaJogos = "Jogos";
                            Directory.CreateDirectory(pastaJogos);

                            string dataDaPasta = DateTime.Now.ToString("dd.MM.yyyy");
                            string subpastaData = Path.Combine(pastaJogos, dataDaPasta);
                            Directory.CreateDirectory(subpastaData);

                            string arquivoResultado = Path.Combine(subpastaData, $"{nome}-{Guid.NewGuid().ToString().Substring(0, 5)}-{DateTime.Now.ToString("t").Replace(":",".")}.txt");

                            // Gere a chave de criptografia
                            byte[] chaveCriptografia = GerarChaveCriptografia();

                            // Criptografar o arquivo antes de salvar
                            SecurityEncoder.CriptografarArquivo(arquivoResultado, resultadosJogos, chaveCriptografia);

                            Console.WriteLine($"Resultados dos jogos foram salvos e criptografados em: {arquivoResultado}");
                            Console.WriteLine($"Chave de criptografia gerada: {BitConverter.ToString(chaveCriptografia)}");

                            // Atribuir a chave de descriptografia após salvar o jogo
                            chaveDescriptografia = chaveCriptografia;
                        }
                        else
                        {
                            Console.WriteLine("Você não possui dinheiro suficiente para fazer jogos.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido. Por favor, insira um valor numérico válido.");
                    }

                    break;

                case "2":
                    if (chaveDescriptografia == null)
                    {
                        Console.WriteLine("Você precisa gerar uma chave de descriptografia antes de descriptografar um arquivo.");
                    }
                    else
                    {
                        Console.Write("Informe o caminho do arquivo criptografado: ");
                        string caminhoArquivoCriptografado = Console.ReadLine();

                        // Verifique se o arquivo existe
                        if (File.Exists(caminhoArquivoCriptografado))
                        {
                            Console.WriteLine("Informe a chave de descriptografia:");
                            var chaveInformada = Console.ReadLine();
                            
                            string[] arr=chaveInformada.Split('-');
                            
                            byte[] chave = new byte[arr.Length];
                            
                            for(int i=0; i<arr.Length; i++)
                                chave[i]=Convert.ToByte(arr[i],16);
                            
                            // Chame a função de descriptografia do projeto "Security"
                            string conteudoDescriptografado = SecurityDecoder.DescriptografarArquivo(caminhoArquivoCriptografado, chave);

                            if (conteudoDescriptografado.StartsWith("Ocorreu um erro ao ler e decifrar o arquivo:"))
                            {
                                Console.WriteLine(conteudoDescriptografado);
                            }
                            else
                            {
                                Console.WriteLine("Conteúdo descriptografado:");
                                Console.WriteLine(conteudoDescriptografado);
                                
                                string pastaJogos = "Jogos-Decodificados";
                                Directory.CreateDirectory(pastaJogos);

                                string dataDaPasta = DateTime.Now.ToString("dd.MM.yyyy");
                                string subpastaData = Path.Combine(pastaJogos, dataDaPasta);
                                Directory.CreateDirectory(subpastaData);

                                string arquivoResultado = Path.Combine(subpastaData,
                                    Path.GetFileName(caminhoArquivoCriptografado));
                                
                                string caminhoArquivo = "exemplo.txt";

                                using (StreamWriter writer = new StreamWriter(arquivoResultado))
                                {
                                    // Escreva a string no arquivo
                                    writer.WriteLine(conteudoDescriptografado);
                                }

                                Console.WriteLine($"{arquivoResultado} gerado com sucesso!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("O arquivo criptografado não existe.");
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Obrigado por usar a Lotérica App. Adeus!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }

    static byte[] GerarChaveCriptografia()
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            byte[] chave = new byte[32]; // Tamanho da chave (256 bits)
            rng.GetBytes(chave);
            return chave;
        }
    }
}
