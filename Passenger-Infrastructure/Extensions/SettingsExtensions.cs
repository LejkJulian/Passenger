using Microsoft.Extensions.Configuration;


namespace Passengers.Infrastructure.Extensions
{
    static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T:new()//nowa klasa z konstruktorem
        {
            //refleksja skasowac Settings z nazwyklasy, zostanie samo general
            string section = typeof(T).Name.Replace("Settings", string.Empty);
            //stworzony nowy obiuekt naszych ustawien, klasa z domyslnym konstr
            var configurationValue = new T();
            //przypisz do ustawien np json do obiektu tejrze klasy
            configuration.GetSection(section).Bind(configurationValue);
            return configurationValue;
        }
    }
}
