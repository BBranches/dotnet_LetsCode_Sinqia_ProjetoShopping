using System;
using System.Collections.Generic;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
     class Menu {
        public static List<ICliente> listaCliente = new List<ICliente>();
        public static List<ILoja> listaLoja = new List<ILoja>();
        public static List<IProduto> listaProduto = new List<IProduto>();
        public static List<IProduto> produtosCompradosTotal = new List<IProduto>();
        public static List<IAeronave> listaAeronave = new List<IAeronave>();
        public static List<IPassagem> listaPassagem = new List<IPassagem>();
        public static List<IPassageiro> listaPassageiro = new List<IPassageiro>();

        public void MenuInicial(){
            Console.WriteLine("\nBem vindo ao Shopping!");
            Console.WriteLine("1 - Cadastro de clientes");
            Console.WriteLine("2 - Cadastro de lojas e produtos");
            Console.WriteLine("3 - Realizar compras nas lojas");
            Console.WriteLine("4 - Aeroporto");    
            Console.WriteLine("0 - Sair do Shopping");
            Console.Write("Opção: ");

            int option = Convert.ToInt32(Console.ReadLine());
            switch(option){
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    MenuClientes(listaCliente);
                    break;
                case 2:
                    MenuLojas(listaLoja, listaProduto); 
                    break;
                case 3:
                    MenuCompra(listaLoja, listaProduto, produtosCompradosTotal);
                    break;
                case 4:
                    MenuPassagem(listaAeronave, listaPassagem, listaPassageiro);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        public void MenuLojas(List<ILoja> lojas, List<IProduto> produtos) { 
            Cadastro novaLoja = new Cadastro(lojas, produtos); 
            
            Console.WriteLine("\nBem vindo ao Cadastro de Lojas!");
            Console.WriteLine("1 - Cadastrar Loja (Fast Food, Self Service e Departamento)");
            Console.WriteLine("2 - Cadastrar produto nas lojas"); 
            Console.WriteLine("3 - Listar lojas cadastradas");
            Console.WriteLine("4 - Listar produtos cadastrados"); 
            Console.WriteLine("0 - Voltar ao menu inicial do shopping");
            Console.Write("Opção: ");
            novaLoja.SelectOption(Convert.ToInt32(Console.ReadLine()));
        }

        public void MenuClientes(List<ICliente> clientes){
            Cadastro novoCliente = new Cadastro(clientes);
            
            Console.WriteLine("\nBem vindo ao cadastro de clientes!");
            Console.WriteLine("1 - Cadastrar novo cliente");
            Console.WriteLine("2 - Listar clientes cadastrados");
            Console.WriteLine("0 - Voltar ao menu inicial do Shopping");
            Console.Write("Opção: ");
            novoCliente.SelectOptionCliente(Convert.ToInt32(Console.ReadLine()));
        }

        public void MenuCompra(List<ILoja> lojas, List<IProduto> produtos, List<IProduto> produtosCompradosTotal){
            CarrinhoCompra novaCompra = new CarrinhoCompra(lojas, produtos, produtosCompradosTotal);
            Console.WriteLine("\nRealizar compras:");
            Console.WriteLine("1 - Comprar em uma loja");
            Console.WriteLine("2 - Listar todos produtos comprados");
            Console.WriteLine("0 - Voltar ao menu inicial do Shopping");
            Console.Write("Opção: ");
            novaCompra.SelectOptionProduto(Convert.ToInt32(Console.ReadLine()));
        }

        public void MenuPassagem(List<IAeronave> aeronaves, List<IPassagem> passagens, List<IPassageiro> passageiros){
            Cadastro novaPassagem = new Cadastro(aeronaves, passagens, passageiros);

            Console.WriteLine("\nBem vindo ao Aeroporto!");
            Console.WriteLine("1 - Cadastrar aeronave");
            Console.WriteLine("2 - Cadastrar passageiro(a)");
            Console.WriteLine("3 - Cadastrar passagem");
            Console.WriteLine("4 - Listar aeronaves cadastradas");
            Console.WriteLine("5 - Listar passageiros(as) cadastrados(as)");
            Console.WriteLine("6 - Listar passagens cadastradas");
            Console.WriteLine("7 - Comprar passagem");
            Console.WriteLine("8 - Listar passagens compradas");
            Console.WriteLine("9 - Registrar bagagem");
            Console.WriteLine("10 - Listar bagagens registradas");
            Console.WriteLine("0 - Voltar ao menu inicial do shopping");
            Console.Write("Opção: ");
            novaPassagem.SelectOptionPassagem(Convert.ToInt32(Console.ReadLine()));
        }

    }
}