﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IDAL
{
    public interface IBBSTopic
    {
        /// <summary>
        /// 获取前几行主贴列表
        /// </summary>
        /// <param name="top">前top行</param>
        /// <returns>数据表</returns>
        DataSet GetList(int top);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Uid">用户id</param>
        /// <returns>对象实体</returns>
        Model.BBSTopic GetModel(int Uid);
    }
}
