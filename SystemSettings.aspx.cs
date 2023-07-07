using RiskProfilingApp.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskProfilingApp
{
    public partial class SystemSettings : System.Web.UI.Page
    {
        DatabaseHandler handler = new DatabaseHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    InitailizeControls();
                }
                catch (Exception ee)
                {
                    Response.Redirect("Login.aspx", true);

                }

            }
        }
        public void InitailizeControls()
        {

        }

        protected void _ddItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedValue"] = _ddItems.SelectedValue.ToString();
            if (_ddItems.SelectedValue == "Countries")
            {             
                DataSet dset = handler.GetDatas("getCountries", new object[] { });
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
            else if (_ddItems.SelectedValue == "Channels")
            {
                DataSet dset = handler.GetDatas("getDistributionChannels", new object[] { });
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
            else if (_ddItems.SelectedValue == "Income")
            {
                DataSet dset = handler.GetDatas("getIncomeBands", new object[] { });
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
            else if (_ddItems.SelectedValue == "Products")
            {
                DataSet dset = handler.GetDatas("getProducts", new object[] { });
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
            else if (_ddItems.SelectedValue == "Clients")
            {
                DataSet dset = handler.GetDatas("getClientTypes", new object[] { });
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
            else if (_ddItems.SelectedValue== "Business")
            {
                DataSet dset = handler.GetDatas("getBusinesses", new object[] { });
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
            else
            {

            }
          
        }

        protected void _btnEdit2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _addnewdiv.Visible = true;
           
            if(_ddItems.SelectedValue == "Countries")
            {
                Label1.Visible = false;
                _category.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Channels")
            {
                Label1.Visible = false;
                _category.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Income")
            {
                Label1.Visible = false;
                _category.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Products")
            {
                DataTable tables = handler.GetDataFromAPIDT("getProductsCategory", new object[] { });
                if (tables.Rows.Count > 0)
                {
                    _category.DataSource = tables;
                    _category.DataTextField = "Category";
                    _category.DataValueField = "Category";
                    _category.DataBind();
                }
            }
            else if (_ddItems.SelectedValue == "Clients")
            {
                DataTable tables = handler.GetDataFromAPIDT("getProductsClient", new object[] { });
                if (tables.Rows.Count > 0)
                {
                    _category.DataSource = tables;
                    _category.DataTextField = "Category";
                    _category.DataValueField = "Category";
                    _category.DataBind();
                }
            }
            else if (_ddItems.SelectedValue == "Business")
            {
                DataTable tables = handler.GetDataFromAPIDT("getBusinessProduct", new object[] { });
                if (tables.Rows.Count > 0)
                {
                    _category.DataSource = tables;
                    _category.DataTextField = "Category";
                    _category.DataValueField = "Category";
                    _category.DataBind();
                }
            }
            else
            {

            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string _loggedUser = Session["fullname"].ToString();
            if (_ddItems.SelectedValue == "Countries")
            {
                int count = handler.InsertData("AddMakerChanges", new object[] { _ddItems.SelectedValue,"", "0", codes.Text.ToString(), _description.Text.ToString(), dd_chooses.SelectedValue, _loggedUser, _loggedUser, "ADD NEW" });
                lblmsg.Text = "Submission Made Successfully. Pending Verification";
                _addnewdiv.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Channels")
            {
                int count = handler.InsertData("AddMakerChanges", new object[] { _ddItems.SelectedValue,"", "0", codes.Text.ToString(), _description.Text.ToString(), dd_chooses.SelectedValue, _loggedUser, _loggedUser, "ADD NEW" });
                lblmsg.Text = "Submission Made Successfully. Pending Verification";
                _addnewdiv.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Income")
            {
                int count = handler.InsertData("AddMakerChanges", new object[] { _ddItems.SelectedValue,"", "0", codes.Text.ToString(), _description.Text.ToString(), dd_chooses.SelectedValue, _loggedUser, _loggedUser, "ADD NEW" });
                lblmsg.Text = "Submission Made Successfully. Pending Verification";
                _addnewdiv.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Products")
            {                
                int count = handler.InsertData("AddMakerChanges", new object[] { _ddItems.SelectedValue, _category.SelectedValue, "0", codes.Text.ToString(), _description.Text.ToString(), dd_chooses.SelectedValue, _loggedUser, _loggedUser, "ADD NEW" });
                lblmsg.Text = "Submission Made Successfully. Pending Verification";
                _addnewdiv.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Clients")
            {              
                int count = handler.InsertData("AddMakerChanges", new object[] { _ddItems.SelectedValue, _category.SelectedValue, "0", codes.Text.ToString(), _description.Text.ToString(), dd_chooses.SelectedValue, _loggedUser, _loggedUser, "ADD NEW" });
                lblmsg.Text = "Submission Made Successfully. Pending Verification";
                _addnewdiv.Visible = false;
            }
            else if (_ddItems.SelectedValue == "Business")
            {               
                int count = handler.InsertData("AddMakerChanges", new object[] { _ddItems.SelectedValue, _category.SelectedValue, "0", codes.Text.ToString(), _description.Text.ToString(), dd_chooses.SelectedValue, _loggedUser, _loggedUser, "ADD NEW" });
                lblmsg.Text = "Submission Made Successfully. Pending Verification";
                _addnewdiv.Visible = false;

            }
            else
            {

            }
        }
    }
}