using log4net;

namespace PrintForms.Helper
{
    public  class Logs
    {
        private static ILog LogInfo = LogDynamicCreate.GetLogger(AppSetting.GetSettingString("StationCode")+"Info");

        private static ILog LogError = LogDynamicCreate.GetLogger(AppSetting.GetSettingString("StationCode")+"Error");

        public static void Write(string message)
        {
            LogInfo.Info(message);
        }

        public static void Error(string message)
        {
            LogError.Error(message);
        }
    }
}
