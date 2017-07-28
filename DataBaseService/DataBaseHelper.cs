using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataBaseService
{
    /// <summary>
    /// 数据库操作服务
    /// </summary>
    public class DataBaseHelper
    {
        #region 全局变量
        /// <summary>
        /// 数据库连接实例
        /// </summary>
        private MySqlConnection Connection;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="SQLConnection">数据库连接语句</param>
        public DataBaseHelper(string SQLConnection)
        {
            InitDataBaseService(SQLConnection);
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="SQLConnection"></param>
        private void InitDataBaseService(string SQLConnection)
        {
            try
            {
                Connection = new MySqlConnection(SQLConnection);
                Connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("数据库连接失败，请检查数据库配置");
            }
        }
        #endregion

        #region 操作数据库
        /// <summary>
        /// 增删改数据表
        /// </summary>
        /// <param name="SQLString">数据库操作语句</param>
        /// <returns>执行结果</returns>
        public bool UpdateTable(string SQLString)
        {
            try
            {
                MySqlCommand Command = new MySqlCommand(SQLString, Connection);
                Command.ExecuteNonQuery();
                Command.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 查询数据库
        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>保存查询结果的数据表</returns>
        public DataTable SelectTable(string SQLString)
        {
            DataTable Table = new DataTable();

            try
            {
                MySqlDataAdapter Adapter = new MySqlDataAdapter(SQLString, Connection);
                Adapter.Fill(Table);
                return Table;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 关闭数据库
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Dispose()
        {
            try
            {
                Connection.Close();
                Connection.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
