using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface IPassagem
    {
        string NomePassageiro { get; set; }
        long CPF { get; set; }        
        int NumeroPassagem { get; set; }
        int NumeroVoo { get; set; }
        string Companhia { get; set; }
        int NumeroAssento { get; set; }
        string Origem { get; set; }
        string Destino { get; set; }
        double HorarioPartida { get; set; }
        double HorarioChegada { get; set; }        
    }
}