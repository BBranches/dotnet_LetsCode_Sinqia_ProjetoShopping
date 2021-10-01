using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class Passagem : IPassagem
    {
        string nomePassageiro;
        long cpf;
        int numeroPassagem;
        int numeroVoo;
        string companhia;
        int numeroAssento;
        string origem;
        string destino;
        double horarioPartida;
        double horarioChegada;        

        public Passagem (string nomePassageiro, long cpf, int numeroPassagem, int numeroVoo, string companhia, int numeroAssento, string origem, string destino, 
        double horarioPartida, double horarioChegada)
        {
            this.NomePassageiro = nomePassageiro;
            this.CPF = cpf;
            this.NumeroPassagem = numeroPassagem;
            this.NumeroVoo = numeroVoo;
            this.Companhia = companhia;
            this.NumeroAssento = numeroAssento;
            this.Origem = origem;
            this.Destino = destino;
            this.HorarioPartida = horarioPartida;
            this.HorarioChegada = horarioChegada;                                
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
        
        public int NumeroPassagem
        {
            get { return numeroPassagem; }
            set { numeroPassagem = value; }
        }

        public int NumeroVoo
        {
            get { return numeroVoo; }
            set { numeroVoo = value; }
        }

        public string Companhia
        {
            get { return companhia; }
            set { companhia = value; }
        }

        public int NumeroAssento
        {
            get { return numeroAssento; }
            set { numeroAssento = value; }
        }

        public string Origem
        {
            get { return origem; }
            set { origem = value; }
        }

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public double HorarioPartida
        {
            get { return horarioPartida; }
            set { horarioPartida = value; }
        }

        public double HorarioChegada
        {
            get { return horarioChegada; }
            set { horarioChegada = value; }
        }
        
    }
}