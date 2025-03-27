namespace metal_komers70.Views.Services
{
    public interface IEmailService
    {
        Task SendContactFormAsync(string name, string email, string phone, string message);
    }
}
