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
    public partial class ApproveUsers : System.Web.UI.Page
    {
        DatabaseHandler handler = new DatabaseHandler();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                string user = Session["username"].ToString();
                string token = Session["AuthToken"].ToString();
                try
                {
                    InitailizeControls(user, token);
                }
                catch (Exception ee)
                {
                    Response.Redirect("UserLogin.aspx", true);

                }

            }

        }

        private void InitailizeControls(string user, string token)
        {
            try
            {
               DataTable table =  handler.GetDataFromAppDT("ConfirmAuthorizationToken", new object[] { user, token });
                if (table.Rows.Count != 0)
                {
                    GetPendingUserApprovals();
                }
                else
                {
                    Response.Redirect("UserLogin.aspx", true);
                }
            }catch(Exception ee)
            {

            }
        }

        //public void GetRoles()
        //{
        //    dd_profile.DataSource = handler.GetUserRoles();
        //    dd_profile.DataTextField = "RoleName";
        //    dd_profile.DataValueField = "RoleName";
        //    dd_profile.DataBind();

        //    dd_profile.Items.Insert(0, new ListItem("-- Select Role --", "0"));

        //}
        private void GetPendingUserApprovals()
        {
            DataTable dtActivity = handler.GetDataFromAppDT("GetUsersToApprove", new object[] { });
            if (dtActivity.Rows.Count > 0)
            {
                GridData.DataSource = dtActivity;
                GridData.DataBind();
                GridData.Visible = true;
            }
            else
            {
                lblmsg.Text = "No Pending Approvals";
            }

        }
        protected void sssButtons(object sender, EventArgs e)
        {

            string reason = rejectReason.Text;
            string _loggedUser = Session["fullname"].ToString();
            //handler.UpdateRejectionReason(email, reason, _loggedUser);

            // Label msg = (Label)Master.FindControl("lblmsg");
            lblmsg.Text = "MESSAGE:  " + "User Denied...........";
        }
      
        private void Button_Click(string email, string reason, string username)
        {
            //
            string reason2 = rejectReason.Text;
            handler.UpdateRejectionReason(email, reason2, username);

            Multiview1.ActiveViewIndex = 0;
            Multiview1.Visible = false;
        }
        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ApproveUser")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string Code = GridData.Rows[intIndex].Cells[4].Text;

                string _loggedUser = Session["fullname"].ToString();
                handler.ApproveUser(Code, _loggedUser);
                GetPendingUserApprovals();

                // Label msg = (Label)Master.FindControl("lblmsg");
                lblmsg.Text = "MESSAGE:  " + "User Successfully Approved";
                handler.InsertLoginLog(Code+ " User Approved by "+_loggedUser, _loggedUser);
            }
            else if (e.CommandName == "DenyUser")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string Code = GridData.Rows[intIndex].Cells[4].Text;
                string _loggedUser = Session["fullname"].ToString();
                handler.InsertLoginLog(Code + " User Rejected " + _loggedUser, _loggedUser);
                Multiview1.ActiveViewIndex = 0;
                Multiview1.Visible = true;
                int intInd = Convert.ToInt32(e.CommandArgument);
                string email = GridData.Rows[intInd].Cells[4].Text;
              
                string reason = rejectReason.Text;
                Button_Click(email, reason, _loggedUser);
            }
        }
    }
}