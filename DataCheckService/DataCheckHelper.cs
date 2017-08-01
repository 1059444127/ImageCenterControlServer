using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCheckService
{
    /// <summary>
    /// 数据校验服务
    /// </summary>
    public class DataCheckHelper
    {
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
            if (string.Equals(RawCode,CRCCode))
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
