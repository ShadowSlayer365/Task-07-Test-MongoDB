
public class Alumno
{
   
    public string Id { get; set; } = null!;  // Usamos null-forgiving operator (!)

    public string? Nombre { get; set; }   // Inicializamos con un valor vacío
    public string? Apellido { get; set; } 
    public string? Correo { get; set; } 
    public string? Telefono { get; set; } 
    public string? Direccion { get; set; } 
    public List<string?> CursosInscritos { get; set; } = new List<string?>();  // Inicializamos con una lista vacía
}

