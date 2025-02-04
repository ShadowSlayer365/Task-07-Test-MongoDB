using AutoMapper;

public class AlumnoProfile : Profile
{
    public AlumnoProfile()
    {
        // Configuración de mapeo entre Alumno y AlumnoDTO
        CreateMap<Alumno, AlumnoDTO>()
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => 
                new DireccionDTO
                {
                    Calle = src.Direccion, // Aquí puedes procesar o descomponer la cadena 'Direccion'
                    Ciudad = "Ciudad ejemplo", 
                    CodigoPostal = "CodigoPostal ejemplo" 
                }))
            .ForMember(dest => dest.CursosInscritos, opt => opt.MapFrom(src => 
                src.CursosInscritos.Select(curso => new CursoInscritoDTO 
                { 
                    CursoId = curso, 
                    NombreCurso = "Curso ejemplo", // Si tienes la lógica para asignar el nombre del curso
                    FechaInscripcion = DateTime.Now // Asigna la fecha de inscripción que corresponda
                }).ToList())); // Mapea CursosInscritos

        // Configuración inversa (AlumnoDTO a Alumno)
        CreateMap<AlumnoDTO, Alumno>();

        // Configuración de mapeo entre DireccionDTO y Direccion
        CreateMap<DireccionDTO, Direccion>();
        CreateMap<Direccion, DireccionDTO>();

        // Configuración de mapeo entre CursoInscrito y CursoInscritoDTO
        CreateMap<CursoInscritoDTO, CursoInscrito>()
            .ForMember(dest => dest.CursoId, opt => opt.MapFrom(src => src.CursoId))
            .ForMember(dest => dest.NombreCurso, opt => opt.MapFrom(src => src.NombreCurso))
            .ForMember(dest => dest.FechaInscripcion, opt => opt.MapFrom(src => src.FechaInscripcion));

        CreateMap<CursoInscrito, CursoInscritoDTO>()
            .ForMember(dest => dest.CursoId, opt => opt.MapFrom(src => src.CursoId))
            .ForMember(dest => dest.NombreCurso, opt => opt.MapFrom(src => src.NombreCurso))
            .ForMember(dest => dest.FechaInscripcion, opt => opt.MapFrom(src => src.FechaInscripcion));
    }
}
