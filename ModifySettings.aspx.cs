using RiskProfilingApp.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskProfilingApp
{
    public partial class ModifySettings : System.Web.UI.Page
    {
        DatabaseHandler handler = new DatabaseHandler();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack == false)
            {
                initializeControls();

            }
            else
            {
                //Response.Redirect("UserLogin.aspx");
            }
        }

        private void initializeControls()
        {
            lblmsg.Text = "";
            string _loggedUser = Session["fullname"].ToString();
            if (Request.QueryString["Code"] != null)
            {

                string _account = Request.QueryString["Code"];


                DataTable table = handler.GetDataFromAPIDT("getProfileDetails", new object[] { _account });
                foreach (DataRow drow in table.Rows)
                {
                    codes.Text = drow["Code"].ToString();
                    _description.Text = drow["Description"].ToString();
                    _value.Text = drow["Value"].ToString();
                    creationdt.Text = drow["Created"].ToString();
                    lastmodifiedBy.Text = drow["ModifiedBy"].ToString();
                    _modified.Text = drow["Modified"].ToString();
                }
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string _selectedValue = Session["SelectedValue"].ToString();
            string _loggedUser = Session["fullname"].ToString();
            string ena = Session["AccessLevel"].ToString();
           
            if (ena =="005")
            {
                if (dd_chooses.SelectedValue != _value.Text && dd_chooses.SelectedValue != "Select Option")
                {
                    int count = handler.InsertData("AddMakerChanges", new object[] { _selectedValue, "", "0", codes.Text.ToString(), _description.Text.ToString(), dd_chooses.SelectedValue, _loggedUser, _loggedUser,"MODIFY" });

                    lblmsg.Text = "Submission Made Successfully. Pending Verification";
                    dd_chooses.Enabled = false;
                   // Response.Redirect("SystemSettings.aspx");
                }
                else
                {
                    lblmsg.Text = "No submission made. Selections made are invalid";
                }
            }

            else
            {
                lblmsg.Text = "Operation Failed, Please contact the Administrator";
            }
        }

        protected void editoptions_Click(object sender, EventArgs e)
        {
            dd_chooses.Enabled = true;
        }
    }
}