using System.Text;

namespace TP07_EDD2.Models;

public class Book
{
    public int ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public List<Copy> Copies { get; set; }

    public void AddCopies(Copy copy)
    {
        Copies.Add(copy);
    }

    public int QtyCopies()
    {
        return Copies.Count;
    }

    public int QtyAvailable()
    {
        return Copies.Count(x => x.IsAvailable());
    }

    public int QtyLoaned()
    {
        return Copies.Count(x => !x.IsAvailable());
    }

    public double PercAvailable()
    {
        if (QtyCopies() == 0)
        {
            return 0;
        }
        
        // ReSharper disable once PossibleLossOfFraction
        return (QtyAvailable() / QtyCopies()) * 100;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"== Livro {Title} ==");
        sb.AppendLine($"ISBN: {ISBN}");
        sb.AppendLine($"Autor: {Author}");
        sb.AppendLine($"Editora: {Publisher}");
        sb.AppendLine($"Exemplares: {QtyCopies()}");
        sb.AppendLine($"Disponíveis: {QtyAvailable()}");
        sb.AppendLine($"Emprestados: {QtyLoaned()}");
        sb.AppendLine($"Percentual de disponibilidade: {PercAvailable()}%");
        sb.AppendLine("===");

        return sb.ToString();
    }

    public string FullDetails()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(ToString());
        foreach (var copies in Copies)
        {
            sb.AppendLine(copies.ToString());
        }
        sb.AppendLine("===");
        return sb.ToString();
    }
}