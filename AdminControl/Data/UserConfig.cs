using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdminControl
{
    class UserConfig
    {
        /// <summary>
        /// 配置文件目录
        /// </summary>
        private string ConfigDirPath;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="ConfigDirPath"></param>
        public UserConfig(string ConfigDirPath)
        {
            this.ConfigDirPath = ConfigDirPath;
        }
    }
}
