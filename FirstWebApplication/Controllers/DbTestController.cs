using FirstWebApplication.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net;
using SqlSugar;



namespace FirstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private object _SqlsugarSetup;

        //构造函数
        public DbTestController(ISqlSugarClient db)
        {
            Db = db;
        }

        //如果就在这个方法使用，用private
        private ISqlSugarClient Db { get; }


        private IActionResult Ok(object p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserTable> GertList()
        {
            return Db.Queryable<UserTable>().ToList();
        }
        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="id"></param>
        /// 


        //[HttpPost]


        //public iinsertable<UserTable> iinsertable(UserTable SqlsugarSetup)
        //{
        //    return SqlsugarSetup.iinsertable(SqlsugarSetup);
        //}

        [HttpPost]
 

      



        ///修改数据
        [HttpPut]




        ///删除数据
        [HttpDelete("{sno}")]
        public void Delete(int sno)
        {
        
        }

    internal record struct NewStruct(UserTable Item1, object Item2)
    {
        public static implicit operator (UserTable, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((UserTable, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}
}
