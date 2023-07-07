using RiskProfilingApp.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskProfilingApp
{

    public partial class Configurations : System.Web.UI.Page
    {
        DatabaseHandler handler = new DatabaseHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                try
                {
                    InitializeControls();
                }
                catch (Exception ee)
                {
                    //Response.Redirect("UserLogin.aspx", true);

                }

            }
        }
        private void InitializeControls()
        {
            string _loggedUser = Session["fullname"].ToString();
            try
            {
                lblmsg.Text = "";

                Getgridtable();
                GetUserRoles();

                _countries.DataSource = handler.GetDataFromAPIDT("getCountries", new object[] { });
                _countries.DataTextField = "Description";
                _countries.DataValueField = "Description";
                _countries.DataBind();

                DataTable reasons = handler.GetDataFromAPIDT("getCountries", new object[] { });
                GridData.DataSource = reasons;
                GridData.DataBind();


                //DataTable letters = handler.GetDataFromAPIDT("getBusinesses", new object[] { });
                //GridView2.DataSource = letters;
                //GridView2.DataBind();

                DataTable ddnotice = handler.GetDataFromAPIDT("getDistributionChannels", new object[] { });
                GridView1.DataSource = ddnotice;
                GridView1.DataBind();

                DataTable nexxtAction = handler.GetDataFromAPIDT("getIncomeBands", new object[] { });
                GridView3.DataSource = nexxtAction;
                GridView3.DataBind();
                //getProducts

            }
            catch (Exception ee)
            {
                // lblmsg.Text = "Error Getting Settings. Please contact your administrator";
                handler.InsertErrorLog("Configurations Page Load", "" + ee.Message + " By " + _loggedUser);
            }
        }

        protected void ActionButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(actionNames.Text))
            {
                lblmsg.Text = "Please Input Next Action";
            }

            else
            {
                SaveActionData();
            }
        }

        protected void saveBtnOnclick(object sender, EventArgs e)
        {
            string _loggedUser = Session["fullname"].ToString();
            string descr = descriptions.Text;
            handler.InsertLoginLog("Configuration Page Edited For : " + descr, _loggedUser);

            if (dd_values.SelectedValue == "High")
            {

                int count = handler.InsertDataAPI("UpdateCountryScore", new object[] { "3", descr });

                if (count > 0)
                {
                    lblmsg.Text = "Update Successful";
                }

            }
            else if (dd_values.SelectedValue == "Medium")
            {

                int count = handler.InsertDataAPI("UpdateCountryScore", new object[] { "2", descr });
                if (count > 0)
                {
                    lblmsg.Text = "Update Successful";
                }
            }
            else if (dd_values.SelectedValue == "Low")
            {

                int count = handler.InsertDataAPI("UpdateCountryScore", new object[] { "1", descr });
                if (count > 0)
                {
                    lblmsg.Text = "Update Successful";
                }
            }
            else
            {

            }
        }

        protected void LetterUploadBtn(object sender, EventArgs e)
        {

            if (!letterUploadFile.HasFile)
            {
                lblmsg.Text = "Please select letter to upload";
            }
            else if (string.IsNullOrEmpty(letterTitle.Text))
            {
                lblmsg.Text = "Please Input Letter Title";
            }

            else
            {
                SaveLetterData();
            }
        }

        private void SaveLetterData()
        {
            string _loggedUser = Session["fullname"].ToString();
            string filePath = letterUploadFile.PostedFile.FileName; // getting the file path of uploaded file
            FileInfo fi = new FileInfo(filePath);
            string filename = fi.Name;     // getting the file name of uploaded file
            string ext = Path.GetExtension(filename);          // getting the file extension of uploaded file
            string type = String.Empty;

            try
            {

                switch (ext)
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

                if (!(String.IsNullOrEmpty(type)))
                {

                    //string finalPath = @"E:\+Jackie\downloadedfiles\Uploads\" + DateTime.Now.ToString("yyMMddhhmmssff") + "_" + FileUpload1.PostedFile.FileName;
                    //FileUpload1.SaveAs(finalPath);
                    //string Upp = Convert.ToBase64String(File.ReadAllBytes(finalPath));


                    Stream fs = letterUploadFile.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);  //reads the   binary files
                    byte[] fbytes = br.ReadBytes(letterUploadFile.PostedFile.ContentLength);  //counting the file length into bytes

                    string Upp = Convert.ToBase64String(fbytes);
                    string PrefferedName = letterTitle.Text;
                    //br.Close();
                    //fs.Close();
                    handler.InsertData("InsertNewUpload", new object[] { filename, Upp, PrefferedName, "", _loggedUser, "Letters" });

                    letterTitle.Text = "";
                    DataSet lets = handler.GetData("GetLetters", new object[] { });
                    //GridView2.DataSource = lets;
                    //GridView2.DataBind();

                }
                else
                {
                    letterTitle.Text = "";
                    lblmsg.Text = "File format not supported. Please contact your administrator";
                }
            }
            catch (Exception ex)
            {
                handler.InsertData("InsertErrorLog", new object[] { "Error Uploading file Because : ", "" + ex, _loggedUser });
            }
        }

        protected void ddAddition(object sender, EventArgs e)
        {

            if (!FileUpload2.HasFile)
            {
                lblmsg.Text = "Please select letter to upload";
            }
            else if (string.IsNullOrEmpty(ddNotice.Text))
            {
                lblmsg.Text = "Please Input Demand Notice Title";
            }
            else
            {
                SaveDemandData();
            }
        }

        protected void GridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string Id = Convert.ToString(GridData.DataKeys[intIndex].Value);

                DataTable table = handler.GetData("NewUploads_GetFileById", new string[] { Id }).Tables[0];
                if (table.Rows.Count > 0)
                {
                    string base64StringUpload = table.Rows[0]["Upp"].ToString();
                    string fileName = table.Rows[0]["FileBytes"].ToString();
                    byte[] fileBytes = Convert.FromBase64String(base64StringUpload);
                    string filePath = @"E:\+Jackie\downloadedfiles\" + fileName;
                    File.WriteAllBytes(filePath, fileBytes);


                    FileInfo fi = new FileInfo(filePath);
                    string ext = Path.GetExtension(fileName);
                    DownloadFile(filePath, ext);

                }

            }
            catch (Exception ex)
            {
                string _loggedUser = Session["fullname"].ToString();
                handler.InsertData("InsertErrorLog", new object[] { "Error downloading File because : ", "" + ex, _loggedUser });
            }
        }

        public void DownloadFile(string filePath, string type)
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

                case ".txt":
                    type = "txt";

                    break;
            }

            if (string.IsNullOrEmpty(type))
            {
                try
                {
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
                    string _loggedUser = Session["fullname"].ToString();
                    handler.InsertData("InsertErrorLog", new object[] { "Error Uploading File because : ", "" + ee, _loggedUser });
                }
            }
        }

        private void SaveActionData()
        {
            string _loggedUser = Session["fullname"].ToString();

            try
            {
                string PrefferedName = actionNames.Text;
                handler.InsertData("InsertNewUpload", new object[] { "", "", PrefferedName, "", _loggedUser, "NextActions" });

                actionNames.Text = "";
                DataTable reasons = handler.GetDataFromAPIDT("GetNextActions", new object[] { });
                GridView3.DataSource = reasons;
                GridView3.DataBind();
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error Uploading Next Action. Please Contact Administrator";
                handler.InsertData("InsertErrorLog", new object[] { "Error Uploading Next Actions: ", "" + ex, _loggedUser });
            }
        }

        private void SaveDemandData()
        {
            string _loggedUser = Session["fullname"].ToString();
            string filePath = FileUpload2.PostedFile.FileName; // getting the file path of uploaded file
            FileInfo fi = new FileInfo(filePath);
            string filename = fi.Name;     // getting the file name of uploaded file
            string ext = Path.GetExtension(filename);          // getting the file extension of uploaded file
            string type = String.Empty;

            try
            {
                switch (ext)
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

                if (!(String.IsNullOrEmpty(type)))
                {
                    Stream fs = FileUpload2.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);  //reads the   binary files
                    byte[] fbytes = br.ReadBytes(FileUpload2.PostedFile.ContentLength);  //counting the file length into bytes

                    string Upp = Convert.ToBase64String(fbytes);
                    string PrefferedName = ddNotice.Text;
                    handler.InsertData("InsertNewUpload", new object[] { filename, Upp, PrefferedName, "", _loggedUser, "DemandNotice" });

                    ddNotice.Text = "";
                    DataTable ddnotice = handler.GetDataFromAPIDT("GetDemandNotice", new object[] { });
                    GridView1.DataSource = ddnotice;
                    GridView1.DataBind();
                }
                else
                {
                    ddNotice.Text = "";
                    lblmsg.Text = "File format not supported. Please contact your administrator";
                }
            }
            catch (Exception ex)
            {
                // string _loggedUser = Session["fullname"].ToString();
                handler.InsertData("InsertErrorLog", new object[] { "Error Uploading file Because : ", "" + ex, _loggedUser });
            }
        }
        protected void GridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
        private void GetUserRoles()
        {
            dd_values.DataSource = handler.GetDataFromAppDT("GetUsableStatuses", new object[] { });
            dd_values.DataTextField = "Status";
            dd_values.DataValueField = "Status";
            dd_values.DataBind();
        }
        private void Getgridtable()
        {
            try
            {
                lblmsg.Text = "";
                string _loggedUser = Session["fullname"].ToString();
                DataSet dset = handler.GetData("getCountries", new object[] { });
                handler.InsertLoginLog("Accessed Countries Configurations Page", _loggedUser);
                var table = DataExtractor.GetDatasTable(dset.Tables[0]);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    var jsonResponse = new JavaScriptSerializer().Serialize(new
                    {
                        ErrorCode = "0",
                        ErrorDescription = "Success",
                        DataTable = table
                    });
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "12345", "PopulateDataTable('" + jsonResponse + "')", true);
                }
                else
                {
                    var jsonResponse = new JavaScriptSerializer().Serialize(new
                    {
                        ErrorCode = "100",
                        ErrorDescription = "Failed"
                    });
                    ScriptManager.RegisterStartupScript(this, Page.GetType(), "12345", "PopulateDataTable('" + jsonResponse + "')", true);

                }
            }
            catch (Exception ee)
            {

            }
        }
        protected void _countriesBT_Click(object sender, EventArgs e)
        {

            DataTable table = handler.GetDataFromAPIDT("getCountriesExplicit", new object[] { _countries.SelectedValue });
            if (table.Rows.Count != 0)
            {
                _countryVw.Visible = true;
                foreach (DataRow drow in table.Rows)
                {
                    ids.Text = drow["ID"].ToString();
                    codes.Text = drow["Code"].ToString();
                    descriptions.Text = drow["Description"].ToString();
                    values.Text = drow["Value"].ToString();
                    creationdt.Text = drow["Created"].ToString();

                }
            }
            else
            {
                lblmsg.Text = "Error Occured. Please try again Later";
            }
        }

    }
}
