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
    public partial class MaintainUsers : System.Web.UI.Page
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
            string _loggedUser = Session["fullname"].ToString();
            lblmsg.Text = "";
            GetUserRoles();

            if (Request.QueryString["Account"] != null)
            {

                string _account = Request.QueryString["Account"];

                DataTable table = handler.GetDataFromAppDT("UpdateUser", new object[] { _account });
                foreach (DataRow drow in table.Rows)
                {
                    handler.InsertLoginLog(_account+ " User Updated" , _loggedUser);
                    username.Text = drow["Username"].ToString();
                    fullname.Text = drow["Fullname"].ToString();
                    role.Text = drow["Role"].ToString();
                    phones.Text = drow["PhoneNubmer"].ToString();
                    status.Text = drow["Active"].ToString();
                    creationdt.Text = drow["RecordDate"].ToString();
                    lastlogindate.Text = drow["LastLoginDate"].ToString();
                    accessLevel.Text = drow["AccessLevel"].ToString();

                }

            }
        }

        private void GetUserRoles()
        {

            dd_choose.DataSource = handler.GetDataFromAppDT("GetAccountStatus", new object[] { });
            dd_choose.DataTextField = "Status";
            dd_choose.DataValueField = "Status";
            dd_choose.DataBind();
        }

        protected void saveBtnOnclick(object sender, EventArgs e)
        {
            string _loggedUser = Session["fullname"].ToString();

            string ena = dd_choose.SelectedValue;
            if (ena == "Enable")
            {
               
                ena = "1";
                int count = handler.InsertData("UpdateUserss", new object[] { ena, username.Text, _loggedUser });
                handler.InsertLoginLog(username.Text +" User Active Status Enabled ", _loggedUser);
                lblmsg.Text = "Update Successful";
                Response.Redirect("UserManagement.aspx");
            }
            else if (ena == "Disable")
            {
                ena = "0";
                int count = handler.InsertData("UpdateUserss", new object[] { ena, username.Text, _loggedUser });
                handler.InsertLoginLog(username.Text + " User Active Status Disabled ", _loggedUser);
                lblmsg.Text = "Update Successful";
                Response.Redirect("UserManagement.aspx");
            }
            else
            {

            }

        }
    }
}
