using TP07_EDD2.Controllers;

namespace TP07_EDD2.View;

public static class Menu
{
    private static Books Books {set; get;} =  new Books();
    public static void Start()
    {
        Console.Clear();
        while (true)
        {
            ShowOptions();
        }
    }

    public static void ShowOptions()
    {
        Console.WriteLine("0. Sair.");
        Console.WriteLine("1. Adicionar livro.");
        Console.WriteLine("2. Pesquisar livro (sintético).");
        Console.WriteLine("3. Pesquisar livro (analítico)");
        Console.WriteLine("4. Adicionar exemplar.");
        Console.WriteLine("5. Registrar empréstimo.");
        Console.WriteLine("6. Registrar devolução.");
        
        var value = ReadInteger("Digite o número da opção: ");
        SwitchOptions(value);
    }

    public static int ReadInteger(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
        }
    }

    private static void SwitchOptions(int option)
    {
        switch (option)
        {
            case 0: Environment.Exit(0); break;
            case 1: AddBook(); break;
            case 2: SearchBook(); break;
            case 3: SearchBookAnalytic(); break;
            case 4: AddCopy(); break;
            case 5: AddLoan(); break;
            case 6: AddRetrieve(); break;
            default: Console.WriteLine("Opção inválida. Aperte qualquer tecla para retornar.");
                Console.ReadKey(); 
                break;
        }
    }

    private static void AddBook()
    {
        
    }

    private static void SearchBook()
    {
        
    }

    private static void SearchBookAnalytic()
    {
        
    }

    private static void AddCopy()
    {
        
    }

    private static void AddLoan()
    {
        
    }

    private static void AddRetrieve()
    {
        
    }
}