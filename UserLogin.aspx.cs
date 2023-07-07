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
    public partial class UserLogin : System.Web.UI.Page
    {
        private int t;
        HttpCookie userCookie;   // Declare a cookie variable
        string ldap = "LDAP://10.128.0.4:389";
        DatabaseHandler handler = new DatabaseHandler();
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    lblmsg.Text = "";

                }
                catch (Exception ee)
                {
                    //Response.Redirect("UserLogin.aspx", true);

                }

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

            //try
            //{
            System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(ldap, usr, pwd);
            object nativeObject = entry.NativeObject;

            System.DirectoryServices.DirectorySearcher details = new System.DirectoryServices.DirectorySearcher(entry);


            if (usr.Contains("dfcugroup.com"))
            {
                details.Filter = String.Format("(userprincipalname={0})", usr);
            }
            else
            {
                details.Filter = String.Format("(samaccountname={0})", usr);
            }

            details.PropertiesToLoad.Add("samaccountname");
            details.PropertiesToLoad.Add("DisplayName");
            details.PropertiesToLoad.Add("userprincipalname");
            // details.PropertiesToLoad.Add("RFC4519");


            SearchResult result = details.FindOne();
            Session["username"] = (string)result.Properties["samaccountname"][0];
            Session["fullname"] = (string)result.Properties["DisplayName"][0];
            Session["userprincipal"] = (string)result.Properties["userprincipalname"][0];
            //Session["RFC4519"] = (string)result.Properties["RFC4519"][0];

            string user = (string)result.Properties["samaccountname"][0];
            string fullname = (string)result.Properties["DisplayName"][0];
            string email = (string)result.Properties["userprincipalname"][0];
            //  string phone = (string)result.Properties["RFC4519"][0];

            authenticated = true;
            if (authenticated == true)
            {
                table = handler.GetUsers(user);
                int userExists = table.Rows.Count;

                if (userExists != 0)
                {
                    table = handler.GetActiveUser(user);

                    int countrows = table.Rows.Count;

                    if (countrows != 0)
                    {
                        Session["Role"] = table.Rows[0]["Role"].ToString();
                        Session["Active"] = table.Rows[0]["Active"].ToString();
                        Session["AccessLevel"] = table.Rows[0]["AccessLevel"].ToString();

                        CallLogin(Session["username"].ToString());

                    }
                    else
                    {
                        lblmsg.Text = "Your Account is Pending Approval by the System Administrator";
                    }
                }
                else
                {
                    lblmsg.Text = "Please sign Up";
                    Response.Redirect("UserSignUp.aspx");
                }
            }

            // Response.Redirect("LandingPage.aspx");

            //}
            //catch (DirectoryServicesCOMException cex)
            //{
            //    //Logs.WriteLog(DateTime.Now.ToString() + ": LDAP ErrorInfo: " + cex.Message);   
            //    lblmsg.Text = "" + cex.Message;

            //}
            //catch (Exception ex)
            //{
            //    //Logs.WriteLog(DateTime.Now.ToString() + ": LDAP ErrorInfo: " + ex.Message);
            //    lblmsg.Text = "" + ex.Message;
            //}
            return authenticated;
        }
        private void CallLogin(string TokenUser)
        {
            try
            {
                string auth = generateAuthToken(TokenUser);
                Session["AuthToken"] = auth;
                if (String.IsNullOrEmpty(auth))
                {
                    lblmsg.Text = "Error Occured. Please Try Again";
                }
                else
                {

                    string username = Session["username"].ToString();
                    string fullname = Session["fullname"].ToString();
                    if (Session["AccessLevel"].ToString() == "005")
                    {

                        handler.InsertLoginLog(username + " User Logged In", fullname);
                        handler.InsertData("InsertLoginDate", new object[] { username });
                        Response.Redirect("RiskProfile.aspx");
                    }
                    else if (Session["AccessLevel"].ToString() == "004")
                    {
                        handler.InsertLoginLog(username + " User Logged In", fullname);
                        handler.InsertData("InsertLoginDate", new object[] { username });
                        Response.Redirect("RiskProfile.aspx");

                    }
                    else if (Session["AccessLevel"].ToString() == "002")
                    {

                        handler.InsertLoginLog(username + " User Logged In", fullname);
                        handler.InsertData("InsertLoginDate", new object[] { username });
                        Response.Redirect("ApproveUsers.aspx");

                    }
                    else if (Session["AccessLevel"].ToString() == "003")
                    {
                        handler.InsertLoginLog(username + " User Logged In", fullname);
                        handler.InsertData("InsertLoginDate", new object[] { username });
                        Response.Redirect("UserActivityReport.aspx");
                    }
                    else
                    {
                        handler.InsertLoginLog(username + " User Logged In", fullname);
                        handler.InsertData("InsertLoginDate", new object[] { username });
                        Response.Redirect("RiskProfile.aspx");
                    }
                }
            }
            catch (Exception ee)
            {

            }
        }
        public string generateAuthToken(string TokenUser)
        {
            var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var resultToken = new string(
               Enumerable.Repeat(allChar, 8)
               .Select(token => token[random.Next(token.Length)]).ToArray());

            string authToken = resultToken.ToString();
            try
            {
                handler.InsertData("InsertAuthorizationToken", new object[] { TokenUser, authToken });
            }
            catch (Exception ee)
            {

            }
            return authToken;
        }
        private void GetStartFunction()
        {
            lblmsg.Text = ".";
            t = Request.QueryString.Count;

            if (t != 0)
            {
                string flag = (int.Parse(Request.QueryString[0])).ToString();
                if (flag.Equals("1"))
                {
                    string value;

                    userCookie = Request.Cookies["username"];
                    if (userCookie != null)
                    {
                        value = userCookie.Value;
                        //dac.SaveUpdateUserAccount("False", value);   // Reset user Account.....
                        handler.InsertLoginLog("SessionExpiry For : " + value, value);
                    }

                    lblmsg.Text = "Your Session has expired. Please log into the system again to continue your work.......";
                }
                else
                {
                    if (flag.Equals("2"))
                    {
                        lblmsg.Text = "Your Accout needs Approval by the System Administrator.......";
                    }
                }
            }
        }
    }
}
