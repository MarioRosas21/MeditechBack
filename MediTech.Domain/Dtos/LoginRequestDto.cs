namespace MediTech.Domain.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Contrasenia { get; set; } = string.Empty;
    }
}
