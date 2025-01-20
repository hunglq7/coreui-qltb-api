using System.Configuration;
namespace WebApi.Common
{
    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
