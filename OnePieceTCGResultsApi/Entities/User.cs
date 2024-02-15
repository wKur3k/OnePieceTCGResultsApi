namespace OnePieceTCGResultsApi.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public List<Role> Roles { get; set; }
    public List<Note> Notes { get; set; }
}