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

    public CarrinhoCompra(List<ILoja> lojas, List<IProduto> produtos, List<IProduto> produtosCompradosTotal)
    {
      this.lojas = lojas;
      this.produtos = produtos;
      this.produtosCompradosTotal = produtosCompradosTotal;
    }

    public void SelectOptionProduto(int option)
    {

      switch (option)
      {
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

    void RealizarCompra()
    {
      string nomeProduto = "";

      if (Cadastro.ListarProdutosCadastrados() == 0)
      {
        Console.WriteLine("Não há produtos disponíveis.");
      }
      else
      {
        do
        {
          Console.Write("\nDigite o nome do produto: ");
          nomeProduto = Console.ReadLine();

          int indexProduto = produtos.FindIndex(produto => produto.Nome == nomeProduto);

          if (indexProduto == -1)
          {
            Console.WriteLine("Produto não disponível. Tente novamente!");
          }
          else
          {
            var produtoBuscado = (from produto in produtos
                                  where produto.Nome == nomeProduto
                                  select produto).FirstOrDefault();

            produtosComprados.Add(new Produto(nomeProduto, produtoBuscado.NomeLoja, produtoBuscado.Preco));
            produtosCompradosTotal.Add(new Produto(nomeProduto, produtoBuscado.NomeLoja, produtoBuscado.Preco));

            var lojaBuscada = (from loja in lojas
                               where loja.Nome == produtoBuscado.NomeLoja
                               select loja).FirstOrDefault();
            if (lojaBuscada.TipoLoja == "Fast Food")
            {
              FastFood fastFood = new FastFood(produtoBuscado.NomeLoja);
              fastFood.PrepararPedido(nomeProduto);
            }
            else if (lojaBuscada.TipoLoja == "Self Service")
            {
              SelfService selfService = new SelfService(produtoBuscado.NomeLoja);
              selfService.PrepararPedido(nomeProduto);
            }
            else
            {
              LojaDepartamento lojaDepartamento = new LojaDepartamento(produtoBuscado.NomeLoja);
              lojaDepartamento.ProcurarNoEstoque();
            }
          }

          Console.WriteLine("\nDeseja adicionar outro produto no carrinho?");

        } while (Cadastro.AdicionarNovo());

        ListarProdutosComprados(produtosComprados);
        Console.WriteLine("Venda realizada com sucesso!");
      }
    }

    void ListarProdutosComprados(List<IProduto> produtosComprados)
    {
      double valorProdutos = 0;
      foreach (IProduto produto in produtosComprados)
      {
        Console.WriteLine($"Loja: {produto.NomeLoja} - Produto: {produto.Nome} - Preço: R${produto.Preco}");
        valorProdutos += produto.Preco;
      }
      Console.WriteLine($"Valor total: R${valorProdutos}");
    }
  }
}
