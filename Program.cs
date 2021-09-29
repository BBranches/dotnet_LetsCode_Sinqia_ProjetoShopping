using System;
using System.Collections.Generic;

namespace dotnet_LetsCode__Sinqia_ProjetoShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MenuGeral(new List<ILoja>());
        }
    }
}