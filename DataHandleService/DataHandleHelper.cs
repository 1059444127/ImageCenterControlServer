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
        #region 全局变量
        /// <summary>
        /// 心跳包结构体
        /// </summary>
        public struct HeartStruct
        {
            /// <summary>
            /// 控制器电源状态
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// 控制器运行时间
            /// </summary>
            public string Runtime { get; set; }

            /// <summary>
            /// 房间内温度
            /// </summary>
            public string Temp { get; set; }

            /// <summary>
            /// 房间内湿度
            /// </summary>
            public string Hum { get; set; }

            /// <summary>
            /// 房间内光照
            /// </summary>
            public string Light { get; set; }

            /// <summary>
            /// 房间内噪音
            /// </summary>
            public string Noise { get; set; }

            /// <summary>
            /// 打开的继电器口状态
            /// </summary>
            public string Relays { get; set; }

            /// <summary>
            /// 矩阵输入信号
            /// </summary>
            public string VideoIn { get; set; }

            /// <summary>
            /// 矩阵输出信号
            /// </summary>
            public string VideoOut { get; set; }

            /// <summary>
            /// 投影机电源状态
            /// </summary>
            public string Projector { get; set; }

            /// <summary>
            /// 镜头电源状态
            /// </summary>
            public string CameraPower { get; set; }
        }

        /// <summary>
        /// 数据校验服务
        /// </summary>
        private DataCheckHelper DataCheck;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public DataHandleHelper()
        {
            DataCheck = new DataCheckHelper();
        }
        #endregion

        #region 心跳包解析
        /// <summary>
        /// 获取心跳包内容
        /// </summary>
        /// <param name="Data"></param>
        /// <returns>心跳包结构体</returns>
        public HeartStruct GetHeartbeat(string Data)
        {
            HeartStruct Heart = new HeartStruct();

            if (DataCheck.CheckData(Data))
            {
                string HeartData = Data.Split(':')[0];

                foreach (string item in HeartData.Split('\t'))
                {
                    switch (item.Split('=')[0])
                    {
                        case "Status":
                            Heart.Status = item.Split('=')[1];
                            break;
                        case "Runtime":
                            Heart.Runtime = item.Split('=')[1];
                            break;
                        case "Temp":
                            Heart.Temp = item.Split('=')[1] + "℃";
                            break;
                        case "Hum":
                            Heart.Hum = item.Split('=')[1] + "%";
                            break;
                        case "Light":
                            Heart.Light = item.Split('=')[1] + "LUX";
                            break;
                        case "Noise":
                            Heart.Noise = item.Split('=')[1] + "DB";
                            break;
                        case "Relays":
                            Heart.Relays = item.Split('=')[1];
                            break;
                        case "VideoIn":
                            Heart.VideoIn = item.Split('=')[1];
                            break;
                        case "VideoOut":
                            Heart.VideoOut = item.Split('=')[1];
                            break;
                        case "Projector":
                            Heart.Projector = item.Split('=')[1];
                            break;
                        case "CameraPower":
                            Heart.CameraPower = item.Split('=')[1];
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("获取到错误数据");
            }
            return Heart;
        }
        #endregion

        #region 数据包封装
        /// <summary>
        /// 封装客户端数据包
        /// </summary>
        /// <param name="Heart">解析后的控制器心跳包</param>
        /// <returns></returns>
        public string GetClientDataPacket(HeartStruct Heart)
        {
            string DataPacket = string.Empty;
            string CRCCode = string.Empty;

            DataPacket = string.Format("cmd=Enviroument\tTemp={0}\tHum={1}\tLight={2}\tNoise={3}");

            CRCCode = DataCheck.GetCRCCode(DataPacket);

            DataPacket += string.Format(":CRC={0}\r\n", CRCCode);

            return DataPacket;
        }
        #endregion
    }
}
