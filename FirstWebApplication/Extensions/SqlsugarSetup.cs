using FirstWebApplication.Controllers;
using Net;
using SqlSugar;

namespace FirstWebApplication.Extensions
{
    //建一个扩展类
    /// <summary>
    /// 静态类没法注入
    /// </summary>
    public static class SqlsugarSetup
    {
        
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="dbName"></param>
        /// 

        static SqlSugarClient Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.19.71.155)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));PASSWORD=bmis_js2;PERSIST SECURITY INFO=True;USER ID=bmis_js2; enlist=dynamic;",//连接符字串
            DbType = DbType.Oracle, //数据库类型
            IsAutoCloseConnection = true //不设成true要手动close
        });

        public static object? UserTable { get; internal set; }

        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration,
        string dbName = "db_master")
        {
            SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.Oracle,
                ConnectionString = configuration[dbName],
                IsAutoCloseConnection = true,
            },
                db =>
                {
                //单例参数配置，所有上下文生效
                db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                    Console.WriteLine(sql);//输出sql
                };
                });
            services.AddSingleton<ISqlSugarClient>(sqlSugar);//这边是SqlSugarScope用AddSingleton
        }

        internal static IDisposable GetInstance()
        {
            throw new NotImplementedException();
        }

       
   
    }
}
