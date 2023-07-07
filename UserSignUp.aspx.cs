using RiskProfilingApp.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskProfilingApp
{
    public partial class UserSignUp : System.Web.UI.Page
    {
        string ldap = "LDAP://10.128.0.4:389";
        DatabaseHandler handler = new DatabaseHandler();
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    lblmsg.Text = "Please Sign Up";

                    txtUserName.Text = Session["username"].ToString();
                    GetRoles();

                    // GetSections();
                }
                catch (Exception ee)
                {
                    //Response.Redirect("UserLogin.aspx", true);

                }

            }


        }

        public void GetRoles()
        {
            dd_role.DataSource = handler.GetUserRoles();
            dd_role.DataTextField = "RoleName";
            dd_role.DataValueField = "RoleName";
            dd_role.DataBind();

            dd_role.Items.Insert(0, new ListItem("-- Select Role --", "0"));

        }


        public void InsertNewUser(string username, string fullname, string email, string role, string profile, string phoneNumber)
        {
            table = handler.GetAccessLevels(role);
            string accessLevel = table.Rows[0]["RoleId"].ToString();
            int countrows = table.Rows.Count;
            if (countrows != 0)
            {
                if (accessLevel == "008")
                {
                    handler.InsertSystemUser(username, fullname, email, role, profile, accessLevel, phoneNumber, "1");
                    handler.InsertLoginLog(username + " User Signed Up For : " + role + " Role", fullname);
                    lblmsg.Text = username + " Successfully Registered";
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    handler.InsertSystemUser(username, fullname, email, role, profile, accessLevel, phoneNumber, "0");
                    handler.InsertLoginLog(username + " User Signed Up For : " + role + " Role", fullname);
                    lblmsg.Text = username + " Successfully Registered";
                    Response.Redirect("UserLogin.aspx");
                }

            }
            else
            {
                handler.InsertSystemUser(username, fullname, email, role, profile, "008", phoneNumber, "1");
                handler.InsertLoginLog(username + " User Signed Up For : " + role + " Role", fullname);
                Response.Redirect("UserLogin.aspx");
                //lblmsg.Text = username + " Successfully Registered";
            }
        }

        public void LoginButtons(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            IsAuthenticated(ldap, username, password);

        }

        public bool IsAuthenticated(string ldap, string usr, string pwd)
        {

            bool authenticated = false;

            try
            {
                System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(ldap, usr, pwd);
                object nativeObject = entry.NativeObject;

                System.DirectoryServices.DirectorySearcher details = new System.DirectoryServices.DirectorySearcher(entry);


                if (usr.Contains("dfcugroup.com"))
                {
                    details.Filter = string.Format("(userprincipalname={0})", usr);
                }
                else
                {
                    details.Filter = String.Format("(samaccountname={0})", usr);
                }

                details.PropertiesToLoad.Add("samaccountname");
                details.PropertiesToLoad.Add("DisplayName");
                details.PropertiesToLoad.Add("userprincipalname");


                SearchResult result = details.FindOne();
                Session["username"] = (string)result.Properties["samaccountname"][0];
                Session["fullname"] = (string)result.Properties["DisplayName"][0];
                Session["userprincipal"] = (string)result.Properties["userprincipalname"][0];

                Session["role"] = dd_role.SelectedValue;

                string user = (string)result.Properties["samaccountname"][0];
                string fullname = (string)result.Properties["DisplayName"][0];
                string email = (string)result.Properties["userprincipalname"][0];
                string role = dd_role.SelectedValue;
                string phoneNumber = phone.Text;
                authenticated = true;

                InsertNewUser(user, fullname, email, role, "", phoneNumber);

                //lblmsg.Text = "Your Account is Pending Approval by the System Administrator";

            }
            catch (DirectoryServicesCOMException cex)
            {
                //Logs.WriteLog(DateTime.Now.ToString() + ": LDAP ErrorInfo: " + cex.Message);               
                handler.InsertErrorLog("LDAP ErrorInfo ", "" + cex.Message);
            }

            catch (Exception ex)
            {
                handler.InsertErrorLog("LDAP ErrorInfo ", "" + ex.Message);

                //Logs.WriteLog(DateTime.Now.ToString() + ": LDAP ErrorInfo: " + ex.Message);
            }
            return authenticated;
        }

    }
}