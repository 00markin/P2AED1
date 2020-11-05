using System;
using System.Collections.Generic;
using System.IO;


class Pagamento{
	public double total = 0;
	public bool pago = false;
	public double saldo = 0;

	public Carrinho menuPagamento(Pagamento pg, Carrinho cart, List<Produto> Prds, Produto prd){
		int op = 0;
		Console.WriteLine ("Saldo atual: R$" + pg.saldo);
		while(op!= 4){
			Console.WriteLine ("Selecione a opção desejada escrevendo apenas o número:");
    		Console.WriteLine ("------------------------------");
    		Console.WriteLine ("1 - ADICIONAR SALDO");
		    Console.WriteLine ("2 - FINALIZAR PAGAMENTO");
		    Console.WriteLine ("3 - REGISTO DE PAGAMENTOS");
		    Console.WriteLine ("4 - RETORNAR AO MENU INICIAL");
		    Console.WriteLine ("------------------------------");
		    op = int.Parse(Console.ReadLine());
		    switch(op){
		      case 1:
		      Console.Clear();
		      pg = addMoney(pg);
		      break;
		      case 2:
		      Console.Clear();
		      pg = finalizarPg(pg, cart, Prds, prd);
		      if(pg.pago){
		      	cart = new Carrinho();
		      }
		      break;
		      case 3:
		      Console.Clear();
		      listarPagamentos();
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
		return cart;
	}


	public Pagamento addSaldo(Pagamento pg){
		double addMoney = 0;
		Console.WriteLine ("Quanto deseja adicionar a sua carteira?");
		addMoney = double.Parse(Console.ReadLine());
		pg.saldo += addMoney;
		return pg;
	}

	public Pagamento finalizarPg(Pagamento pg, Carrinho cart, List<Produto> Prds, Produto prd){
		pg.total = 0;
		int[] quanti = cart.qtd.ToArray();
        Test(quanti);
        double[] prec = cart.prc.ToArray();
        Test(prec);
        string[] descricao = cart.nome.ToArray();
        Test(descricao);
        for (int i = 0; i < descricao.Length; i++){
        	double aux = double.Parse(quanti[i]);
        	pg.total += (prec[i] * aux);
        }
        if(pg.saldo >= pg.total){
        	for (int i = 0; i < descricao.Length; i++){
        		double aux = double.Parse(quanti[i]);
        		aux = (prec[i] * aux);
        		gravarPagamento(descricao[i], quanti[i], aux);
        	}
        	for (int i = 0; i < descricao.Length; i++){
        		int aux2 = cart.indexA[i];
        		if (Prds[aux2].qtd == quanti[i]){
        			Prds.RemoveAt(aux2);
        		} else {
        			Prds[aux2].qtd -= quanti[i];
        		}
        	}
        	Console.WriteLine("Obrigado por realizar seu pagamento!\nPressione qualquer tecla para prosseguir.");
			prd.gravarEstoque(Prds);
			pg.pago = true;
			pg.saldo -= pg.total;
			Console.ReadKey();
	    }
	    else {
	    	Console.WriteLine("Saldo insuficiente, para confirmar a compra, adicione ao menos R$" + (pg.saldo - pg.total));
	    }
		return pg;
	}

	public void gravarPagamento(string dc, int qt, double tt){
		if(File.Exists("Pagamentos.txt")){
		    StreamWriter escrita = File.AppendText("Pagamentos.txt");
		    escrita.WriteLine(dc);
		    escrita.WriteLine(qt);
		    escrita.WriteLine(tt);
		    escrita.Close();
    	}
    	else {
    		StreamWriter escrita = new StreamWriter("Pagamentos.txt");
    		escrita.WriteLine(dc);
		    escrita.WriteLine(qt);
		    escrita.WriteLine(tt);
    		escrita.Close();
    	}
	}


	public void listarPagamentos(){
		string desc;
		int quant;
		double totalPg;
		if(File.Exists("Pagamentos.txt")){
		    string[] relatorio = File.ReadAllLines("Carteira.txt");
		    Console.WriteLine("------------------INICIO DO RELATORIO-------------------");
		    Console.WriteLine("NOME DO PRODUTO          QUANTIDADE          TOTAL PAGO");
		    for(int i = 0; i < relatorio.Length; i+=3){
		    	desc = relatorio[i];
		    	quant = int.Parse(relatorio[i+1]);
		    	totalPg = double.Parse(relatorio[i+2]);
		    	Console.WriteLine(desc + "          " + quant + "          R$" + totalPg);
		    }
		    Console.WriteLine("---------------------FIM DO RELATORIO---------------------");
		    Console.ReadKey();
    	}
    	else {
    		Console.WriteLine("NÃO EXISTEM REGISTOS DE PAGAMENTOS!");
    		Console.ReadKey();
    	}
	}

}