namespace TP07_EDD2.Models;

public class Loan
{
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }

    public Loan()
    {
        Start = DateTime.Now;
        End = null;
    }
}