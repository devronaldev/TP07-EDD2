using TP07_EDD2.Controllers;
using TP07_EDD2.Models;

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

    private static void ShowOptions()
    {
        Console.Clear();
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
        var isbn = ReadInteger("Insira o ISBN (13 dígitos): ");
        Console.Write("Insira o titulo: ");
        var title = Console.ReadLine();
        Console.Write("Insira o autor: ");
        var author = Console.ReadLine();
        Console.Write("Insira a editora: ");
        var publisher =  Console.ReadLine();
        
        var book = new Book(title, author, publisher, isbn);
        
        Books.AddBook(book);
        Console.Clear();
        Console.WriteLine("Livro adicionado com sucesso.");
        Console.WriteLine(book.ToString());
        Console.WriteLine("Clique qualquer tecla para retornar.");
        Console.ReadKey();
    }

    private static void SearchBook()
    {
        Console.Write("Insira o titulo: ");
        var book = Books.SearchBook(new Book(Console.ReadLine()));
        if (book == null)
        {
            Console.WriteLine("Nenhum livro foi encontrado.");
            Console.WriteLine("Clique qualquer tecla para retornar.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine(book.ToString());
        Console.WriteLine("Clique qualquer tecla para retornar.");
        Console.ReadKey();
    }

    private static void SearchBookAnalytic()
    {
        Console.Write("Insira o titulo: ");
        var book = Books.SearchBook(new Book(Console.ReadLine()));
        if (book == null)
        {
            Console.WriteLine("Nenhum livro foi encontrado.");
            Console.WriteLine("Clique qualquer tecla para retornar.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine(book.FullDetails());
        Console.WriteLine("Clique qualquer tecla para retornar.");
        Console.ReadKey();
    }

    private static void AddCopy()
    {
        Console.Write("Insira o titulo: ");
        var book = Books.SearchBook(new Book(Console.ReadLine()));
        if (book == null)
        {
            Console.WriteLine("Nenhum livro foi encontrado.");
            Console.WriteLine("Clique qualquer tecla para retornar.");
            Console.ReadKey();
            return;
        }
        book.AddCopies(new Copy());
        Console.WriteLine("Clique qualquer tecla para retornar.");
        Console.ReadKey();
    }

    private static void AddLoan()
    {
        Console.Write("Insira o titulo: ");
        var book = Books.SearchBook(new Book(Console.ReadLine()));
        if (book == null)
        {
            Console.WriteLine("Nenhum livro foi encontrado.");
            Console.WriteLine("Clique qualquer tecla para retornar.");
            Console.ReadKey();
            return;
        }

        var copy = book.Copies.FirstOrDefault(x => x.IsAvailable());
        if (copy == null)
        {
            Console.WriteLine("Nenhum exemplar disponível foi encontrado.");
            Console.WriteLine("Clique qualquer tecla para retornar.");
            Console.ReadKey();
            return;
        }
        copy.Loan();
        Console.Clear();
        Console.WriteLine("Empréstimo iniciado com sucesso. Unidade: ");
        Console.WriteLine(copy.ToString());
        Console.WriteLine("Clique qualquer tecla para retornar.");
        Console.ReadKey();
    }

    private static void AddRetrieve()
    {
        Console.Write("Insira o titulo: ");
        var book = Books.SearchBook(new Book(Console.ReadLine()));
        if (book == null)
        {
            Console.WriteLine("Nenhum livro foi encontrado.");
            Console.WriteLine("Clique qualquer tecla para retornar.");
            Console.ReadKey();
            return;
        }

        var copy =  book.Copies.FirstOrDefault(x => !x.IsAvailable());
        if (copy == null)
        {
            Console.WriteLine("Nenhum exemplar emprestado foi encontrado.");
            Console.WriteLine("Clique qualquer tecla para retornar.");
            Console.ReadKey();
            return;
        }
        copy.Retrieve();
        Console.Clear();
        Console.WriteLine("Exemplar devolvido com sucesso. Unidade: ");
        Console.WriteLine(copy.ToString());
        Console.WriteLine("Clique qualquer tecla para retornar.");
        Console.ReadKey();
    }
}