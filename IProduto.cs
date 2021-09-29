using System;
using System.Collections.Generic;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface IProduto
    {
        string Nome { get; set; }
        string NomeLoja { get; set; }
        double Preco { get; set; }
    }
}