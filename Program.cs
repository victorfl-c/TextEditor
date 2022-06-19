using System;
using System.IO;
using System.Threading;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Olá, seja muito bem vindo(a)! ");
            Console.WriteLine("Qual das opções a seguir você deseja? ");
            Console.WriteLine("1 - Editar/Criar arquivo.");
            Console.WriteLine("2 - Abrir arquivo");
            Console.WriteLine("0 - Sair\n");

            
            short option = short.Parse(Console.ReadLine());
            switch(option)
            {
                case 0 : Leave(); break;
                case 1 : Edit(); break;
                case 2 : Open(); break;
                default : InvalidOption(); break;
            }
        }
        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo ou pressione (ESC) para sair.");
            Console.WriteLine("-----------------------------------------------------\n");
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);
            Save(text);
        }
        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo? ");
            string path = Console.ReadLine();
            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            MenuReturn();

        }
        static void Leave()
        {
            Console.Clear();
            Console.WriteLine("Saindo do editor...");
            Thread.Sleep(2000);
            System.Environment.Exit(0);
        }
        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Em qual caminho deseja salvar? ");
            Console.WriteLine("Deve conter o tipo de arquivo, exemplo : Arquivo.txt\n");
            var path = Console.ReadLine();
            using(var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            MenuReturn();

        }
        static void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Opção inválida!");
            Console.WriteLine("Escolha opções entra 0 e 2.\n");
            MenuReturn();
        }
        static void MenuReturn()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Pressione Enter para voltar ao Menu.");
            Console.ReadKey();
            Menu();
        }
    }
}