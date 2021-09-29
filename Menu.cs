using System;
using System.Collections.Generic;

namespace dotnet_LetsCode__Sinqia_ProjetoShopping
{
     class Menu {

        public void MenuInicial(){
            Menu menu = new Menu();
            Console.WriteLine("\n Bem vindo ao menu inicial!");
            Console.WriteLine("1 - Acessar registro de clientes");
            Console.WriteLine("2 - Acessar área de lojas");
            Console.WriteLine("0 - Fechar o programa");
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
                    menu.MenuGeral(new List<ILoja>());
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        public void MenuGeral(List<ILoja> lojas) {
            Cadastro novaLoja = new Cadastro(lojas);
            
            Console.WriteLine("\nBem vindo ao Shopping!");
            Console.WriteLine("1 - Cadastrar Loja de Departamento");
            Console.WriteLine("2 - Cadastrar Self Service");
            Console.WriteLine("3 - Cadastrar Fast Food");
            Console.WriteLine("4 - Listar Lojas Cadastradas");
            Console.WriteLine("5 - Realizar Compra");
            Console.WriteLine("0 - Sair do menu shopping e voltar ao menu inicial");
            Console.Write("Opção: ");
            novaLoja.SelectOption(Convert.ToInt32(Console.ReadLine()));
        }

        public void MenuClientes(List<ICliente> clientes){
            Cadastro novoCliente = new Cadastro(clientes);
            Console.WriteLine("\nBem vindo ao registro de clientes!");
            Console.WriteLine("1 - Cadastrar novo cliente");
            Console.WriteLine("2 - Listar clientes cadastrados");
            Console.WriteLine("3 - Remover um cliente");
            Console.WriteLine("0 - Sair do registro de clientes e voltar ao menu inicial");
            Console.Write("Opção: ");
            novoCliente.SelectOptionCliente(Convert.ToInt32(Console.ReadLine()));
        }

    }
}