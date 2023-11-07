namespace LoteriaLibrary
{
    public class Loteria
    {
        public static HashSet<int> GerarNumerosSorte(Random random, HashSet<HashSet<int>> numerosSorteados)
        {
            HashSet<int> numerosSorte = new HashSet<int>();

            while (numerosSorte.Count < 6)
            {
                int numero = random.Next(1, 61);
                numerosSorte.Add(numero);
            }

            while (numerosSorteados.Contains(numerosSorte))
            {
                numerosSorte.Clear();
                while (numerosSorte.Count < 6)
                {
                    int numero = random.Next(1, 61);
                    numerosSorte.Add(numero);
                }
            }

            return numerosSorte;
        }
    }
}