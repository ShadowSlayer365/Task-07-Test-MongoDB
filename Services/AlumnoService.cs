using AutoMapper;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

public class AlumnoService
{
    private readonly IMongoCollection<Alumno> _alumnos;
    private readonly IMapper _mapper;

    public AlumnoService(IMongoDatabase database, IOptions<MongoDBSettings> settings, IMapper mapper)
    {
        _alumnos = database.GetCollection<Alumno>(settings.Value.CollectionName);
        _mapper = mapper;
    }

    public async Task<List<AlumnoDTO>> GetAlumnosAsync()
    {
        var alumnos = await _alumnos.Find(alumno => true).ToListAsync();
        return _mapper.Map<List<AlumnoDTO>>(alumnos); // Mapear a DTO
    }

    public async Task<AlumnoDTO> GetAlumnoByIdAsync(string id)
    {
        var alumno = await _alumnos.Find(alumno => alumno.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<AlumnoDTO>(alumno); // Mapear a DTO
    }

    public async Task CreateAlumnoAsync(AlumnoDTO alumnoDTO)
    {
        var alumno = _mapper.Map<Alumno>(alumnoDTO); // Mapear a entidad
        await _alumnos.InsertOneAsync(alumno);
    }

    public async Task UpdateAlumnoAsync(string id, AlumnoDTO alumnoDTO)
    {
        var alumno = _mapper.Map<Alumno>(alumnoDTO); // Mapear a entidad
        await _alumnos.ReplaceOneAsync(a => a.Id == id, alumno);
    }

    public async Task DeleteAlumnoAsync(string id)
    {
        await _alumnos.DeleteOneAsync(a => a.Id == id);
    }
}