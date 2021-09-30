using System;
using System.Collections.Generic;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    class Cadastro
    {
        List<ILoja> lojas;
        List<ICliente> clientes;
        List<IProduto> produtos;

        public Cadastro(List<ILoja> lojas, List<IProduto> produtos) { // tá repetindo a linha 21??
            this.lojas = lojas;
            this.produtos = produtos;
        }

        public Cadastro(List<ICliente> clientes){
            this.clientes = clientes;
        }

        public Cadastro(List<IProduto> produtos, List<ILoja> lojas){
            this.produtos = produtos;
            this.lojas = lojas;
        }

        public void SelectOption(int option) {            
            Menu menu = new Menu();

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
            Menu menu = new Menu();

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

        public void SelectOptionProduto(int option) { 
            Menu menu = new Menu();

            switch(option){
            case 0:
                menu.MenuInicial();
                break;
            case 1:
                RealizarCompra();
                menu.MenuCompra(produtos, lojas);
                break;     
            case 2:
                ListarProdutos();
                menu.MenuCompra(produtos, lojas);
                break;
            default:
                Console.WriteLine("Opção incorreta, tente novamente\n");
                menu.MenuCompra(produtos, lojas);
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

        void RealizarCompra() {
            string nomeProduto = "";
            string nomeLoja = "";
            double preco;

            Console.WriteLine("\nQual o tipo de Loja: ");
            Console.WriteLine("1 - Fast Food");
            Console.WriteLine("2 - Self Service");
            Console.WriteLine("2 - Loja Departamento");
            Console.Write("Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nDigite o nome da Loja que a compra será realizada: ");
            nomeLoja = Console.ReadLine();
            
            do {
                Console.Write("\nDigite o nome do produto que deseja comprar: ");
                nomeProduto = Console.ReadLine();

                Console.Write("Digite o preço do produto: ");
                preco = Convert.ToDouble(Console.ReadLine());

                produtos.Add(new Produto(nomeProduto, nomeLoja, preco));
                
                if(opcao == 1) {
                    FastFood fastFood = new FastFood(nomeLoja);
                    fastFood.PrepararPedido(nomeProduto);
                } else if(opcao == 2) {
                    SelfService selfService = new SelfService(nomeLoja);
                    selfService.PrepararPedido(nomeProduto);
                } else {
                    LojaDepartamento lojaDepartamento = new LojaDepartamento(nomeLoja);
                }

                Console.WriteLine("\nDeseja adicionar outro produto no carrinho?");
                
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

        void CadastrarProduto()
        {
            Menu menu = new Menu();
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

        void ListarProdutosCadastrados()
        {
            foreach (IProduto produto in produtos)
            {
                Console.WriteLine($"Loja: {produto.NomeLoja} - Produto: {produto.Nome} - Preço: R${produto.Preco}");
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

        void ListarLojasCadastradas()
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

        void ListarProdutos()
        {
            double valorProdutos = 0;
            foreach (IProduto produto in produtos)
            { 
                Console.WriteLine($"Loja: {produto.NomeLoja} - Produto: {produto.Nome} - Preço: {produto.Preco}");
                valorProdutos += produto.Preco;
            } 
            Console.WriteLine($"Valor total: {valorProdutos}"); 
        }

        bool AdicionarNovo() {
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
