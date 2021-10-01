using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    class CarrinhoCompra
    {
        List<ILoja> lojas;
        List<IProduto> produtos;
        List<IProduto> produtosCompradosTotal;
        List<IProduto> produtosComprados = new List<IProduto>();

        Menu menu = new Menu();

        public CarrinhoCompra(List<ILoja> lojas, List<IProduto> produtos, List<IProduto> produtosCompradosTotal) {
            this.lojas = lojas;
            this.produtos = produtos;
            this.produtosCompradosTotal = produtosCompradosTotal;
        }

        public void SelectOptionProduto(int option) { 

            switch(option){
            case 0:
                menu.MenuInicial();
                break;
            case 1:
                RealizarCompra();
                menu.MenuCompra(lojas, produtos, produtosCompradosTotal);
                break;     
            case 2:
                ListarProdutosComprados(produtosCompradosTotal);
                menu.MenuCompra(lojas, produtos, produtosCompradosTotal);
                break;
            default:
                Console.WriteLine("Opção incorreta, tente novamente\n");
                menu.MenuCompra(lojas, produtos, produtosCompradosTotal);
                break;
            }    
        }
      
        void RealizarCompra() {
            string nomeProduto = "";

            if(Cadastro.ListarProdutosCadastrados() == 0) {
                Console.WriteLine("Não há produtos disponíveis.");
            } 
            else {

            // Console.WriteLine("\nQual o tipo de Loja: ");
            // Console.WriteLine("1 - Fast Food");
            // Console.WriteLine("2 - Self Service");
            // Console.WriteLine("3 - Loja Departamento");
            // Console.Write("Opção: ");
            // int opcao = Convert.ToInt32(Console.ReadLine());

                do {
                    Console.Write("\nDigite o nome do produto: ");
                    nomeProduto = Console.ReadLine();

                    int indexProduto = produtos.FindIndex(produto => produto.Nome == nomeProduto);

                    if (indexProduto == -1)
                    {
                        Console.WriteLine("Produto não disponível. Tente novamente!");
                    } 
                    else {
                        var resultado = (from produto in produtos
                                        where produto.Nome == nomeProduto
                                        select produto).FirstOrDefault();

                        produtosComprados.Add(new Produto(nomeProduto, resultado.NomeLoja, resultado.Preco));
                        produtosCompradosTotal.Add(new Produto(nomeProduto, resultado.NomeLoja, resultado.Preco));
                    }

                    

                        // if(opcao == 1) {
                        //     FastFood fastFood = new FastFood(nomeLoja);
                        //     fastFood.PrepararPedido(nomeProduto);
                        // } else if(opcao == 2) {
                        //     SelfService selfService = new SelfService(nomeLoja);
                        //     selfService.PrepararPedido(nomeProduto);
                        // } else {
                        //     LojaDepartamento lojaDepartamento = new LojaDepartamento(nomeLoja);
                        // }
                
                        Console.WriteLine("\nDeseja adicionar outro produto no carrinho?");

                } while(Cadastro.AdicionarNovo());
                
                ListarProdutosComprados(produtosComprados);
            }
        }

        void ListarProdutosComprados(List<IProduto> produtosComprados)
        {
            double valorProdutos = 0;
            foreach (IProduto produto in produtosComprados)
            { 
                Console.WriteLine($"Loja: {produto.NomeLoja} - Produto: {produto.Nome} - Preço: {produto.Preco}");
                valorProdutos += produto.Preco;
            } 
            Console.WriteLine($"Valor total: {valorProdutos}"); 
        }
    }
}
