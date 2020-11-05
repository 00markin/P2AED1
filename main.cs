using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable()]
class MainClass {
  public static void Main (string[] args) {
    int op = 0;
    List<Cliente> Clts = new list<Cliente>();
    Cliente clt = new Cliente();
    List<Produto> Prds = new list<Produto>();
    Produto prd = new Produto();
    Carrinho cart = new Carrinho();
    Pagamento pg = new Pagamento();

    if(File.Exists("Clientes.bin")){
      //File.WriteAllLines("Clientes.txt", Clts);
    	string serializationFile = "Clientes.bin";
    	using (Stream stream = File.Open(serializationFile, FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            List<Cliente>  Clts = (List<Cliente>)bformatter.Deserialize(stream);
        }
    }
    if(File.Exists("Estoque.bin")){
    	string serializationFile = "Estoque.bin";
    	using (Stream stream = File.Open(serializationFile, FileMode.Open))
        {
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            List<Produto>  Prds = (List<Produto>)bformatter.Deserialize(stream);
        }
    }
    Console.WriteLine ("Bem vindo ao seu M&MSuperMercado!");
    Console.WriteLine ("Escolha o setor que deseja ir!");
    while(op!= 5){
    	Console.WriteLine ("Selecione a opção desejada escrevendo apenas o número:");
      Console.WriteLine ("------------------------------");
      Console.WriteLine ("1 - CLIENTE");
      Console.WriteLine ("2 - PRODUTOS");
      Console.WriteLine ("3 - CARRINHO");
      Console.WriteLine ("4 - PAGAMENTO");
      Console.WriteLine ("5 - SAIR");
      Console.WriteLine ("------------------------------");
      op = int.Parse(Console.ReadLine());
      switch(op){
        case 1:
        Console.Clear();
        clt.menuClientes(Clts);
        break;
        case 2:
        Console.Clear();
       	prd.menuProdutos(Prds, cart);
        break;
        case 3:
        Console.Clear();
        cart = cart.menuCarrinho(Prds, cart);
        break;
        case 4:
        Console.Clear();
        
        break;
        case 5:
        Console.Clear();
        Console.WriteLine("Obrigado pela sua preferência!");
        Console.ReadKey();
        break;
        default:
        Console.Clear();
        Console.WriteLine("Opção inválida, tente novamente:");
        break;
      }
    }
  }
}
