using Application;
using Domain.Model;
using CpfCnpjLibrary;
using System.Linq;

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

        string msgIdInvalido = null;
        string msgCpfInvalido = null;
        string msgSaldoInvalido = null;
        var dadosCorretosCliente = false;

        while (!dadosCorretosCliente)
        {
            Console.WriteLine("Seu número de identificação:");
            var id = Console.ReadLine();
            var idValido = int.TryParse(id, out int numeroId);

            if (!idValido)
            {
                msgIdInvalido = "Identificador não é válido.";
            }
            else
            {
                cliente.Id = numeroId;
            }

            Console.WriteLine("Seu nome:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Seu CPF:");
            cliente.Cpf = Console.ReadLine();
            bool cpfValido = Cpf.Validar(cliente.Cpf);

            if (!cpfValido)
            {
                msgCpfInvalido = "CPF digitado não é válido.";
            }

            Console.WriteLine("Seu saldo:");
            var saldo = Console.ReadLine();
            var saldoValido = float.TryParse(saldo, out float valorSaldo);

            if (!saldoValido)
            {
                msgSaldoInvalido = "Saldo não é válido.";
            }
            else
            {
                cliente.Saldo = valorSaldo;
            }

            if (msgIdInvalido != null)
            {
                Console.WriteLine($"{msgIdInvalido}");
            }
            if (msgCpfInvalido != null)
            {
                Console.WriteLine($"{msgCpfInvalido}");
            }
            if (msgSaldoInvalido != null)
            {
                Console.WriteLine($"{msgSaldoInvalido}");
            }

            if (msgIdInvalido == null && msgCpfInvalido == null && msgSaldoInvalido == null)
            {
                dadosCorretosCliente = true;
            }

            Console.ReadKey();
            Console.Clear();
        }

        Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
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

        Console.ReadKey();

        return cliente;

    }
}