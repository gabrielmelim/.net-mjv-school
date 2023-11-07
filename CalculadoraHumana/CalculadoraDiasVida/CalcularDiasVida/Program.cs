using System.Globalization;

Console.Write("Digite seu nome: ");
string nome = Console.ReadLine();

DateTime dataNascimento;

do
{
    Console.Write("Digite sua data de nascimento (no formato DD/MM/YYYY): ");
} while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, DateTimeStyles.None, out dataNascimento));

DateTime data100Anos = dataNascimento.AddYears(100);

int anoMorte = dataNascimento.Year + 100;
int mesMorte = dataNascimento.Month;
int diaMorte = dataNascimento.Day;

if (data100Anos <= DateTime.Now)
{
    Console.WriteLine("Você já atingiu 100 anos!");
}
else
{
    Console.WriteLine($"Olá, {nome}! Você atingirá 100 anos em {diaMorte}/{mesMorte}/{anoMorte}.");
    TimeSpan tempoRestante = data100Anos - DateTime.Now;
    int diasRestantes = tempoRestante.Days;
    Console.WriteLine($"Faltam {diasRestantes} dias para você atingir 100 anos.");
}