using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseInterface
{
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public interface IDatabaseInterface
    {
        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="SQLConnection"></param>
        void InitDataBaseService(string SQLConnection);

        /// <summary>
        /// 增删改查数据库
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        bool UpdateTable(string SQLString);

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        DataTable SelectTable(string SQLString);

        /// <summary>
        /// 关闭数据库
        /// </summary>
        void Dispose();
    }
}
