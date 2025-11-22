//namespace MediTech.Application.Services.Usuario_Services;
///// <summary>
///// Esta clase es para el service de los Usuarios, aqui tratamos los datos que vienen de la base de datos, aqui usamos el Dto para mostrar mensaje al usuario en la interfaz swagger.
///// </summary>
//public class UsuarioService : IUsuarioService                    //Heredamos la funcion de la interfaz.
//{
//    private readonly IUsuarioRepository _usuarioRepository;      //variable para usar la propia interfaz.
//    private readonly JwtService _jwtService;                     //varibale que usaremos para el JWT para el login.

//    //Constructir de la clase UsuarioService
//    public UsuarioService(IUsuarioRepository usuarioRepository, JwtService jwtService)
//    {
//        _usuarioRepository = usuarioRepository;
//        _jwtService = jwtService;
//    }

//    public Task<IEnumerable<Usuarios>> GetAllAsync()
//    {
//        return _usuarioRepository.GetAllAsync();
//    }

//    //metodo para logear al Usuario y regresar el token.
//    public async Task<LoginDto> LoginAsync(string nombre, string contrasenia)
//    {
//        var usuario = await _usuarioRepository.LoginAsync(nombre, contrasenia);

//        if (usuario is null)
//        {
//            return new LoginDto
//            {
//                Exito = false,
//                Mensaje = "Credenciales inválidas o usuario inactivo",
//                Token = null
//            };
//        }

//        var token = _jwtService.GenerateToken(usuario.Nombre);

//        return new LoginDto
//        {
//            Exito = true,
//            Mensaje = "Inicio de sesión exitoso",
//            Token = token
//        };
//    }
//}
