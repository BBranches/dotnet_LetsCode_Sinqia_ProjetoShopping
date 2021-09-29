using System;
using System.Collections.Generic;

namespace dotnet_LetsCode__Sinqia_ProjetoShopping
{
     class Menu {

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
    }
}