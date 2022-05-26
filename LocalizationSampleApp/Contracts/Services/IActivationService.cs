using System.Threading.Tasks;

namespace LocalizationSampleApp.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
