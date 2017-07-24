using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCheckService;

namespace DataHandleService
{
    /// <summary>
    /// 数据解析服务
    /// </summary>
    public class DataHandleHelper
    {
        /// <summary>
        /// 数据校验服务
        /// </summary>
        private DataCheckHelper DataCheck;

        /// <summary>
        /// 构造器
        /// </summary>
        public DataHandleHelper()
        {
            DataCheck = new DataCheckHelper();
        }

        /// <summary>
        /// 获取房间温度
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseTemp(string Data)
        {
            string Temp = string.Empty;

            string[] DataStr = Data.Split(' ');

            if ((DataStr.Length != 17) || (DataStr[DataStr.Length - 1] != "CRC=f754\r\n"))
            {
                Temp = "ERROR";
                return Temp;
            }

            //数据处理
            Temp = Data.Split(' ')[3].Split('=')[1];

            return Temp + " ℃";
        }

        /// <summary>
        /// 获取房间湿度
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseHum(string Data)
        {
            string Hum = string.Empty;

            string[] DataStr = Data.Split(' ');

            if ((DataStr.Length != 17) || (DataStr[DataStr.Length - 1] != "CRC=f754\r\n"))
            {
                Hum = "ERROR";
                return Hum;
            }

            //数据处理
            Hum = Data.Split(' ')[4].Split('=')[1];

            return Hum + " %";
        }

        /// <summary>
        /// 获取房间光照
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseLight(string Data)
        {
            string Light = string.Empty;

            string[] DataStr = Data.Split(' ');

            if ((DataStr.Length != 17) || (DataStr[DataStr.Length - 1] != "CRC=f754\r\n"))
            {
                Light = "ERROR";
                return Light;
            }

            //数据处理
            Light = Data.Split(' ')[5].Split('=')[1];

            return Light + " LUX";
        }

        /// <summary>
        /// 获取房间噪音
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string GetHouseNoise(string Data)
        {
            string Noise = string.Empty;

            string[] DataStr = Data.Split(' ');

            if ((DataStr.Length != 17) || (DataStr[DataStr.Length - 1] != "CRC=f754\r\n"))
            {
                Noise = "ERROR";
                return Noise;
            }

            //数据处理
            Noise = Data.Split(' ')[6].Split('=')[1];

            return Noise + " DB";
        }
    }
}
