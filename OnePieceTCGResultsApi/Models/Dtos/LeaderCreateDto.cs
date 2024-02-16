using OnePieceTCGResultsApi.Entities;

namespace OnePieceTCGResultsApi.Models.Dtos;

public class LeaderCreateDto
{
    public string Name { get; set; }
    public List<ColorId> Colors { get; set; }
}