using System.ComponentModel.DataAnnotations;

namespace APIMetrics.Models;

public class TargetValue
{
    [Range(minimum: -100, maximum: 100, ErrorMessage = "Informe um valor entre -100 e 100")]
    public int NewTargetValue { get; set; }
}
