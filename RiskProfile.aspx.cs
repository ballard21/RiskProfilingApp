using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiskProfilingApp.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RiskProfilingApp
{
    public partial class RiskProfile : System.Web.UI.Page
    {
        DatabaseHandler handler = new DatabaseHandler();
        string profilingAPI = WebConfigurationManager.AppSettings["profilingAPI"];
        string profilingUser = WebConfigurationManager.AppSettings["profilingUser"];
        string profilingPass = WebConfigurationManager.AppSettings["profilingPass"];
        DataTable dtable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {
                string user = Session["fullname"].ToString();
                string users = Session["username"].ToString();
                string token = Session["AuthToken"].ToString();
                try
                {
                    InitializeComponents(users, token);
                    lblmsg.Text = "";
                }
                catch (Exception ee)
                {
                    handler.InsertData("InsertErrorLog", new object[] { "RiskProfile Page", "" + ee.Message, user });
                    //Response.Redirect("UserLogin.aspx", true);                   

                }

            }

        }

        private void InitializeComponents(string user, string token)
        {
            DataTable table = handler.GetDataFromAppDT("ConfirmAuthorizationToken", new object[] { user, token });
            if (table.Rows.Count != 0)
            {
                GetBusiness();
                GetClientTypes();
                GetCountries();
                GetProducts();
                GetDistributionChannel();
                GetIncomeRange();
            }
            else
            {
                Response.Redirect("UserLogin.aspx", true);
            }

        }

        public void GetClientTypes()
        {
            _clienttype.DataSource = handler.GetDataFromAPIDS("getClientTypes", new object[] { });
            _clienttype.DataTextField = "Description";
            _clienttype.DataValueField = "Description";
            _clienttype.DataBind();
            _clienttype.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void GetCountries()
        {
            _country.DataSource = handler.GetDataFromAPIDS("getCountries", new object[] { });
            _country.DataTextField = "Description";
            _country.DataValueField = "Description";
            _country.DataBind();
            _country.Items.Insert(0, new ListItem("-- Select  --", "0"));
        }
        public void GetBusiness()
        {
            _nature.DataSource = handler.GetDataFromAPIDS("getBusinesses", new object[] { });
            _nature.DataTextField = "Description";
            _nature.DataValueField = "Description";
            _nature.DataBind();

            _nature.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void GetProducts()
        {
            _preferred.DataSource = handler.GetDataFromAPIDS("getProducts", new object[] { });
            _preferred.DataTextField = "Description";
            _preferred.DataValueField = "Description";
            _preferred.DataBind();
            _preferred.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void GetDistributionChannel()
        {
            _distributionChannel.DataSource = handler.GetDataFromAPIDS("getDistributionChannels", new object[] { });
            _distributionChannel.DataTextField = "Description";
            _distributionChannel.DataValueField = "Description";
            _distributionChannel.DataBind();

            _distributionChannel.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void GetIncomeRange()
        {
            DropDownList1.DataSource = handler.GetDataFromAPIDS("getIncomeBands", new object[] { });
            DropDownList1.DataTextField = "Description";
            DropDownList1.DataValueField = "Description";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void Searchtxn(object sender, EventArgs e)
        {

            string users = Session["username"].ToString();
            string token = Session["AuthToken"].ToString();
            //handler.InsertData("InsertLoginLog", new object[] { "RiskProfile Page", "" + ee.Message, ee.InnerException });
            // handler.InsertLoginLog("Searchtxn  " + users + " ", token);
            DataTable table = handler.GetDataFromAppDT("ConfirmAuthorizationToken", new object[] { users, token });
            if (table.Rows.Count != 0)
            {
                RiskProfilingResponse response = new RiskProfilingResponse();
                if (string.IsNullOrEmpty(_customerName.Text))
                {
                    lblmsg.Text = "Please Enter Customer Name";
                }
                else if (String.IsNullOrEmpty(_address.Text))
                {
                    lblmsg.Text = "Please Enter Customer Address";
                }
                else if (String.IsNullOrEmpty(_clienttype.Text))
                {
                    lblmsg.Text = "Please Select Client Type";
                }
                else if (String.IsNullOrEmpty(_country.Text))
                {
                    lblmsg.Text = "Please Select Customer's Country";
                }
                else if (String.IsNullOrEmpty(_nature.Text))
                {
                    lblmsg.Text = "Please Select Nature Of Business";
                }
                else if (String.IsNullOrEmpty(_preferred.Text))
                {
                    lblmsg.Text = "Please Select Preferred Bank Product";
                }
                else if (String.IsNullOrEmpty(_distributionChannel.Text))
                {
                    lblmsg.Text = "Please Select Distribution Channel";
                }
                else if (String.IsNullOrEmpty(DropDownList1.SelectedValue))
                {
                    lblmsg.Text = "Please Select Customer Income Range";
                }
                else
                {
                    string tok = getRiskToken();
                    handler.InsertLoginLog("getRiskToken Token:  ", tok);
                    if (string.IsNullOrEmpty(tok))
                    {
                        lblmsg.Text = "Risk Profiling Failed";
                    }
                    else
                    {
                        try
                        {
                            DataTable tables = handler.GetDataFromAPIDT("getDistributionChannelsExplicit", new object[] { _distributionChannel.SelectedValue });
                            string distributionValue = tables.Rows[0]["Id"].ToString();

                            DataTable tables1 = handler.GetDataFromAPIDT("getIncomeBandsExplicit", new object[] { DropDownList1.SelectedValue });
                            string IncomeValue = tables1.Rows[0]["Id"].ToString();

                            DataTable tables2 = handler.GetDataFromAPIDT("getProductsExplicit", new object[] { _preferred.SelectedValue });
                            string preferredValue = tables2.Rows[0]["Id"].ToString();

                            DataTable tables3 = handler.GetDataFromAPIDT("getClientTypesExplicit", new object[] { _clienttype.SelectedValue });
                            string clientValue = tables3.Rows[0]["Id"].ToString();

                            DataTable tables4 = handler.GetDataFromAPIDT("getBusinessesExplicit", new object[] { _nature.SelectedValue });
                            string natureValue = tables4.Rows[0]["Id"].ToString();

                            DataTable tables5 = handler.GetDataFromAPIDT("getCountriesExplicit", new object[] { _country.SelectedValue });
                            string coutnriesValue = tables5.Rows[0]["Id"].ToString();

                            if (_ddpep.SelectedValue == "Yes")
                            {
                                response = riskProfilingCheck(tok, _customerName.Text, _address.Text, natureValue, coutnriesValue, distributionValue, preferredValue, IncomeValue, clientValue, true);
                                if (string.IsNullOrEmpty(response.score.score.ToString()))
                                {
                                    lblmsg.Text = "Error Occured. Please Try Again";
                                }
                            }
                            else
                            {
                                response = riskProfilingCheck(tok, _customerName.Text, _address.Text, natureValue, coutnriesValue, distributionValue, preferredValue, IncomeValue, clientValue, false);
                                if (string.IsNullOrEmpty(response.score.score.ToString()))
                                {
                                    lblmsg.Text = "Error Occured. Please Try Again";
                                }
                            }
                        }

                        catch (Exception ee)
                        {
                            lblmsg.Text = "Operation Failed ";
                            handler.InsertLoginLog("Wide Error :  ", ee.Message.ToString());
                            lblmsg.Text = "Risk Profiling Failed " + ee.Message.ToString();
                        }
                    }
                }               
            }
            else
            {
                Response.Redirect("UserLogin.aspx", true);
            }

        }
        public string getRiskToken()
        {
            string response = "";
            object bodyData = new
            {
                username = profilingUser,
                password = profilingPass
            };
            var url = profilingAPI + "api/Users/Authenticate";
            HttpClient client = new HttpClient();
            var body = JsonConvert.SerializeObject(bodyData);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var resp = client.PostAsync(url, content).Result;
            var result = resp.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(result);
            //handler.InsertLoginLog("getRiskToken Token:  ", (obj["token"].ToString()));

            //if (!resp.IsSuccessStatusCode)
            //{
            //    response = obj["token"].ToString();
            //}

            return obj["token"].ToString();
        }
        public RiskProfilingResponse riskProfilingCheck(string token, string _customerName, string _address, string natureValue, string coutnriesValue, string distributionValue, string preferredValue, string IncomeValue, string clientValue, bool pep)
        {
            string user = Session["fullname"].ToString();
            RiskProfilingResponse response = new RiskProfilingResponse();
            try
            {
                gettokenrequest req = new gettokenrequest();

                if (token != null)
                {
                    object bodyData = new
                    {
                        CustomerName = _customerName,
                        Address = _address,
                        BusinessId = natureValue,
                        CountryId = coutnriesValue,
                        DistributionChannelId = distributionValue,
                        ProductId = preferredValue,
                        IncomeId = IncomeValue,
                        ClientTypeId = clientValue,
                        IsPep = pep

                    };

                    //  var Apiurl = settings["ApiUrl:riskProfilingApi"];
                    var url = profilingAPI + "api/RiskProfiling?CustomerName=" + _customerName + "&Address=" + _address + "&BusinessId=" + natureValue + "&CountryId=" + coutnriesValue + "&DistributionChannelId=" + distributionValue + "&ProductId=" + preferredValue + "&IncomeId=" + IncomeValue + "&ClientTypeId=" + clientValue + "&IsPep=" + pep;
                    handler.InsertLoginLog("riskProfilingCheck " + url + " ", url);

                    var client = new HttpClient();
                    //client. = -1;
                    var body = JsonConvert.SerializeObject(bodyData);
                    var content = new StringContent(body, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var resp = client.PostAsync(url, content).Result;
                    var result = resp.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<RiskProfilingResponse>(result);
                    if (string.IsNullOrEmpty(response.score.rating))
                    {
                        lblmsg.Text = "RISK PROFILING FAILED";
                        handler.InsertLoginLog("Risk Profiling For " + _customerName + " FAILED", user);
                    }
                    else
                    {
                        handler.InsertLoginLog("Risk Profiling For " + _customerName + " DONE and RATING IS " + response.score.rating, user);
                        submitRequest.Visible = false;
                        submitResponse.Visible = true;
                        Label19.Text = _customerName;
                        Label20.Text = response.score.rating;
                        TextBox1.Text = _customerName;
                        TextBox2.Text = _address;
                        DropDownList2.Text = _clienttype.SelectedValue;
                        Label21.Text = response.score.clientType.ToString("N2");

                        DropDownList3.Text = _country.SelectedValue;
                        Label22.Text = response.score.citizenship.ToString("N2");
                        DropDownList4.Text = _nature.SelectedValue;
                        Label23.Text = response.score.business.ToString("N2");
                        DropDownList5.Text = _preferred.SelectedValue;
                        Label24.Text = response.score.product.ToString("N2");
                        DropDownList6.Text = _distributionChannel.SelectedValue;
                        Label25.Text = response.score.channel.ToString("N2");
                        DropDownList7.Text = DropDownList1.SelectedValue;
                        Label26.Text = response.score.income.ToString("N2");
                        Label18.Text = pep.ToString();
                    }
                }
                else
                {
                    response.StatusCode = "99";
                    response.StatusDescription = "" + token + " AUTHENTICATION FAILED ";
                }

            }
            catch (Exception ee)
            {
                response.StatusCode = "99";
                response.StatusDescription = "" + ee.Message;
            }
            return response;
        }
    }
}