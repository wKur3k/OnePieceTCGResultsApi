namespace OnePieceTCGResultsApi.Entities;

public class Color
{
    public ColorId ColorId { get; set; }  
    public string Name { get; set; }
    public List<Leader> Leaders { get; set; }
}