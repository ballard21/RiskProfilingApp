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
    public partial class CheckerVerification : System.Web.UI.Page
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
                    // Response.Redirect("UserLogin.aspx", true);

                }

            }
        }

        private void InitializeControls()
        {
            rejec.Visible = false;
            string _loggedUser = Session["fullname"].ToString();
            lblmsg.Text = "";

            if (Request.QueryString["Account"] != null)
            {

                string _account = Request.QueryString["Account"];

                DataTable table = handler.GetDataFromAppDT("getAllMakerChanges", new object[] { _loggedUser });
                foreach (DataRow drow in table.Rows)
                {
                    handler.InsertLoginLog(_account + " Checker Verification", _loggedUser);
                    username.Text = drow["Category"].ToString();
                    fullname.Text = drow["Category2"].ToString();
                    role.Text = drow["Code"].ToString();
                    phones.Text = drow["Description"].ToString();
                    status.Text = drow["Value"].ToString();
                    Label2.Text = drow["Modified"].ToString();
                    Label4.Text = drow["ModifiedBy"].ToString();
                    Label6.Text = drow["Options"].ToString();
                }
            }
        }

        protected void saveBtnOnclick(object sender, EventArgs e)
        {
            string _loggedUser = Session["fullname"].ToString();
            if (dd_choose.SelectedValue == "Reject")
            {

                int count = handler.InsertData("UpdateMakerTable", new object[] { role.Text.ToString(), _loggedUser, rejctreason.Text.ToString(), "REJECTED" });

                handler.InsertLoginLog(role.Text + " Rejected ", _loggedUser);
                lblmsg.Text = "Rejected Successfully";
                Response.Redirect("SystemSettings.aspx");
            }
            else if (dd_choose.SelectedValue == "Approve")
            {
                int count = handler.InsertData("UpdateMakerTable", new object[] { role.Text.ToString(), _loggedUser, "", "APPROVED" });
                if (count > 0)
                {
                    int counts = handler.InsertDataAPI("UpdateRiskRatings", new object[] { username.Text, fullname.Text, Label6.Text, role.Text, phones.Text, Convert.ToInt32(status.Text), "System" });

                    handler.InsertLoginLog(role.Text + " Approved ", _loggedUser);
                    lblmsg.Text = "Approved Successfully";
                    Response.Redirect("SystemSettings.aspx");
                }
            }
            else
            {

            }

        }

        protected void dd_choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dd_choose.SelectedValue == "Reject")
            {
                rejec.Visible = true;
            }
            else
            {

            }
        }
    }
}