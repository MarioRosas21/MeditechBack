using MediTech.Application.Common.Interfaces.Repositories;
using MediTech.Application.Features.Colaboradores.Handlers;
using MediTech.Application.Recetas.Handlers;
using MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeByDireccion;
using MediTech.Application.Services.Cede_Services.Features.CRUD.Queries.GetCedeById;
using MediTech.Application.Services.Paciente_Services.Features.Auth.Queries.LoginPaciente;
using MediTech.Application.Services.Recetas_Services.Features.CRUD.Queries.GetAllRecetas;
using MediTech.Domain.Interfaces.Repositories.Cedes_Repositories;
using MediTech.Domain.Interfaces.Repositories.Citas_Repositories;
using MediTech.Domain.Interfaces.Repositories.Colaborador_Repositories;
using MediTech.Domain.Interfaces.Repositories.Email_Repositories;
using MediTech.Domain.Interfaces.Repositories.Especialidad_Repositories;
using MediTech.Infrastructure.Persistence.Cede_Persistences;
using MediTech.Infrastructure.Persistence.Citas_Persistences;
using MediTech.Infrastructure.Persistence.Colaborador_Persistences;
using MediTech.Infrastructure.Persistence.Email_Persistences;
using MediTech.Infrastructure.Persistence.Especialidad_Persistences;
using MediTech.Infrastructure.Persistence.Recetas_Persistences;
using MediTech.Infrastructure.Persistence.Usuario_Persistences;

var builder = WebApplication.CreateBuilder(args);

// ------------------------
// EF Core
// ------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ------------------------
// Repositorios
// ------------------------
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<ICedeRepository, CedeRepository>();
builder.Services.AddScoped<IEspecialidadRepository, EspecialidadRepository>();
builder.Services.AddScoped<ITipoColaboradorRepository, TipoColaboradorRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<ISignosVitalesRepository, SignosVitalesRepository>();
builder.Services.AddScoped<IRecetasRepository, RecetasRepository>();





// ------------------------
// Servicios
// ------------------------
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<VerificarRolService>();

// ------------------------
// MediatR
// ------------------------
builder.Services.AddMediatR(
    typeof(GetAllPacientesQueryHandler).Assembly,
    typeof(LoginPacienteQueryHandler).Assembly,
    typeof(CreateCitaCommandHandler).Assembly,
    typeof(GetCitasByPacienteQueryHandler).Assembly,
    typeof(GetCitaByIdQueryHandler).Assembly,
    typeof(GetCedeByDireccionQueryHandler).Assembly,
    typeof(GetCedeByIdQueryHandler).Assembly,
    typeof(GetAllTipoColaboradoresHandler).Assembly,
    typeof(GetAllSignosVitalesQueryHandler).Assembly,
    typeof(GetAllRecetasQueryHandler).Assembly
);

// ------------------------
// AutoMapper
// ------------------------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// ------------------------
// Controladores
// ------------------------
builder.Services.AddControllers();

// ------------------------
// Swagger + JWT
// ------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MediTech", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese 'Bearer {token}'"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[]{ }
        }
    });
});

// ------------------------
// CORS
// ------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedHosts", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// ------------------------
// JWT Authentication
// ------------------------
var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
        )
    };
});

// ------------------------
// POLÍTICA DE AUTORIZACIÓN PARA MÉDICOS Y ENFERMEROS
// ------------------------
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EsMedicoOEnfermeroByTipoColaborador", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var tipo = context.User.FindFirst("tipoColaborador")?.Value;

            return tipo == "Médico" || tipo == "Enfermero";
        });
    });

    options.AddPolicy("EsMedicoOEnfermeroByRole", policy =>
    {
        policy.RequireRole("Médico", "Enfermero");
    });
});

// ------------------------
// Build
// ------------------------
var app = builder.Build();

// ------------------------
// Middlewares
// ------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseDeveloperExceptionPage();

app.MapGet("/", () => Results.Redirect("/swagger"));

// CORS
app.UseCors("AllowedHosts");

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers();

// URLs
app.Urls.Add("http://0.0.0.0:5239");
app.Urls.Add("https://localhost:5239");
app.Urls.Add("https://localhost:7042");

app.Run();
