using Microsoft.Extensions.Configuration;

namespace PrintForms.Helper
{
    public static class AppSetting
    {
        private static IConfiguration Configuration { get; set; }

        public static void Init(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfigurationSection GetSection(string key)
        {
            return Configuration.GetSection(key);
        }
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSettingString(string key)
        {
            return Configuration[key] ?? "";
        }
    }
}
