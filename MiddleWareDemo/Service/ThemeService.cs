using Microsoft.Extensions.Options;

namespace MiddleWareDemo.Service
{
    public class ThemeService : IThemeService
    {
        private ThemeSettings _themeSettings;

        public ThemeService(IOptions<ThemeSettings> themeSettings)
        {
            _themeSettings = themeSettings.Value;
        }

        public string ApplyTheme()
        {
            return $"NAme : {_themeSettings.Name}/ Color : {_themeSettings.Color}";
        }
    }
}
