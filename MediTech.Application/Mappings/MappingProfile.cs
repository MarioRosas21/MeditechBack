using AutoMapper;
using MediTech.Domain.Entities;                  // <-- NECESARIO
using MediTech.Domain.Dtos.SignosVitales;       // <-- Correcto       // si lo necesitas
using MediTech.Domain.Entities.Colaboradores_Entities;
using MediTech.Domain.Entities.Pacientes_Entities;
using MediTech.Application.Recetas.Commands;
using MediTech.Domain.Entities;

namespace MediTech.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePacienteCommand, Paciente>();
            CreateMap<UpdatePacienteCommand, Paciente>();
            CreateMap<Paciente, PacienteVM>();

            // Cita → CitaVM
            CreateMap<Cita, CitaVM>()
                .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => src.Paciente.Nombre))
                .ForMember(dest => dest.PacienteApellidoPaterno, opt => opt.MapFrom(src => src.Paciente.ApellidoPaterno))
                .ForMember(dest => dest.PacienteApellidoMaterno, opt => opt.MapFrom(src => src.Paciente.ApellidoMaterno))
                .ForMember(dest => dest.CURP, opt => opt.MapFrom(src => src.Paciente.CURP))
                .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.Paciente.FechaNacimiento))
                .ForMember(dest => dest.Sede, opt => opt.MapFrom(src => $"{src.Cede.Ciudad} - {src.Cede.Direccion}"))
                .ForMember(dest => dest.HoraCita, opt => opt.MapFrom(src => src.Disponibilidad.HoraInicio))
                .ForMember(dest => dest.Medico, opt => opt.MapFrom(src =>
                    $"{src.Disponibilidad.Colaborador.Nombre} {src.Disponibilidad.Colaborador.ApellidoPaterno}"))
                .ForMember(dest => dest.Especialidad, opt => opt.MapFrom(src =>
                    src.Disponibilidad.Colaborador.Especialidad != null
                        ? src.Disponibilidad.Colaborador.Especialidad.Nombre
                        : "Sin especificar"))
                .ForMember(dest => dest.Motivo, opt => opt.MapFrom(src => src.Motivo ?? "sin motivo"))
                .ForMember(dest => dest.FechaCita, opt => opt.MapFrom(src => src.FechaCita));

            CreateMap<Cede, CedeVM>();

            CreateMap<CrearUsuarioDto, Colaborador>();

            // 🔥 AQUÍ ESTABA EL ERROR
            CreateMap<MediTech.Domain.Entities.SignosVitales, SignosVitalesDto>();

            CreateMap<MediTech.Domain.Entities.Recetas_Entities.Recetas, RecetasDto>();

        }
    }
}
