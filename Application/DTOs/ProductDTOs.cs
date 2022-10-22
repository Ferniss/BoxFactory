namespace Application.DTOs;

public class PostProductDTO
{
    public int Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


public class PutProductDTO
{
    public int? Price { get; set; }
    public string? Name { get; set; }
    public int Id { get; set; }
    public string Description { get; set;}
}