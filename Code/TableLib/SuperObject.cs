using System;
using System.Collections.Generic;
using System.Text;

namespace TableLib
{
    public class SuperObject
    {
        Dictionary<string, object> dataDict = new Dictionary<string, object>();
        /// <summary>
        /// 公共参数字典(用于给脚本提供必要的参数)
        /// </summary>
        public Dictionary<string, object> DataDict
        {
            get { return dataDict; }
        }
    }
}