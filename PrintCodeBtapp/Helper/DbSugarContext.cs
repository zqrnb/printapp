using SqlSugar;

namespace PrintForms.Helper
{
    public class DbSugarContext
    {
        public static readonly SqlSugarClient Db = Init();
        private static SqlSugarClient Init()
        {
            var sqlSugarDb = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = AppSetting.GetSettingString("KukaDBConnectionString"),//必填, 数据库连接字符串
                DbType = DbType.SqlServer,         //必填, 数据库类型
                IsAutoCloseConnection = true
            });
            return sqlSugarDb;
        }

    }
}
