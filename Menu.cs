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
        public static List<PassagemComprada> listaPassagensCompradas = new List<PassagemComprada>();

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
                    MenuAeroporto(listaAeronave, listaPassagem, listaPassageiro);
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

            Console.WriteLine("\nRealizar compras no Shopping:");
            Console.WriteLine("1 - Comprar em uma loja");
            Console.WriteLine("2 - Listar todos produtos comprados");
            Console.WriteLine("0 - Voltar ao menu inicial do Shopping");
            Console.Write("Opção: ");
            novaCompra.SelectOptionProduto(Convert.ToInt32(Console.ReadLine()));
        }

        public void MenuAeroporto(List<IAeronave> aeronaves, List<IPassagem> passagens, List<IPassageiro> passageiros){
            Console.WriteLine("\nBem vindos ao Aeroporto!");
            Console.WriteLine("1 - Hangar");
            Console.WriteLine("2 - Companhia aérea");
            Console.WriteLine("0 - Voltar ao menu inicial do Shopping");
            Console.Write("Opção: ");

            int option = Convert.ToInt32(Console.ReadLine());
            switch(option){
                case 0:
                    MenuInicial();
                    break;
                case 1:
                    MenuHangar(listaAeronave, listaPassagem, listaPassageiro);
                    break;
                case 2:
                    MenuShoppingAirlines(listaAeronave, listaPassagem, listaPassageiro);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    MenuAeroporto(listaAeronave, listaPassagem, listaPassageiro);
                    break;
            }
        }

        public void MenuShoppingAirlines(List<IAeronave> aeronaves, List<IPassagem> passagens, List<IPassageiro> passageiros){
            Console.WriteLine("\nBem vindos a Shopping Airlines!");
            Console.WriteLine("1 - Cadastro de passageiros e passagens");
            Console.WriteLine("2 - Comprar Passagens");
            Console.WriteLine("3 - Registro de bagagens");
            Console.WriteLine("0 - Voltar ao menu inicial do Aeroporto");
            Console.Write("Opção: ");

            int option = Convert.ToInt32(Console.ReadLine());
            switch(option){

                case 0:
                    MenuAeroporto(listaAeronave, listaPassagem, listaPassageiro);
                    break;
                case 1:
                    MenuPassagem(listaAeronave, listaPassagem, listaPassageiro);
                    break;
                case 2:
                    MenuCompraPassagem(listaPassagem, listaPassageiro, listaAeronave, listaPassagensCompradas);
                    break;
                case 3:
                    MenuBagagem(listaPassagem, listaPassageiro, listaPassagensCompradas);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    MenuShoppingAirlines(listaAeronave, listaPassagem, listaPassageiro);
                    break;
            }
        }

        public void MenuPassagem(List<IAeronave> aeronaves, List<IPassagem> passagens, List<IPassageiro> passageiros){
            Cadastro novaPassagem = new Cadastro(aeronaves, passagens, passageiros);

            Console.WriteLine("\nBem vindo ao Cadastro de Passageiros e Passagens!");
            Console.WriteLine("1 - Cadastrar passageiro(a)");
            Console.WriteLine("2 - Cadastrar passagem");
            Console.WriteLine("3 - Listar passageiros(as) cadastrados(as)");
            Console.WriteLine("4 - Listar passagens cadastradas");
            Console.WriteLine("0 - Voltar ao menu inicial da Shopping Airlines");
            Console.Write("Opção: ");
            novaPassagem.SelectOptionPassagem(Convert.ToInt32(Console.ReadLine()));
        }


        public void MenuHangar(List<IAeronave> aeronaves, List<IPassagem> passagens, List<IPassageiro> passageiros){
            Cadastro novoHangar = new Cadastro(aeronaves, passagens, passageiros);

            Console.WriteLine("\nBem vindo ao Cadastro de aeronaves!");
            Console.WriteLine("1 - Cadastrar aeronave");
            Console.WriteLine("2 - Listar aeronaves cadastradas");
            Console.WriteLine("0 - Voltar ao menu inicial do aeroporto");
            Console.Write("Opção: ");
            novoHangar.SelectOptionHangar(Convert.ToInt32(Console.ReadLine()));
        }

        public void MenuBagagem(List<IPassagem> passagens, List<IPassageiro> passageiros, List<PassagemComprada> passagensCompradas){
            Cadastro novaBagagem = new Cadastro(passagens, passageiros, passagensCompradas);

            Console.WriteLine("\nBem vindo ao Registro de bagagens!");
            Console.WriteLine("1 - Registrar bagagem");
            Console.WriteLine("2 - Listar bagagens registradas");
            Console.WriteLine("0 - Voltar ao menu inicial da Shopping Airlines");
            Console.Write("Opção: ");
            novaBagagem.SelectOptionBagagem(Convert.ToInt32(Console.ReadLine()));
        }

        public void MenuCompraPassagem(List<IPassagem> passagens, List<IPassageiro> passageiros, List<IAeronave> aeronaves, List<PassagemComprada> passagensCompradas){
            CarrinhoPassagem novaCompraPassagem = new CarrinhoPassagem(passagens, passageiros, aeronaves, passagensCompradas);

            Console.WriteLine("\nBem vindo à área de compra de passagens da Shopping Airlines!");
            Console.WriteLine("1 - Comprar passagem");
            Console.WriteLine("2 - Listar passagens compradas");
            Console.WriteLine("0 - Voltar ao menu inicial da Shopping Airlines");
            Console.Write("Opção: ");
            novaCompraPassagem.SelectOptionComprarPassagem(Convert.ToInt32(Console.ReadLine()));
        }
    }
}