using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class Bagagem : IBagagem
    {
        private string tipoBagagem;
        private int peso;
        private string nomePassageiro;
        private int numeroPassagem;
        
        public Bagagem(string tipoBagagem, int peso, string nomePassageiro, int numeroPassagem)
        {
            this.TipoBagagem = tipoBagagem;
            this.Peso = peso;
            this.NomePassageiro = nomePassageiro;
            this.NumeroPassagem = numeroPassagem;
        }

        public int Peso {
            get => peso;
            set {
                peso = value;
            }
        }

        public string TipoBagagem {
            get => tipoBagagem;
            set {
                tipoBagagem = value;
            }
        } 

        public string NomePassageiro
        {
            get { return nomePassageiro; }
            set { nomePassageiro = value; }
        } 

        public int NumeroPassagem
        {
            get { return numeroPassagem; }
            set { numeroPassagem = value; }
        }     
    }
}