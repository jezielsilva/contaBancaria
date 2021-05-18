using System;
using System.Collections.Generic;

namespace contaBancaria
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            int opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != 6)
            {
                switch (opcaoUsuario)
                {
                    case 1:
                        ListarContas();
                        break;
                    case 2:
                        InserirConta();
                        break;
                    case 3:
                        TransferenciaParaOutraConta();
                        break;
                    case 4:
                        Sacar();
                        break;;
                    case 5:
                        Depositar();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Volte Sempre !!!");            
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            
            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void TransferenciaParaOutraConta()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o numero da Conta Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine(">>> Inserir Nova Conta <<<");
            Console.WriteLine("Digite 1 para Conta Física e 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o nome do Cliente: ");
            string nomeCliente = Console.ReadLine();
            
            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor do Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                nome: nomeCliente,
                credito :entradaCredito,
                saldo: entradaSaldo,
                tipoConta: (TipoConta)entradaTipoConta
                );
            listContas.Add(novaConta);
            Console.WriteLine("Conta criada com sucesso !!!");
        }

        private static void ListarContas()
        {
            Console.WriteLine("Contas: ");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada !!!");
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static int ObterOpcaoUsuario()
        {
            Console.WriteLine(">>> - Banco Black - <<<");
            Console.WriteLine("Escolha a opção desejada: ");
            Console.WriteLine(" ");
            Console.WriteLine("1- Listar todas as Contas");
            Console.WriteLine("2- Inserir Nova Conta");
            Console.WriteLine("3- Tranferência");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Fechar Aplicação");

            int opcaoUsuario = int.Parse(Console.ReadLine());
            return opcaoUsuario;
        }
    }
}