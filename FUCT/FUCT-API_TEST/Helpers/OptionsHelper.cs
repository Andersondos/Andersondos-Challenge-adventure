using FUCT_API.Helpers;
using Microsoft.Extensions.Options;
namespace FUCT_API_TEST.Helpers
{
    public class OptionsHelper : IOptions<AppSettings>
    {
        AppSettings IOptions<AppSettings>.Value => new AppSettings()
        {
            Secret = "adasd dadasdadasdadsd ad sdd ak dajsk dajdkasdjaskdlkj"
        };
    }
}
