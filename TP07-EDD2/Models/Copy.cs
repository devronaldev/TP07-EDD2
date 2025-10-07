using System.Text;

namespace TP07_EDD2.Models;

public class Copy
{
    public int SerialId { get; set; }
    public List<Loan> Loans { get; set; }
    private static int LastId { get; set; } = 0;

    public Copy(List<Loan> loans)
    {
        Loans = loans;
        SerialId = LastId++;
    }

    public Copy() : this(new List<Loan>())
    {
        
    }

    public bool Loan()
    {
        if (IsAvailable())
        {
            Loans.Add(new Loan());
            return true;
        }
        return false;
    }

    public bool Retrieve()
    {
        var loan = Loans.FirstOrDefault(x => x.End == null);
        if (loan == null)
        {
            return false;
        }
        loan.End = DateTime.Now;
        return true;
    }
    
    public bool IsAvailable()
    {
        if (Loans.Any(x => x.End == null))
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Tombo: {SerialId}");
        sb.AppendLine($"Empréstimos: {Loans.Count}");
        sb.AppendLine($"Disponível: {(IsAvailable() ? "Sim" : "Não")}");
        
        return sb.ToString();
    }
}