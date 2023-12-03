using Application;
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
        var cliente = new Cliente();
        var calculo = new Calculo();

        Console.WriteLine("Seu número de identificação:");
        cliente.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.Cpf = Console.ReadLine();

        Console.WriteLine("Seu saldo:");
        cliente.Saldo = float.Parse(Console.ReadLine());
        Console.Clear();

        Console.WriteLine($"Como posso ajudar {cliente.Nome}?");

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
            if (opcaoDesejada == 1)
            {
                Console.Clear();

                Console.WriteLine("Digite o valor:");
                float deposito = float.Parse(Console.ReadLine());

                cliente.Saldo = calculo.Soma(cliente.Saldo, deposito);

                Console.WriteLine($"Seu saldo atual é {cliente.Saldo}");
            }
            if (opcaoDesejada == 2)
            {
                Console.Clear();

                Console.WriteLine("Digite o valor:");
                var saque = float.Parse(Console.ReadLine());

                cliente.Saldo = calculo.Subtracao(cliente.Saldo, saque);

                Console.WriteLine($"Seu saldo atual é {cliente.Saldo}");
            }
        }

        Console.ReadKey();
        
        return cliente;
    }
}