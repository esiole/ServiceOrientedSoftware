using DBModel.Models;

namespace Services.Dto;

public class Statistic
{
    public int Qty { get; set; }
    public double AverageWeight { get; set; }
    public double AverageVolume { get; set; }

    public Statistic(Stats stats)
    {
        Qty = stats.Qty;
        AverageWeight = stats.AverageWeight;
        AverageVolume = stats.AverageVolume;
    }
}