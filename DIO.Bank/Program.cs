using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos servicos.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Transferir.");
            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta de origem: ");
            string Escolha = Console.ReadLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            int indiceContaOrigem = (int.Parse(Escolha) - 1);

            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta de destino: ");
            Escolha = Console.ReadLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            int indiceContaDestino = (int.Parse(Escolha) - 1);

            Console.WriteLine();
            Console.WriteLine("Digite o valor a ser transferido: ");
            Escolha = Console.ReadLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            double valorTransferencia = (double.Parse(Escolha));

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Depositar.");
            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta: ");
            string Escolha = Console.ReadLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            int indiceConta = (int.Parse(Escolha) - 1);
            Console.WriteLine();
            Console.WriteLine("Digite o valor a ser depositado: ");
            Escolha = Console.ReadLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            double valorDeposito = (double.Parse(Escolha));

            listContas[indiceConta].Depositar(valorDeposito);
        }
        private static void Sacar()
        {   
            Console.WriteLine("Sacar.");
            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta: ");
            string Escolha = Console.ReadLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            int indiceConta = (int.Parse(Escolha) - 1);
            Console.WriteLine();
            Console.WriteLine("Digite o valor a ser sacado: ");
            Escolha = Console.ReadLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            double valorSaque = (double.Parse(Escolha));

            listContas[indiceConta].Sacar(valorSaque);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas.");
            Console.WriteLine();
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.WriteLine();
                return;
            }
            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", (i + 1));
                Console.WriteLine(conta);
            }
        }
        private static void InserirConta()
        {
            
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine();
            // Tipo Conta
            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Juridica: ");
            string Escolha = Console.ReadLine();
            Console.WriteLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                return;
            }
            int entradaTipoConta = int.Parse(Escolha);
            // Nome
            Console.WriteLine("Digite o nome do cliente: ");
            Escolha = Console.ReadLine();
            Console.WriteLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                Console.ReadLine();
                return;
            }        
            string entradaNome = Escolha;
            // Saldo
            Console.WriteLine("Digite o saldo inicial: ");
            Escolha = Console.ReadLine();
            Console.WriteLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                Console.ReadLine();
                return;
            }  
            double entradaSaldo = double.Parse(Escolha);
            // Credito
            Console.WriteLine("Digite o crédito: ");
            Escolha = Console.ReadLine();
            Console.WriteLine();
            if(Escolha.ToUpper() == "X")
            {
                Console.WriteLine();
                Console.WriteLine("Operacao cancelada.");
                Console.WriteLine();
                Console.ReadLine();
                return;
            }  
            double entradaCredito = double.Parse(Escolha);

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, Saldo: entradaSaldo, Credito: entradaCredito, Nome: entradaNome);
            listContas.Add(novaConta);
            Console.WriteLine("Conta inserida com sucesso.");
            Console.WriteLine(novaConta.ToString());

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO Bank");
            Console.WriteLine("Informe a operacao desejada: ");
            Console.WriteLine("1- Lista contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            Console.WriteLine("Dica: Durante as operacoes, digite X para cancelar.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
