﻿using RiskProfilingApp.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskProfilingApp
{
    public partial class UserReports : System.Web.UI.Page
    {
        DatabaseHandler handler = new DatabaseHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";

                if (IsPostBack == false)
                {
                    GetAllUsers();
                }
            }
            catch (Exception ee)
            {
                //Response.Redirect("UserLogin.aspx");
            }
        }

        private void GetAllUsers()
        {
            DataTable dtActivity = handler.GetDataFromAppDT("GetAllUsers", new object[] { });
            GridData.DataSource = dtActivity;
            GridData.DataBind();
            GridData.Visible = true;
        }
        protected void downloadClicked(object sender, EventArgs e)
        {
            string fileName = "UserReport";
            string filePath = @"C:\Users\public\downloads\" + fileName + ".csv";
            DataTable dset = handler.GetDataFromAppDT("GetAllUsers", new object[] { });
            ToCSV(dset, filePath);
        }
        protected void ToCSV(DataTable dtDataTable, string strFilePath)
        {

            var dataList = new List<string>();
            string header = "";
            foreach (DataColumn column in dtDataTable.Columns)
            {
                header += column.ColumnName + ",";
            }
            // dataList.AddRange(header.Split(new string[] { "," }, StringSplitOptions.None));
            dataList.Add(header);
            foreach (DataRow drow in dtDataTable.Rows)
            {
                string row = "";
                foreach (DataColumn column in dtDataTable.Columns)
                {
                    row += drow[column.ColumnName].ToString().Replace(",", "_") + ",";

                }
                dataList.Add(row);

            }
            File.WriteAllLines(strFilePath, dataList.ToArray());
            string ext = Path.GetExtension(strFilePath);
            DownloadingFile(strFilePath, ext);

        }

        public void DownloadingFile(string filePath, string type)
        {

            switch (type)
            {
                case ".xls":
                    type = "excel";
                    break;

                case ".xlsx":
                    type = "excel";

                    break;

                case ".pdf":
                    type = "pdf";

                    break;
                case ".csv":
                    type = "csv";

                    break;
                case ".docx":
                    type = "docx";

                    break;
                case ".doc":
                    type = "doc";

                    break;
            }

            if (!(string.IsNullOrEmpty(type)))
            {
                try
                {
                    //filePath = @"E:\+Jackie\downloadedfiles\PayGo UMEME UAT.docx";
                    FileInfo file = new FileInfo(filePath);
                    HttpContext.Current.Response.Redirect("", false);
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ClearHeaders();
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                    HttpContext.Current.Response.ContentType = type;
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.TransmitFile(file.FullName);
                    HttpContext.Current.Response.End();
                }
                catch (Exception ee)
                {
                    //DatabaseHandler.handler.InsertErrorLog("Error downlading file because :  ", "" + ee);
                }
            }
        }
    }
}

