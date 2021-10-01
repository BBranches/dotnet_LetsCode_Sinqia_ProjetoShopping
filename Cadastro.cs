using System;
using System.Collections.Generic;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    class Cadastro
    {
        public static List<ILoja> lojas;
        List<ICliente> clientes;
        public static List<IProduto> produtos;
        List<IProduto> produtosComprados = new List<IProduto>();
        List<IPassagem> passagens;

        Menu menu = new Menu();

        public Cadastro(List<ILoja> lojas, List<IProduto> produtos) {
            Cadastro.lojas = lojas;
            Cadastro.produtos = produtos;
        }

        public Cadastro(List<ICliente> clientes){
            this.clientes = clientes;
        }

        public Cadastro(List<IPassagem> passagens){
            this.passagens = passagens;
        }

        public void SelectOption(int option) {            

            switch (option)
            {
                case 0:
                    menu.MenuInicial();
                    break;
                case 1:
                    CadastrarLojaDepartamento();
                    menu.MenuLojas(lojas, produtos); 
                    break;
                case 2:
                    CadastrarSelfService();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 3:
                    CadastrarFastFood();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 4: 
                    CadastrarProduto();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 5:
                    ListarLojasCadastradas();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 6: 
                    ListarProdutosCadastrados();
                    menu.MenuLojas(lojas, produtos);
                    break;
                default:
                    Console.WriteLine("Opção incorreta, tente novamente\n");
                    menu.MenuLojas(lojas, produtos);
                    break;
            }
        }

        public void SelectOptionCliente(int option) { 

            switch(option){
            case 0:
                menu.MenuInicial();
                break;
            case 1:
                CadastrarCliente();
                menu.MenuClientes(clientes);
                break;  
            case 2:
                ListarClientesCadastrados();
                menu.MenuClientes(clientes);
                break;
            default:
                Console.WriteLine("Opção incorreta, tente novamente\n");
                menu.MenuClientes(clientes);
                break;
            }    
        }

        public void SelectOptionPassagem(int option){
            
            switch(option){
            case 0:
                menu.MenuInicial();
                break;
            case 1:
                CadastrarPassagem();
                menu.MenuPassagem(passagens);
                break;
            case 2:
                ListarPassagensCadastradas();
                menu.MenuPassagem(passagens);
                break;
            default:
                Console.WriteLine("Opção incorreta, tente novamente\n");
                menu.MenuPassagem(passagens);
                break;
            }
        }
      
        void CadastrarCliente() {
            string nomeCliente = "";
            long CPF;

            do {
                Console.Write("\nDigite o nome do cliente a ser cadastrado: ");
                nomeCliente = Console.ReadLine();

                Console.Write("Digite o CPF do cliente: ");
                CPF = Convert.ToInt64(Console.ReadLine());
                clientes.Add(new Cliente(CPF, nomeCliente));

                Console.WriteLine("\nDeseja cadastrar outro Cliente?");

            } while(AdicionarNovo());
        }

        void CadastrarLojaDepartamento()
        {           
            string nomeLoja = "";
            double aluguelLoja;

            do {
                Console.Write("\nDigite o nome da loja de departamento que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();

                Console.Write("Digite o valor do aluguel da loja de departamento: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());

                lojas.Add(new LojaDepartamento(nomeLoja, aluguelLoja));
                
                Console.WriteLine("\nDeseja cadastrar outra loja?");

            } while(AdicionarNovo());
        }

        void CadastrarPassagem(){
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

            do{
                Console.Write("\nDigite o nome do(a) passageiro(a): ");
                nomePassageiro = Console.ReadLine();

                Console.Write("Digite o CPF do(a) passageiro(a): ");
                cpf = Convert.ToInt64(Console.ReadLine());

                int indexCPF = passagens.FindIndex(passagem => passagem.CPF == cpf);
                if (indexCPF == 0)
                {
                    Console.WriteLine("Passageiro já cadastrado. Verifique os cadastros realizados ou digite outro CPF.");
                    menu.MenuPassagem(passagens);
                }

                else
                {
                    Console.Write("Digite o número da passagem (com até 10 algarismos): ");
                    numeroPassagem = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite o número do voo: ");
                    numeroVoo = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite o nome da companhia aérea: ");
                    companhia = Console.ReadLine();

                    Console.Write("Digite o número do assento: ");
                    numeroAssento = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite a origem do voo (se estiver partindo do Shopping, digitar \"Shopping\"): ");
                    origem = Console.ReadLine();

                    Console.Write("Digite o destino do voo (se o destino for o Shopping, digitar \"Shopping\"): ");
                    destino = Console.ReadLine();

                    Console.Write("Digite o horário de partida do voo: ");
                    horarioPartida = Double.Parse(Console.ReadLine());

                    Console.Write("Digite o horário de chegada do voo: ");
                    horarioChegada = Double.Parse(Console.ReadLine());

                    passagens.Add(new Passagem(nomePassageiro, cpf, numeroPassagem, numeroVoo, companhia, numeroAssento, origem, destino, horarioPartida, horarioChegada));

                    Console.WriteLine("\nDeseja cadastrar novo(a) passageiro(a)");
                }
            }while(AdicionarNovo());
        }

        void CadastrarProduto()
        {
            string nomeLoja;
            string nomeProduto;
            double preco;

            do
            {
                    Console.Write("\nDigite o nome da loja em que será cadastrado o produto: ");
                    nomeLoja = Console.ReadLine();

                    int indexLoja = lojas.FindIndex(loja => loja.Nome == nomeLoja);

                    if (indexLoja == -1)
                    {
                        Console.WriteLine("Loja não encontrada. Tente novamente ou cadastre a loja.");
                        menu.MenuLojas(lojas,produtos); 
                    }

                    else
                    {
                        Console.Write("Digite o nome do produto: ");
                        nomeProduto = Console.ReadLine();

                        Console.Write("Digite o preço do produto: ");
                        preco = Convert.ToDouble(Console.ReadLine());
                        produtos.Add(new Produto(nomeProduto, nomeLoja, preco));

                        Console.WriteLine("\n Deseja cadastrar um novo produto?");
                    }
            }while (AdicionarNovo());
        }

        void ListarPassagensCadastradas()
        {
            foreach (IPassagem passagem in passagens)
            {
                Console.WriteLine($"Passageiro(a): {passagem.NomePassageiro} - CPF: {passagem.CPF} - Nº de Passagem: {passagem.NumeroPassagem}");
                Console.WriteLine($"Nº do voo: {passagem.NumeroVoo} - Companhia Aérea: {passagem.Companhia} - Número do assento: {passagem.NumeroAssento}");
                Console.WriteLine($"Origem: {passagem.Origem} - Destino: {passagem.Destino} - Horário de Partida: {passagem.HorarioPartida} - horario de Chegada: {passagem.HorarioChegada}");
            }
        }

        public static int ListarProdutosCadastrados()
        {
            if(produtos == null) {
                return 0;
            } 
            else {
                foreach (IProduto produto in produtos)
                {
                    Console.WriteLine($"Loja: {produto.NomeLoja} - Produto: {produto.Nome} - Preço: R${produto.Preco}");
                }
                return 1;
            }     
        }

        void CadastrarFastFood()
        {           
            string nomeLoja = "";
            double aluguelLoja;

            do {
                Console.Write("\nDigite o nome do FastFood que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();

                Console.Write("Digite o valor do aluguel do FastFood: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());

                lojas.Add(new FastFood(nomeLoja, aluguelLoja));
                
                Console.WriteLine("\nDeseja cadastrar outro FastFood?");

            } while(AdicionarNovo());
        }

        void CadastrarSelfService()
        {           
            string nomeLoja = "";
            double aluguelLoja;

            do {
                Console.Write("\nDigite o nome do Self Service que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();
                
                Console.Write("Digite o valor do aluguel do Self Service: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());

                lojas.Add(new SelfService(nomeLoja, aluguelLoja));
                
                Console.WriteLine("\nDeseja cadastrar outro Self Service?");

            } while(AdicionarNovo());
        }

        public static void ListarLojasCadastradas()
        {
            foreach (ILoja loja in lojas)
            {
                Console.WriteLine($"Loja: {loja.Nome} - Aluguel: {loja.Aluguel}");
            }
        }

        void ListarClientesCadastrados()
        {
            foreach (ICliente cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome} - CPF: {cliente.CPF}");
            }
        }

        public static bool AdicionarNovo() {
            bool adicionar = false;

            Console.WriteLine("1 - Sim ");
            Console.WriteLine("2 - Não ");
            Console.Write("Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao) {
                case 1:
                    adicionar = true;
                    break;
                case 2: 
                    adicionar = false;
                    break;
                default:
                    Console.WriteLine("Opção Invalida, não haverá novo cadastro");
                    adicionar = false;
                    break;
            }       
            return adicionar;
        }
    }
}
