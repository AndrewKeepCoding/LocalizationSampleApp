using System.Threading.Tasks;

namespace LocalizationSampleApp.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
