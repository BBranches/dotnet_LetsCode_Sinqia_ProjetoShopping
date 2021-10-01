using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class Passageiro : IPassageiro
    {
        string nomePassageiro;
        long cpf;               

        public Passageiro (string nomePassageiro, long cpf)
        {
            this.NomePassageiro = nomePassageiro;
            this.CPF = cpf;                                            
        }

        public string NomePassageiro
        {
            get { return nomePassageiro; }
            set { nomePassageiro = value; }
        }

        public long CPF
        {
            get { return cpf; }
            set { cpf = value; } 
        }    
    }
}