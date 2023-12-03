using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();
       
    }

    static Pessoa Identificacao()
    {
        var pessoa = new Pessoa();

        Console.WriteLine("Seu número de identificação:");
        pessoa.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();
        Console.Clear();

        Console.WriteLine($"Como posso ajudar {pessoa.Nome}?");

        var x = 1;

        while (x == 1)
        {
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1- Depósito");
            Console.WriteLine("2- Saque");
            Console.WriteLine("3- Sair");

            var opcaoDesejada = int.Parse(Console.ReadLine());

            if (opcaoDesejada == 3)
            {
                Environment.Exit(0);
            }
            if (opcaoDesejada == 1 || opcaoDesejada == 2)
            {
                Console.WriteLine("Menu");
                Environment.Exit(0);
            }
        }

        Console.ReadKey();
        
        return pessoa;
    }
}