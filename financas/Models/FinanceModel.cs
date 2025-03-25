using System.ComponentModel.DataAnnotations;

namespace financas.Models;

public class FinancasModel
{
    public int Id {get; set;}
    [Required]
    public double Amount {get; set;}
    [Required]
    public string? Description {get; set;}
    [Required]
    public string? Type {get; set;}
    public DateTime Date {get; set;} = DateTime.Now;
}

//Verificar se precisa incluir o DateTime