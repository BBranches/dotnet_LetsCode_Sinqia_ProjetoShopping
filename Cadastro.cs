using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    class Cadastro
    {
        public static List<ILoja> lojas;
        public static List<ICliente> clientes;
        public static List<IProduto> produtos;
        public static List<IProduto> produtosComprados = new List<IProduto>();
        public static List<IAeronave> aeronaves;
        public static List<IPassagem> passagens;
        public static List<PassagemComprada> passagensCompradas;
        public static List<IPassageiro> passageiros;
        public static List<IBagagem> bagagens = new List<IBagagem>();

        Menu menu = new Menu();

        public Cadastro(List<ILoja> lojas, List<IProduto> produtos) {
            Cadastro.lojas = lojas;
            Cadastro.produtos = produtos;
        }

        public Cadastro(List<ICliente> clientes){
            Cadastro.clientes = clientes;
        }        

        public Cadastro(List<IAeronave> aeronaves, List<IPassagem> passagens, List<IPassageiro> passageiros){
            Cadastro.aeronaves = aeronaves;
            Cadastro.passageiros = passageiros;
            Cadastro.passagens = passagens;
        }

        public Cadastro(List<IPassagem> passagens, List<IPassageiro> passageiros, List<PassagemComprada> passagensCompradas){
            Cadastro.passageiros = passageiros;
            Cadastro.passagens = passagens;
            Cadastro.passagensCompradas = passagensCompradas;
        }

        public void SelectOption(int option) {            

            switch (option)
            {
                case 0:
                    menu.MenuInicial();
                    break;
                case 1:
                    CadastrarLoja();
                    menu.MenuLojas(lojas, produtos); 
                    break;
                case 2:
                    CadastrarProduto();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 3:
                    ListarLojasCadastradas();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 4: 
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
                menu.MenuShoppingAirlines(aeronaves, passagens, passageiros);
                break;
            case 1:
                CadastrarPassageiro();
                menu.MenuPassagem(aeronaves, passagens, passageiros);
                break;
            case 2:
                CadastrarPassagem();
                menu.MenuPassagem(aeronaves, passagens, passageiros);
                break;
            case 3:
                ListarPassageirosCadastrados();
                menu.MenuPassagem(aeronaves, passagens, passageiros);
                break;  
            case 4:
                ListarPassagensCadastradas();
                menu.MenuPassagem(aeronaves, passagens, passageiros);
                break;  
            default:
                Console.WriteLine("Opção incorreta, tente novamente\n");
                menu.MenuPassagem(aeronaves, passagens, passageiros);
                break;
            }
        }

        public void SelectOptionHangar(int option){
            switch(option){
                case 0:
                    menu.MenuAeroporto(aeronaves, passagens, passageiros);
                    break;
                case 1:
                    CadastrarAeronave();
                    menu.MenuHangar(aeronaves, passagens, passageiros);
                    break;
                case 2:
                    ListarAeronavesCadastradas();
                    menu.MenuHangar(aeronaves, passagens, passageiros);
                    break;
                default:
                    Console.WriteLine("Opção incorreta, tente novamente\n");
                    menu.MenuHangar(aeronaves, passagens, passageiros);
                    break;
            }

        }

        public void SelectOptionBagagem(int option){
            switch(option){
                case 0:
                    menu.MenuAeroporto(aeronaves, passagens, passageiros);
                    break;
                case 1:
                    RegistrarBagagem();
                    menu.MenuBagagem(passagens, passageiros, passagensCompradas);
                    break;
                case 2:
                    ListarBagagensRegistradas();
                    menu.MenuBagagem(passagens, passageiros, passagensCompradas);
                    break;
                default:
                    Console.WriteLine("Opção incorreta, tente novamente\n");
                    menu.MenuBagagem(passagens, passageiros, passagensCompradas);
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

        void CadastrarPassageiro() {
            string nomePassageiro = "";
            long CPF;

            do {
                    Console.Write("Digite o CPF do passageiro: ");
                    CPF = Convert.ToInt64(Console.ReadLine());

                    int indexCPF = passageiros.FindIndex(passageiro => passageiro.CPF == CPF);
                    if (indexCPF == 0)
                    {
                        Console.WriteLine("Passageiro já cadastrado. Verifique os cadastros realizados ou digite outro CPF.");
                        menu.MenuPassagem(aeronaves, passagens, passageiros);
                    }
                    else {
                        Console.Write("\nDigite o nome do passageiro a ser cadastrado: ");
                        nomePassageiro = Console.ReadLine();
                        passageiros.Add(new Passageiro(nomePassageiro, CPF));
                    }
                    Console.WriteLine("\nDeseja cadastrar outro Passageiro?");

            } while(AdicionarNovo());
        }

        void CadastrarLoja()
        {           
            string nomeLoja = "";
            string tipoLoja = "";

            Console.WriteLine("\nQual o tipo de Loja: ");
            Console.WriteLine("1 - Fast Food");
            Console.WriteLine("2 - Self Service");
            Console.WriteLine("3 - Loja Departamento");
            Console.Write("Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            
            if(opcao == 1) {
                do {
                    Console.Write("\nDigite o nome do Fast Food que deseja cadastrar: ");
                    nomeLoja = Console.ReadLine();
                    tipoLoja = "Fast Food";

                    lojas.Add(new FastFood(nomeLoja, tipoLoja));

                    Console.WriteLine("\nDeseja cadastrar outro Fast Food?");

                } while(AdicionarNovo());
                
            } else if(opcao == 2) {
                do {
                    Console.Write("\nDigite o nome do Self Service que deseja cadastrar: ");
                    nomeLoja = Console.ReadLine();
                    tipoLoja = "Self Service";

                    lojas.Add(new SelfService(nomeLoja, tipoLoja));

                    Console.WriteLine("\nDeseja cadastrar outro Self Service?");

                } while(AdicionarNovo());
                
            } else {
                do {
                    Console.Write("\nDigite o nome da loja de departamento que deseja cadastrar: ");
                    nomeLoja = Console.ReadLine();
                    tipoLoja = "Loja de Departamento";

                    lojas.Add(new LojaDepartamento(nomeLoja, tipoLoja));

                    Console.WriteLine("\nDeseja cadastrar outra loja?");

                } while(AdicionarNovo());   
            }
        }

        void CadastrarAeronave() {
            string tipoAeronave;
            int numeroAeronave;

            Console.WriteLine("\nQual o tipo de Aeronave: ");
            Console.WriteLine("1 - Jatinho");
            Console.WriteLine("2 - Helicoptero");
            Console.Write("Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            
            if(opcao == 1) {
                do {
                    Console.Write("\nDigite o número do Jatinho que deseja cadastrar: ");
                    numeroAeronave = Convert.ToInt32(Console.ReadLine());
                    tipoAeronave = "Jatinho";

                    aeronaves.Add(new Aeronave(tipoAeronave, numeroAeronave));

                    Console.WriteLine("\nDeseja cadastrar outro Jatinho?");

                } while(AdicionarNovo());
                
            } else if(opcao == 2) {
                do {
                    Console.Write("\nDigite o número do Helicoptero que deseja cadastrar: ");
                    numeroAeronave = Convert.ToInt32(Console.ReadLine());
                    tipoAeronave = "Helicoptero";

                    aeronaves.Add(new Aeronave(tipoAeronave, numeroAeronave));

                    Console.WriteLine("\nDeseja cadastrar outro Helicoptero?");

                } while(AdicionarNovo());
            }
            ListarAeronavesCadastradas();
        }

        void CadastrarPassagem() {
            long numeroAeronave;
            int numeroPassagem;
            int numeroVoo;
            string companhia;
            int numeroAssento;
            string origem;
            string destino;
            int horarioPartida;
            int horarioChegada;

            do{
                Console.Write("\nDigite o número da Aeronave: ");
                numeroAeronave = Convert.ToInt32(Console.ReadLine());

                int indexAeronave = aeronaves.FindIndex(aeronave => aeronave.NumeroAeronave == numeroAeronave);

                if (indexAeronave == -1)
                {
                    Console.WriteLine("Aeronave não disponível!");
                    menu.MenuPassagem(aeronaves, passagens, passageiros);
                }
                else {
                    var aeronaveBuscada = (from aeronave in aeronaves
                                where aeronave.NumeroAeronave == numeroAeronave
                                select aeronave).FirstOrDefault();

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
                    horarioPartida = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Digite o horário de chegada do voo: ");
                    horarioChegada = Convert.ToInt32(Console.ReadLine());

                    passagens.Add(new Passagem(numeroPassagem, numeroVoo, companhia, aeronaveBuscada.TipoAeronave, numeroAssento, origem, destino, horarioPartida, horarioChegada));

                    Console.WriteLine("\nDeseja cadastrar outra passagem?");
                }
            }while(AdicionarNovo());
        }

        void RegistrarBagagem() {
            int numeroPassagem;
            string tipoBagagem;
            int peso;

            do{
                Console.Write("\nDigite o número da passagem: ");
                numeroPassagem = Convert.ToInt32(Console.ReadLine());

                int indexPassagem = passagensCompradas.FindIndex(passagem => passagem.NumeroPassagem == numeroPassagem);
                
                if(indexPassagem == -1) {
                    Console.WriteLine("Passagem não disponível!");
                    menu.MenuPassagem(aeronaves, passagens, passageiros);
                }
                else {
                    Console.WriteLine("\nQual o tipo de Bagagem?");
                    Console.WriteLine("1 - De Mão - até 10kg");
                    Console.WriteLine("2 - Despachada - até 23kg");
                    Console.Write("Opção: ");
                    int opcao = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nQual o peso em kg da Bagagem? ");
                    peso = Convert.ToInt32(Console.ReadLine());

                    if(opcao == 1) {
                        while(peso > 10) {
                            Console.WriteLine("Peso acima do permitido, tente novamente!");
                            Console.Write("\nQual o peso em kg da Bagagem? ");
                            peso = Convert.ToInt32(Console.ReadLine());
                        }
                        tipoBagagem = "De Mão";
                    } 
                    else {
                        while(peso > 23) {
                            Console.WriteLine("Peso acima do permitido, tente novamente!");
                            Console.Write("\nQual o peso em kg da Bagagem? ");
                            peso = Convert.ToInt32(Console.ReadLine());
                        }
                        tipoBagagem = "Despachada";
                    }
                    
                    var passagemBuscada = (from passagem in passagensCompradas
                                where passagem.NumeroPassagem == numeroPassagem
                                select passagem).FirstOrDefault();
                    
                    bagagens.Add(new Bagagem(tipoBagagem, peso, passagemBuscada.NomePassageiro, passagemBuscada.NumeroPassagem));  
                }
                Console.WriteLine("\nDeseja registrar outra bagagem?");
            } while(AdicionarNovo());
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

        public static void ListarPassagensCadastradas()
        {
            foreach (IPassagem passagem in passagens)
            {
                Console.WriteLine($"\nNº da Passagem: {passagem.NumeroPassagem} - Nº do voo: {passagem.NumeroVoo} - Companhia Aérea: {passagem.Companhia} - Tipo Aeronave: {passagem.TipoAeronave} - Número do assento: {passagem.NumeroAssento}");
                Console.WriteLine($"Origem: {passagem.Origem} - Destino: {passagem.Destino} - Horário de Partida: {passagem.HorarioPartida}h - Horário de Chegada: {passagem.HorarioChegada}h");
            }
        }

        public static void ListarAeronavesCadastradas()
        {
            foreach (IAeronave aeronave in aeronaves)
            {
                Console.WriteLine($"Tipo de Aeronave: {aeronave.TipoAeronave} - Número Aeronave: {aeronave.NumeroAeronave}");
            }
        }

        public static void ListarBagagensRegistradas()
        {
            foreach (IBagagem bagagem in bagagens)
            {
                Console.WriteLine($"Tipo de Bagagem: {bagagem.TipoBagagem} - Peso: {bagagem.Peso}kg - Número Passagem: {bagagem.NumeroPassagem} - Nome Passageiro: {bagagem.NomePassageiro}");   
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

        public static void ListarLojasCadastradas()
        {
            foreach (ILoja loja in lojas)
            {
                Console.WriteLine($"Loja: {loja.Nome} - Tipo: {loja.TipoLoja}");
            }
        }

        public static void ListarClientesCadastrados()
        {
            foreach (ICliente cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome} - CPF: {cliente.CPF}");
            }
        }

        public static void ListarPassageirosCadastrados()
        {
            foreach (IPassageiro passageiro in passageiros)
            {
                Console.WriteLine($"Nome: {passageiro.NomePassageiro} - CPF: {passageiro.CPF}");
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
