using System;
using System.Collections.Generic;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
     class Menu {

        public void MenuInicial(){
            Menu menu = new Menu();
            Console.WriteLine("\nBem vindo ao Shopping!");
            Console.WriteLine("1 - Cadastro de clientes");
            Console.WriteLine("2 - Cadastro de lojas");
            Console.WriteLine("3 - Realizar compra");
            Console.WriteLine("0 - Sair do Shopping");
            Console.Write("Opção: ");

            int option = Convert.ToInt32(Console.ReadLine());
            switch(option){
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    menu.MenuClientes(new List<ICliente>());
                    break;
                case 2:
                    menu.MenuLojas(new List<ILoja>(), new List<IProduto>()); 
                    break;
                case 3:
                    menu.MenuCompra(new List<IProduto>(), new List<ILoja>());
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        public void MenuLojas(List<ILoja> lojas, List<IProduto> produtos) { 
            Cadastro novaLoja = new Cadastro(lojas, produtos); 
            
            Console.WriteLine("\nBem vindo ao Cadastro de Lojas!");
            Console.WriteLine("1 - Cadastrar Loja de Departamento");
            Console.WriteLine("2 - Cadastrar Self Service");
            Console.WriteLine("3 - Cadastrar Fast Food");
            Console.WriteLine("4 - Cadastrar produto"); 
            Console.WriteLine("5 - Listar lojas cadastradas");
            Console.WriteLine("6 - Listar produtos cadastrados"); 
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

        public void MenuCompra(List<IProduto> produtos, List<ILoja> lojas){
            Cadastro novoProduto = new Cadastro(produtos, lojas);
            Console.WriteLine("\nRealizar compras:");
            Console.WriteLine("1 - Entrar na loja e escolher produtos");
            Console.WriteLine("2 - Listar todos produtos comprados no Shopping");
            Console.WriteLine("0 - Voltar ao menu inicial do Shopping");
            Console.Write("Opção: ");
            novoProduto.SelectOptionProduto(Convert.ToInt32(Console.ReadLine()));
        }

    }
}