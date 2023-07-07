using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace RiskProfilingApp.Logic
{
    public class DatabaseHandler
    {
        DataTable table = new DataTable();
        private DataSet details;
        private Database RiskApp, RiskProfile;
        private DbCommand command;



        public DatabaseHandler()
        {
            try
            {
                RiskApp = DatabaseFactory.CreateDatabase("DBConnectionString");
                RiskProfile = DatabaseFactory.CreateDatabase("DBRiskProfiling");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDatasss(string UserName)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("CheckIfUserExists", UserName);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }


        public DataTable GetUsers(string UserName)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("CheckIfUserExists", UserName);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }

        public DataTable GetAllAlerts()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("AllAlerts");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }

        public DataTable GetCustomersDueInSeven()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetCustomersDueInSeven");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }

        public DataSet GetLoanDetailsAssigned(string staff)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetLoanDetailsAssigned", staff);
                details = RiskApp.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return details;
        }

        public DataSet GetPaymentsForAccounts(string account)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetPaymentsForAccounts", account);
                details = RiskApp.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return details;
        }

        public DataSet GetUnassignedLoans()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetLoanDetailsToAssign");
                details = RiskApp.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return details;
        }

        public DataSet GetAllLoanDetails()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetAllLoanDetails");
                details = RiskApp.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return details;
        }

        public DataTable GetDemandNoticeCustomers(string staff)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetDemandNoticeCustomers", staff);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }

        public DataTable GetLoanDetails(string account)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetLoanDetailsAccount", account);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                InsertErrorLog("Get Loan Details ", " " + ee);
            }

            return table;
        }

        public DataTable GetScripts(string type)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetScripts", type);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                InsertErrorLog("Get Loan Details ", " " + ee);
            }

            return table;
        }
        public DataTable GetMailingList()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetMailingList");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }



        public DataTable GetMailing()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetMailing");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }

        public DataTable GetCallerScript()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetCallerScript");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                InsertErrorLog("Getting Caller Script Failed Because : ", " " + ee);
            }
            return table;
        }

        public DataTable GetCustomerInArrearsOne()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetCustomerInArrearsOne");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                InsertErrorLog("GetCustomerInArrearsOne Failed Because : ", " " + ee);
            }
            return table;
        }


        public DataTable GetActivityLog()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetActivityLog");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                InsertErrorLog("Getting Audit Trail Failed Because : ", " " + ee);
            }
            return table;
        }

        public DataTable GetAllUsers()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetAllUsers");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }



        public DataTable GetUsers()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetUsers");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }

        public DataTable GetAllActiveUsers()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetAllActiveUsers");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }
        public DataTable GetAllInactiveUsers()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetAllInactiveUsers");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return table;
        }


        public DataTable GetUserRoles()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetUserRoles");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                InsertErrorLog("Error getting User Roles because : ", " " + ee.Message);
            }
            return table;
        }
        //GetAllRoles
        public DataTable GetAllRoles()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetAllRoles");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                InsertErrorLog("Error getting User Roles because : ", " " + ee.Message);
            }
            return table;
        }
        public DataTable DownloadFile(string ReasonCode)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("DownloadFile", ReasonCode);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                InsertErrorLog("Error downloading File beacause : ", " " + ee.Message);
            }
            return table;
        }

        public DataTable GetDemandNotice()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetDemandNotice");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                InsertErrorLog("Error getting Demand Notice because : ", " " + ee.Message);
            }
            return table;
        }
        public DataTable GetDefaultReasons()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetDefaultReasons");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                InsertErrorLog("Error getting User Roles because : ", " " + ee.Message);
            }
            return table;
        }

        public DataTable GetSections()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetSections");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                InsertErrorLog("Error getting Sections because : ", " " + ee.Message);
            }

            return table;
        }

        public DataTable GetAccessLevels(string role)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetAccessLevels", role);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                throw ee;
            }

            return table;
        }

        public DataTable GetScheduleLog()
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetScheduleLog");
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

            }
            return table;
        }
        public DataTable GetActiveUser(string username)
        {
            try
            {
                command = RiskApp.GetStoredProcCommand("GetActiveUser", username);
                table = RiskApp.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {
                InsertErrorLog("Get Active User Failed Because : ", "" + ee);

            }
            return table;
        }

        public int ApproveUser(string email, string username)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("ApproveUser", email, username);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                InsertErrorLog("Approve User Failed Because :  " + email, "By : " + username + " " + ee);

            }
            return count;
        }

        public int AddRoles(string roleName)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("AddRoless", roleName);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                InsertErrorLog("Add Roles Failed Because : ", "" + ee);
            }
            return count;
        }

        public int InsertCallerScript(string title, string realScript, string loggedUser, string type)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("InsertCallerScript", title, realScript, loggedUser, type);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                InsertErrorLog("Add Roles Failed Because : ", "" + ee);
            }
            return count;
        }
        public int InsertErrorLog(string action, string error)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("InsertErrorLog", action, error);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                Console.WriteLine("" + ee);


            }
            return count;
        }

        public int InsertDemandNoticeCustomers(string account, string email)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("InsertDemandNoticeCustomers", account, email);
                count = RiskApp.ExecuteNonQuery(command);
                count++;
            }
            catch (Exception ee)
            {
                Console.WriteLine("" + ee);


            }
            return count;
        }

        public int InsertSheduleLog(string account_number, string Type, string Email, string Phone, string sender, string reason)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("ScheduleLogs", account_number, Type, Email, Phone, sender, reason);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                Console.WriteLine("" + ee);


            }
            return count;
        }
        public int UpdateRejectionReason(string email, string reason, string username)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("UpdateRejectionReason", email, reason, username);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                Console.WriteLine("", ee);

            }
            return count;

        }

        public int UpdateCallDetails(DateTime promiseDate, string promiseAmount, string promiseAction, DateTime actionDate, DateTime reminderDate, string username, string account, string defaultReason)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("UpdateCallDetails", promiseDate, promiseAmount, promiseAction, actionDate, reminderDate, username, account, defaultReason);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                Console.WriteLine("", ee);

            }
            return count;

        }

        public int UpdateReminderDetails(DateTime reminderDate, string username, string account, string reminderReason)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("UpdateReminderDetails", reminderDate, username, account, reminderReason);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                Console.WriteLine("", ee);
                InsertErrorLog("Update Reminder Details Failed Because: ", "" + ee);

            }
            return count;
        }
        public int UpdateLoanAssignDetails(string nwAssignee, string username, string account)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("UpdateLoanAssignDetails", nwAssignee, username, account);
                count = RiskApp.ExecuteNonQuery(command);
            }
            catch (Exception ee)
            {
                Console.WriteLine("", ee);

            }
            return count;

        }

        public int InsertLoginLog( string action, string loggedIn)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("InsertLoginLog",  action, loggedIn);
                count = RiskApp.ExecuteNonQuery(command);
                Console.WriteLine("Inserted");

            }
            catch (Exception ee)
            {
                Console.WriteLine("", ee);

            }
            return count;
        }

        public int InsertNewUpload(string filename, string Upp, string PrefferedName, string reasonCode, string username, string uploadType)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("InsertNewUpload", filename, Upp, PrefferedName, reasonCode, username, uploadType);
                count = RiskApp.ExecuteNonQuery(command);
                Console.WriteLine(PrefferedName + " Uploaded");

            }
            catch (Exception ee)
            {
                Console.WriteLine("", ee);

            }
            return count;
        }


        public int InsertSystemUser(string username, string fullname, string email, string role, string profile, string accesslevel, string phoneNumber,string act)
        {
            int count = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand("InsertSystemUsers", username, fullname, email, role, profile, accesslevel, phoneNumber,act);
                count = RiskApp.ExecuteNonQuery(command);
                Console.WriteLine(username + "Inserted");

            }
            catch (Exception ee)
            {
                Console.WriteLine("", ee);

            }
            return count;
        }
        public int InsertData(string procedure, object[] data)
        {
            int suc = -1;
            try
            {
                command = RiskApp.GetStoredProcCommand(procedure, data);
                suc = RiskApp.ExecuteNonQuery(command);

            }
            catch (Exception ee)
            {

                throw ee;
            }
            return suc;
        }
        public int InsertDataAPI(string procedure, object[] data)
        {
            int suc = -1;
            try
            {
                command = RiskProfile.GetStoredProcCommand(procedure, data);
                suc = RiskProfile.ExecuteNonQuery(command);
                suc++;

            }
            catch (Exception ee)
            {

                throw ee;
            }
            return suc;
        }
        public DataSet GetData(string procedure, object[] data)
        {
            DataSet dset = new DataSet();
            try
            {
                if (data == null)
                    command = RiskApp.GetStoredProcCommand(procedure);
                else
                    command = RiskApp.GetStoredProcCommand(procedure, data);
                dset = RiskApp.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return dset;
        }
      

        public DataSet GetDatas(string procedure, object[] data)
        {
            DataSet dset = new DataSet();
            try
            {
                if (data == null)
                    command = RiskProfile.GetStoredProcCommand(procedure);
                else
                    command = RiskProfile.GetStoredProcCommand(procedure, data);
                dset = RiskProfile.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

               // throw ee;
            }
            return dset;
        }

        public DataSet GetDataFromAPIDS(string procedure, object[] data)
        {
            DataSet dset = new DataSet();
            try
            {
                if (data == null)
                    command = RiskProfile.GetStoredProcCommand(procedure);
                else
                    command = RiskProfile.GetStoredProcCommand(procedure, data);
                dset = RiskProfile.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return dset;
        }

        public DataTable GetDataFromAPIDT(string procedure, object[] data)
        {
            DataTable dset = new DataTable();
            try
            {
                if (data == null)
                    command = RiskProfile.GetStoredProcCommand(procedure);
                else
                    command = RiskProfile.GetStoredProcCommand(procedure, data);
                dset = RiskProfile.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return dset;
        }

        public DataSet GetDataFromAppDS(string procedure, object[] data)
        {
            DataSet dset = new DataSet();
            try
            {
                if (data == null)
                    command = RiskApp.GetStoredProcCommand(procedure);
                else
                    command = RiskApp.GetStoredProcCommand(procedure, data);
                dset = RiskApp.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return dset;
        }

        public DataTable GetDataFromAppDT(string procedure, object[] data)
        {
            DataTable dset = new DataTable();
            try
            {
                if (data == null)
                    command = RiskApp.GetStoredProcCommand(procedure);
                else
                    command = RiskApp.GetStoredProcCommand(procedure, data);
                dset = RiskApp.ExecuteDataSet(command).Tables[0];
                // dset = AuditTrail.ExecuteDataSet(command);
            }
            catch (Exception ee)
            {

                throw ee;
            }
            return dset;
        }
        internal void LogError(string message, string transactionId, string method, string username)
        {
            try
            {
                //phone = FormatNumber(phone); 
                DbCommand commands = RiskApp.GetStoredProcCommand("LogError", message, transactionId, method, username);
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

    }
}