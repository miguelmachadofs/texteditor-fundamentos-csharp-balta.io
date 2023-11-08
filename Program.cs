using System;
using System.IO;

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
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option) 
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir() 
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            // Sempre usar o using quando formos ler ou fazer e salvar uma alteração em um arquivo
            using (var file = new StreamReader(path)) // StreamReader vai ser o leitor do arquivo
            {
                string text = file.ReadToEnd(); // ReadToEnd vai ler o arquivo até o final
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadKey();
            Menu();
        }

        static void Editar() 
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("---------------");
            string text = "";

            do 
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }   

        static void Salvar(string text) 
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            /* 
                Neste momento, estamos trabalhando com a abertura e fechamento de arquivos,
                através da classe instanciada System.IO.StreamWriter. No uso cotidiano, precisaríamos
                chamar também a função Close() dessa classe, para que o arquivo não fique em aberto e
                impossibilite de alguém usá-lo posteriormente. Porém, para que não haja o risco de
                esquecer de fechar manualmente o arquivo, fazemos a manipulação do arquivo dentro de um using.
                Pois ele já fará, automaticamente, a abertura e fechamento dele. Isso serve também para
                interações com bancos de dados. Cria o objeto, usa e depois o fecha
            */
            using (var file = new StreamWriter(path)) 
            {
                // Stream em inglês é fluxo e Writer seria de escrita: fluxo de escrita de um array de bytes (útil p/ qualquer arquivo)
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Menu();
        }
    }
}
