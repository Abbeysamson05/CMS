using CMS.API.Configuration;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IEmailServices
    {
        void SendEmail(Message message);
    }
}
