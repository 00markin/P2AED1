using System;
using System.Collections.Generic;
using System.IO;

class Carrinho{
	public List<string> nome = new List<string>();
	public List<int> qtd = new List<int>();
	public List<double> prc = new List<double>();
	public List<int> indexA = new List<int>();


	public Carrinho menuCarrinho(List<Produto> Prds, Carrinho cart, Produto prd){
		int op = 0;
    	Console.WriteLine ("   _");
		Console.WriteLine ("    \\________");
		Console.WriteLine (" ~   \\######/       ");
		Console.WriteLine (" ~    |____.         ");
		Console.WriteLine ("______o____o_________");
		Console.WriteLine ("                      \\_______");
    	while(op!= 3){
    		Console.WriteLine ("Selecione a opção desejada escrevendo apenas o número:");
    		Console.WriteLine ("------------------------------");
    		Console.WriteLine ("1 - ADICIONAR PRODUTO AO CARRINHO");
		    Console.WriteLine ("2 - REMOVER PRODUTO DO CARRINHO");
		    Console.WriteLine ("3 - RETORNAR AO MENU INICIAL");
		    Console.WriteLine ("------------------------------");
		    op = int.Parse(Console.ReadLine());
		    switch(op){
		      case 1:
		      Console.Clear();
		      cart = addCarrinho(Prds, cart, prd);
		      break;
		      case 2:
		      Console.Clear();
		      cart = removeCarrinho(cart);
		      break;
		      case 3:
		      Console.Clear();
		      break;
		      default:
		      Console.Clear();
		      Console.WriteLine("Opção inválida, tente novamente:");
		      break;
		    }
		}
		return cart;
	}
  	

  	public Carrinho addCarrinho(List<Produto> Prds, Carrinho cart, Produto prd){
  		int prodAdd;
  		int qtdAdd;
  		prd.listarProdutos(Prds);
  		Console.WriteLine ("Digite o número anterior ao nome do produto para adicioná-lo ao seu carrinho");
  		prodAdd = int.Parse(Console.ReadLine());
  		Console.WriteLine ("Digite a quantidade");
  		qtdAdd = int.Parse(Console.ReadLine());
  		while(qtdAdd > Prds[prodAdd].qtd){
  			Console.WriteLine ("Quantidade inviável, digite nova quantidade");
  			qtdAdd = int.Parse(Console.ReadLine());
  		}
  		cart.nome.Add(Prds[prodAdd].desc);
  		cart.qtd.Add(qtdAdd);
  		cart.prc.Add(Prds[prodAdd].prc);
  		cart.indexA.Add(prodAdd);

  		return cart;
  	}


  	public Carrinho removeCarrinho(Carrinho cart){
  		Console.WriteLine ("-------------------------------------");
	    int prodRemov;
	    int i = 0;
        foreach(string nome in cart.nome){
        	Console.WriteLine (i +"-" + nome + "    " + cart.qtd + "    R$"+cart.prc);
        	i++;
        }
        Console.WriteLine ("-------------------------------------");
        Console.WriteLine ("Digite o número anterior ao nome do produto para retirá-lo do seu carrinho");
  		prodRemov = int.Parse(Console.ReadLine());
  		cart.nome.RemoveAt(prodRemov);
  		cart.qtd.RemoveAt(prodRemov);
  		cart.prc.RemoveAt(prodRemov);

  		return cart;
  	}
}