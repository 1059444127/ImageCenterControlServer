using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataBaseService
{
    /// <summary>
    /// 数据库操作服务
    /// </summary>
    public class DataBaseHelper
    {
        /// <summary>
        /// 数据库连接实例
        /// </summary>
        private MySqlConnection Connection;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="SQLConnection">数据库连接语句</param>
        public DataBaseHelper(string SQLConnection)
        {
            InitDataBaseService(SQLConnection);
        }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="SQLConnection"></param>
        private void InitDataBaseService(string SQLConnection)
        {
            try
            {
                Connection = new MySqlConnection(SQLConnection);
            }
            catch (Exception)
            {
                throw new Exception("数据库连接失败，请检查数据库配置");
            }
        }

        public void InsertData()
        {

        }

        public void DeleteData()
        {

        }

        public void UpdateData()
        {

        }

        public void SelectData()
        {

        }
    }
}
