using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable()]
class Cliente{

  public string nome;
  public string dataNasc;
  public string cpf;
  public string endereco;

  public void menuClientes(List<Cliente>  Clts){
    int op = 0;
    while(op!= 3){
      Console.WriteLine ("Selecione a opção desejada escrevendo apenas o número:");
      Console.WriteLine ("------------------------------");
      Console.WriteLine ("1 - CADASTRAR CLIENTE");
      Console.WriteLine ("2 - REMOVER CLIENTE");
      Console.WriteLine ("3 - RETORNAR AO MENU INICIAL");
      Console.WriteLine ("------------------------------");
      op = int.Parse(Console.ReadLine());
      switch(op){
        case 1:
        Console.Clear();
        Clts = cadastrarCliente(Clts);
        gravarClientes(Clts);
        break;
        case 2:
        Console.Clear();
        Clts = removerCliente(Clts);
        gravarClientes(Clts);
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
  }

  public List<Cliente>  cadastrarCliente(List<Cliente>  Clts) {
    Cliente clt = new Cliente();
    Console.WriteLine ("Qual seu nome?");
    clt.nome = Console.ReadLine();
    Console.WriteLine ("Qual sua data de nascimento?");
    clt.dataNasc = Console.ReadLine();
    Console.WriteLine ("Qual seu CPF?");
    clt.cpf = Console.ReadLine();
    Console.WriteLine ("Qual seu endereço?");
    clt.nome = Console.ReadLine();
    Clts.Add(clt);
    return Clts;
  }


  public List<Cliente>  removerCliente(List<Cliente>  Clts) {
    string cpfremove;
    bool remove = false;
    Console.WriteLine("Qual o CPF do cliente a ser removido?");
    cpfremove = Console.ReadLine();
    for(int i = 0; i < Clts.Count; i++)
     {
      if(Clts[i].cpf == cpfremove){
        Clts.RemoveAt(i);
        remove = true;
      }
     }
     if(remove){
      Console.WriteLine("Cliente removido com sucesso.");
     }
     else {
      Console.WriteLine("Ocorreu um erro na operação.");
     }
     return Clts;
  }


  public void gravarClientes(List<Cliente>  Clts){
    string serializationFile = "Clientes.bin";
    using (Stream stream = File.Open(serializationFile, FileMode.Create))
    {
      var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
      bformatter.Serialize(stream, Clts);
    }
  }

}