public class AlumnoDTO
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public int Edad { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public  DireccionDTO Direccion { get; set; }
    public List<CursoInscritoDTO> CursosInscritos { get; set; }
    public DateTime FechaRegistro { get; set; }
}

