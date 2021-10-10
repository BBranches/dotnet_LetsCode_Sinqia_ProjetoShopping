using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class PassagemComprada : IPassagem, IPassageiro
    {
        string nomePassageiro;
        long cpf;
        int numeroPassagem;
        int numeroVoo;
        string companhia;
        string tipoAeronave;
        int numeroAssento;
        string origem;
        string destino;
        int horarioPartida;
        int horarioChegada;        

        public PassagemComprada (string nomePassageiro, long cpf, int numeroPassagem, int numeroVoo, string companhia, string tipoAeronave, int numeroAssento, string origem, string destino, int horarioPartida, int horarioChegada)
        {
            this.NomePassageiro = nomePassageiro;
            this.CPF = cpf;
            this.NumeroPassagem = numeroPassagem;
            this.NumeroVoo = numeroVoo;
            this.Companhia = companhia;
            this.TipoAeronave = tipoAeronave;
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

        public string TipoAeronave
        {
            get { return tipoAeronave; }
            set { tipoAeronave = value; }
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

        public int HorarioPartida
        {
            get { return horarioPartida; }
            set { horarioPartida = value; }
        }

        public int HorarioChegada
        {
            get { return horarioChegada; }
            set { horarioChegada = value; }
        }     
    }
}