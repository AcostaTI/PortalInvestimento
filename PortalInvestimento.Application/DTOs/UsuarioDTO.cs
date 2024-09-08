namespace PortalInvestimento.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public EnTipoAcesso TipoAcesso { get; set; }
    }

    public enum EnTipoAcesso
    {
        Admin = 1,
        Funcionario = 2
    }
}
