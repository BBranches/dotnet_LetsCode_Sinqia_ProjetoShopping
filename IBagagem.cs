using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping 
{
    public interface IBagagem
    {
        string TipoBagagem { get; set; }
        double Peso { get; set; }
    }
}