using FirstWebApplication.Controllers;
using SqlSugar;

namespace Net
{   
    [SugarTable("UserTable")]
    public class UserTable
    {

        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]

        public string SNO { get; set; }

       
        public string SNAME { get; set; }
        public string SAGE { get; set; }

        internal static Task UpdateAsync(UserTable userTable)
        {
            throw new NotImplementedException();
        }

     
     
    }
}
