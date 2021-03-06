﻿using System;
using System.Data;
using System.Collections.Generic;
 
namespace ALineScrewDB.BLL
{
    /// <summary>
    /// db
    /// </summary>
    public partial class dbBLL
    {
        private readonly ALineScrewDB.dbDAL dal = new ALineScrewDB.dbDAL();
        public dbBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 二维码)
        {
            return dal.Exists(二维码);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALineScrewDB.dbModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ALineScrewDB.dbModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string 二维码)
        {

            return dal.Delete(二维码);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string 二维码list)
        {
            return dal.DeleteList(二维码list);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALineScrewDB.dbModel GetModel(string 二维码)
        {

            return dal.GetModel(二维码);
        }

        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ALineScrewDB.dbModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ALineScrewDB.dbModel> DataTableToList(DataTable dt)
        {
            List<ALineScrewDB.dbModel> modelList = new List<ALineScrewDB.dbModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ALineScrewDB.dbModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public dbModel GetModelByModuleID(string moduleID)
        {
            string sqlStr = " 二维码 = '" + moduleID + "'";
            List<dbModel> screwdata = GetModelList(sqlStr);
            if(screwdata!= null && screwdata.Count>0)
            {
                return screwdata[0];
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}

