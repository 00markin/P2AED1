using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable()]
class Produto{
	public string desc;
	public int qtd;
	public double prc;

	public void menuProdutos(List<Produto> Prds, Carrinho cart){
		int op = 0;
    	while(op!= 4){
    		Console.WriteLine ("Selecione a opção desejada escrevendo apenas o número:");
    		Console.WriteLine ("------------------------------");
    		Console.WriteLine ("1 - CADASTRAR PRODUTO");
		    Console.WriteLine ("2 - LISTAR ESTOQUE");
		    Console.WriteLine ("3 - ADICIONAR PRODUTO AO CARRINHO");
		    Console.WriteLine ("4 - RETORNAR AO MENU INICIAL");
		    Console.WriteLine ("------------------------------");
		    op = int.Parse(Console.ReadLine());
		    switch(op){
		      case 1:
		      Console.Clear();
		      Prds = cadastrarProdutos(Prds);
		      gravarEstoque(Prds);
		      break;
		      case 2:
		      Console.Clear();
		      listarProdutos(Prds);
		      break;
		      case 3:
		      Console.Clear();
		      cart = cart.addCarrinho(Prds, cart);
		      break;
		      case 4:
    		  Console.Clear();
       		  break;
		      default:
		      Console.Clear();
		      Console.WriteLine("Opção inválida, tente novamente:");
		      break;
		    }
		}
	}

	public List<Produto> cadastrarProduto(List<Produto> Prds) {
    	Produto prd = new Produto();
	    Console.WriteLine ("Qual a descrição do produto?");
	    prd.nome = Console.ReadLine();
	    Console.WriteLine ("Quantos produtos estão disponíveis?");
	    prd.qtd = int.Parse(Console.ReadLine());
	    Console.WriteLine ("Qual o valor do produto?");
	    prd.prc = double.Parse(Console.ReadLine());
	    Prds.add(prd);
	    return Prds;
  	}

  	public void listarProdutos(List<Produto> Prds){
  		if(File.Exists("Estoque.bin")){
	    	string serializationFile = "Estoque.bin";
	    	using (Stream stream = File.Open(serializationFile, FileMode.Open))
	        {
	            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
	            Prds = (List<Produto>)bformatter.Deserialize(stream);
	        }
	        Console.WriteLine ("-------------------------------------");
	        int i = 0;
        	foreach(Protuduto prd in Prds){
        		Console.WriteLine (i +"-" + prd.nome + "    " + prd.qtd + "    R$"+prd.prc);
        		i++;
        	}
        	Console.WriteLine ("-------------------------------------");
    	}
    	else {
    		Console.WriteLine ("Não existe estoque disponível");
    	}
  	}

  	public void gravarEstoque(List<Produto> Prds){
  		string serializationFile = "Estoque.bin";
    	using (Stream stream = File.Open(serializationFile, FileMode.Create))
    	{
    	  var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    	  bformatter.Serialize(stream, PrdsList);
    	}
  	}
}