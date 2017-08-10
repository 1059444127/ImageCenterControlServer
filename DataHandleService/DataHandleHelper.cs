using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public DataHandleHelper()
        {

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

            if (CheckData(Data))
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

        #region 获取继电器口控制指令
        /// <summary>
        /// 获取继电器口模式控制指令
        /// </summary>
        /// <param name="PortsOpen">要开启的口，如"1,2,3"</param>
        /// <param name="PortsClose">要关闭的口，如"4,5,6"</param>
        /// <returns></returns>
        public string GetRelayCommand(string PortsOpen, string PortsClose)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=RelayCtl\tON={0}\tOFF={1}", PortsOpen, PortsClose);

            ushort CRCCode = GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode);

            return Command;
        }
        #endregion

        #region 获取投影机控制指令
        /// <summary>
        /// 获取投影机控制指令
        /// </summary>
        /// <param name="ProjectorID">投影机编号</param>
        /// <param name="PowerStatus">电源状态</param>
        /// <returns></returns>
        public string GetProjectorCommand(string ProjectorID, string PowerStatus)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=ProjectorCtl\tID={0}\tPower={1}", ProjectorID, PowerStatus);

            ushort CRCCode = GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode);

            return Command;
        }
        #endregion

        #region 获取矩阵控制指令
        /// <summary>
        /// 获取矩阵控制指令
        /// </summary>
        /// <param name="MatrixIn">矩阵输入，如"1,2,3,4"</param>
        /// <param name="MatrixOut">矩阵输出，如"1,3,2,4"</param>
        /// <returns></returns>
        public string GetMatrixCommand(string MatrixIn, string MatrixOut)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=VideoCtl\tVideoIn={0}\tVideoOut={1}", MatrixIn, MatrixOut);

            ushort CRCCode = GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode);

            return Command;
        }
        #endregion

        #region 获取镜头控制指令
        /// <summary>
        /// 获取镜头控制指令
        /// </summary>
        /// <param name="PowerStatus">电源状态</param>
        /// <param name="EnlargeLevel">缩放等级</param>
        /// <returns></returns>
        public string GetCameraCommand(string PowerStatus, string EnlargeLevel)
        {
            string Command = string.Empty;

            Command = string.Format("cmd=CameraCtl\tPower={0}\tEnlargeLevel={1}", PowerStatus, EnlargeLevel);

            ushort CRCCode = GetCRCCode(Encoding.UTF8.GetBytes(Command));

            Command += string.Format(":CRC={0:x}\r\n", CRCCode);

            return Command;
        }
        #endregion

        #region 数据包封装
        /// <summary>
        /// 封装环境数据包
        /// </summary>
        /// <param name="Heart">解析后的控制器心跳包</param>
        /// <returns>封装后的环境数据包</returns>
        public string PacketEnviroumentData(HeartStruct Heart)
        {
            string DataPacket = string.Empty;
            string CRCCode = string.Empty;

            DataPacket = string.Format("cmd=Enviroument\tControlStatus={0}\tTemp={1}\tHum={2}\tLight={3}\tNoise={4}", Heart.Status, Heart.Temp, Heart.Hum, Heart.Light, Heart.Noise);

            CRCCode = GetCRCCode(DataPacket);

            DataPacket += string.Format(":CRC={0}\r\n", CRCCode);

            return DataPacket;
        }

        /// <summary>
        /// 封装设备状态数据包
        /// </summary>
        /// <param name="Heart">解析后的控制器心跳包</param>
        /// <returns>封装后的设备状态数据包</returns>
        public string PacketDeviceStatusData(HeartStruct Heart)
        {
            string DataPacket = string.Empty;
            string CRCCode = string.Empty;

            DataPacket = string.Format("cmd=DeviceStatus\tControlStatus={0}\tProjector={1}\tVideoIn={2}\tVideoOut={3}\tCameraPower={4}", Heart.Status, Heart.Projector, Heart.VideoIn, Heart.VideoOut, Heart.CameraPower);

            CRCCode = GetCRCCode(DataPacket);

            DataPacket += string.Format(":CRC={0}\r\n", CRCCode);

            return DataPacket;
        }
        #endregion

        #region 获得校验码
        /// <summary>
        /// 获得CRC校验码
        /// </summary>
        /// <param name="Data">待校验的数据</param>
        /// <returns></returns>
        public ushort GetCRCCode(byte[] Data)
        {
            uint IX, IY;

            ushort CRCCode = 0xFFFF;

            int Len = Data.Length;
            if (Len <= 0)
            {
                CRCCode = 0;
            }
            else
            {
                Len--;
                for (IX = 0; IX <= Len; IX++)
                {
                    CRCCode = (ushort)(CRCCode ^ (Data[IX]));

                    for (IY = 0; IY <= 7; IY++)
                    {
                        if ((CRCCode & 1) != 0)
                        {
                            CRCCode = (ushort)((CRCCode >> 1) ^ 0xA001);
                        }
                        else
                        {
                            CRCCode = (ushort)(CRCCode >> 1);
                        }
                    }
                }
            }

            byte buf1 = (byte)((CRCCode & 0xff00) >> 8);//高位置
            byte buf2 = (byte)(CRCCode & 0x00ff); //低位置

            CRCCode = (ushort)(buf1 << 8);

            CRCCode += buf2;

            return CRCCode;
        }

        /// <summary>
        /// 获得CRC校验码
        /// </summary>
        /// <param name="RawData">待校验的数据</param>
        /// <returns></returns>
        public string GetCRCCode(string RawData)
        {
            byte[] Data = Encoding.UTF8.GetBytes(RawData);

            uint IX, IY;

            ushort CRCCode = 0xFFFF;

            string Code = string.Empty;

            int Len = Data.Length;
            if (Len <= 0)
            {
                CRCCode = 0;
            }
            else
            {
                Len--;
                for (IX = 0; IX <= Len; IX++)
                {
                    CRCCode = (ushort)(CRCCode ^ (Data[IX]));

                    for (IY = 0; IY <= 7; IY++)
                    {
                        if ((CRCCode & 1) != 0)
                        {
                            CRCCode = (ushort)((CRCCode >> 1) ^ 0xA001);
                        }
                        else
                        {
                            CRCCode = (ushort)(CRCCode >> 1);
                        }
                    }
                }
            }

            byte buf1 = (byte)((CRCCode & 0xff00) >> 8);//高位置
            byte buf2 = (byte)(CRCCode & 0x00ff); //低位置

            CRCCode = (ushort)(buf1 << 8);

            CRCCode += buf2;

            Code = string.Format("{0:x}", CRCCode);

            return Code;
        }
        #endregion

        #region 校验数据
        /// <summary>
        /// CRC数据校验
        /// </summary>
        /// <param name="Data">待校验的完整数据</param>
        /// <returns></returns>
        public bool CheckData(string Data)
        {
            string[] StrData = Data.Split(':');

            //原始校验码
            string RawCode = StrData[1].Split('=')[1].Replace("\r\n", "");

            //待计算部分转化为字节数组
            byte[] RawData = Encoding.UTF8.GetBytes(StrData[0]);

            //计算出的校验码
            string CRCCode = string.Format("{0:x}", GetCRCCode(RawData));

            //判断
            if (string.Equals(RawCode, CRCCode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
