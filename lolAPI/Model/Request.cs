using System.ComponentModel.DataAnnotations;

namespace lolAPI.Model;

public class Request
{
    [Key]
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty!;
    public string Json { get; set; } = String.Empty!;
    public DateTime DateCreated { get; set; }
}