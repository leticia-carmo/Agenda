using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda01
{
    class Program
    {
        static void Main(string[] args)
        {//variáveis
            int codCadastro = 0;
            string nome, tel, email, cpf, endereco, cep, cidade, bairro, estado;

            //faça(laço)
            do
            {
                //primeira linha exibida para o usuário
                Console.WriteLine("Informe o código numérico, ou digite a tecla enter para sair do programa");
                codCadastro = Convert.ToInt32(Console.ReadLine());//ou int.Parse(Console.ReadLine());

                //se o usuário deseja sair do programa
                if (codCadastro == 0)
                {
                    Console.WriteLine("Você digitou um código de saída, deseja sair do programa? Pressione a tecla enter para confirmar");
                    Console.ReadKey();
                    break;
                }
                //caso o usuário queira continuar no programa
                else
                {
                    //pergunta e lê o nome que será cadastrado
                    Console.WriteLine("Informe o nome");
                    nome = Console.ReadLine();

                    //pergunta e lê o telefone que será cadastrado
                    Console.WriteLine("Informe o telefone");
                    tel = Console.ReadLine();

                    //pergunta e lê o email que será cadastrado
                    Console.WriteLine("Informe o email");
                    email = Console.ReadLine();

                    //pergunta e lê o cpf que será cadastrado
                    Console.WriteLine("Informe o CPF");
                    cpf = Console.ReadLine();
                    //para retirar espaços em branco no começo e fim do cpf
                    cpf = cpf.Trim();
                    //remove os caracteres escolhidos: ponto, vírgula e hífen
                    cpf = cpf.Replace(".", "").Replace("-", "").Replace(",", "");

                    //cria laço até que o usuário digite os 11 caracteres
                    while (cpf.Length != 11)
                    {
                        Console.WriteLine("Esse CPF é inválido, digite novamente o CPF com 11 dígitos");
                        cpf = Console.ReadLine();
                    }

                    //pergunta e lê o endereço que será cadastrado
                    Console.WriteLine("Informe o endereço");
                    endereco = Console.ReadLine();

                    //pergunta e lê o bairro que será cadastrado
                    Console.WriteLine("Informe o bairro");
                    bairro = Console.ReadLine();

                    //pergunta e lê o cidade que será cadastrado
                    Console.WriteLine("Informe o cidade");
                    cidade = Console.ReadLine();

                    //pergunta e lê o estado que será cadastrado
                    Console.WriteLine("Informe a sigla do Estado");
                    estado = Console.ReadLine();
                    //para retirar espaços em branco no começo e fim do estado
                    estado = estado.Trim();
                    //remove os caracteres escolhidos: ponto, vírgula e hífen
                    estado = estado.Replace(".", "").Replace(",", "").Replace("-", "");
                    //cria laço até que o usuário digite os 11 caracteres
                    while (estado.Length != 2)
                    {
                        Console.WriteLine("Esse Estado é inválido, digite novamente a sigla do Estado com 2 dígitos");
                        estado = Console.ReadLine();
                    }

                    //pergunta e lê o cep que será cadastrado
                    Console.WriteLine("Informe o CEP");
                    cep = Console.ReadLine();
                    //para retirar espaços em branco no começo e fim do estado
                    cep = cep.Trim();
                    //remove os caracteres escolhidos: ponto, vírgula e hífen
                    cep = cep.Replace(".", "").Replace(",", "").Replace("-", "");
                    //cria laço até que o usuário digite os 11 caracteres
                    while (cep.Length != 8)
                    {
                        Console.WriteLine("Esse CEP é inválido, digite novamente o CEP com 8 dígitos");
                        cep = Console.ReadLine();
                    }

                    //pasta para armazenar os arquivos com os dados
                    DirectoryInfo dir = new DirectoryInfo(@"c:\atividadeC#");

                    if (!dir.Exists)
                    {
                        try
                        //caso não ocorra um erro
                        {
                            //caso não exista a pasta:
                            dir.Create();
                            Console.WriteLine("Diretório criado com sucesso");
                        }
                        //caso ocorra um erro
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível criar o diretório: {0}", e.ToString());
                        }
                        finally { }

                        //criando novo arquivo ou adicionando novas informações no final deles
                        FileStream CriaArquivo = new FileStream(@"c:\atividadeC#\atividade.txt", FileMode.Append);
                        //chamando a classe que cria arquivo e escreve nele
                        StreamWriter Arquivo = new StreamWriter(CriaArquivo, Encoding.ASCII);
                        Arquivo.WriteLine("");
                        Arquivo.WriteLine("Novo registro");
                        Arquivo.WriteLine("");
                        Arquivo.WriteLine(Convert.ToString(0));
                        Arquivo.WriteLine(nome);
                        Arquivo.WriteLine(tel);
                        Arquivo.WriteLine(email);
                        Arquivo.WriteLine(cpf);
                        Arquivo.WriteLine(endereco);
                        Arquivo.WriteLine(bairro);
                        Arquivo.WriteLine(cidade);
                        Arquivo.WriteLine(estado);
                        Arquivo.WriteLine(cep);
                        //fechando
                        Arquivo.Flush();
                        Arquivo.Close();
                        CriaArquivo.Close();
                        Console.Clear();
                    }


                }

            }
            //caso o código digitado for diferente de 99999, o programa continua
            while (codCadastro != 99999);
        }
    }
}