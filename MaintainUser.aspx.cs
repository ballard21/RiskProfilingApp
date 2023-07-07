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
    public partial class MaintainUser : System.Web.UI.Page
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
            GetUserRoles();
            if (Request.QueryString["Account"] != null)
            {

                string _account = Request.QueryString["Account"];

                DataTable table = handler.GetDataFromAppDT("UpdateUser", new object[] { _account });
                foreach (DataRow drow in table.Rows)
                {
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
            dd_choose.DataSource = handler.GetDataFromAppDT("GetAllRoles", new object[] { });
            dd_choose.DataTextField = "RoleName";
            dd_choose.DataValueField = "RoleName";
            dd_choose.DataBind();
        }


        protected void saveBtnOnclick(object sender, EventArgs e)
        {
            string _loggedUser = Session["fullname"].ToString();

            string ena = dd_choose.SelectedValue;

            DataTable tabl = handler.GetDataFromAppDT("GetSpecificAccessLevel", new object[] { ena });
            string Access = tabl.Rows[0]["RoleId"].ToString();
            if (ena != "")
            {
                int count = handler.InsertData("UpdateUserRole", new object[] { ena, Access, _loggedUser, username.Text });

                lblmsg.Text = "Update Successful";
                Response.Redirect("UsersManagement.aspx");
            }

            else
            {
                lblmsg.Text = "Operation Failed, Please contact the Administrator";
            }
        }
    }
}
