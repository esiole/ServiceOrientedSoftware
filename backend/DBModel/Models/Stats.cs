namespace DBModel.Models;

[Table("stats")]
public class Stats
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public int Qty { get; set; }
    public double AverageWeight { get; set; }
    public double AverageVolume { get; set; }
}