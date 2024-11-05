using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using System.Net.NetworkInformation;
using System.Threading;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
//using System.Web.HttpContext;
//using System.Threading.Tasks;
using System.Net.Http;
//using System.Web.Script.Serialization;
//using Nop.Core.Domain.Payments;
//using Nop.Plugin.Payments.ShurjoPay.Models;
//using Nop.Services.Configuration;
//using Nop.Services.Orders;
using System.Xml;
//using Nop.Services.Payments;
//using Nop.Web.Framework.Controllers;
using System.Globalization;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Npgsql;
//using Newtonsoft.Json;

namespace ConsoleApp_api
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimerCallback timeCB12 = new TimerCallback(timercode12);  // push pull internal

            Timer t12 = new Timer(            // put in push pull out table
            timeCB12,     // The TimerCallback delegate type.
            "Hi",       // Any info to pass into the called method (null for no info).
             0,          // Amount of time to wait before starting.
            200);      // Interval of time between calls (in milliseconds).

            Console.Read();
        }
        static void timercode12(object state)
        {
            int id = 0;
            string client_id = string.Empty;
            string client_request_id = string.Empty;
            int unique_request_id = 0;
            string opt = string.Empty;
            string type = string.Empty;
            string date = string.Empty;
            string extnwcode = string.Empty;
            string msisdn = string.Empty;
            string pin = string.Empty;
            string loginid = string.Empty;
            string password = string.Empty;
            string extcode = string.Empty;
            string extrefnum = string.Empty;
            string msisdn2 = string.Empty;
            string cli = string.Empty;
            string message = string.Empty;
            string messagetype = string.Empty;
            string ismasking = string.Empty;
            string masking = string.Empty;
            string des = string.Empty;
            string backstr = string.Empty;
            int no_of_msg = 0;
            string messagetype1 = string.Empty;

            string unicode = string.Empty;
            string unicode_value = "0";

            string rsp_error_code = string.Empty;
            string rsp_contact = string.Empty;
            string rsp_creditDeducted = string.Empty;
            string rsp_currentBalance = string.Empty;
            string rsp_description = string.Empty;

            string rsp_smsID = string.Empty;
            string rsp_msisdn = string.Empty;

            string str = string.Empty;


            int amount = 0;
            string language1 = string.Empty;
            string language2 = string.Empty;
            string selecttor = string.Empty;
            string req_type = string.Empty;

            string rsp_type = string.Empty;
            string rsp_txnstatus = string.Empty;
            string rsp_date = string.Empty; ;
            string rsp_extrefnum = string.Empty; ;
            string rsp_txnid = string.Empty;
            string rsp_message = string.Empty;

            string rsp_con_type = string.Empty;
            string rsp_operator = string.Empty;
            string outdata_masking = string.Empty;
            string longcode = string.Empty;

            //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=WINTEL-ECS;uid=sa;pwd=K1B2A3#;" + "Initial Catalog=my_db");
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=@Online5@;Database=WAHED_DB;";

            /*OleDbCommand sampleCMD1 = new OleDbCommand("a2p_data_from_client_receive", connectObj1);
            sampleCMD1.CommandType = CommandType.StoredProcedure;

            OleDbParameter sampParm1 = new OleDbParameter();

            sampParm1 = sampleCMD1.Parameters.Add("@id", OleDbType.Integer);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.VarWChar, 1000);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
            sampParm1.Direction = ParameterDirection.Output;

            sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
            sampParm1.Direction = ParameterDirection.Output;


            sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
            sampParm1.Direction = ParameterDirection.Output;*/
            using (var conn = new NpgsqlConnection(connString))
            {
                using (var cmd = new NpgsqlCommand("a2p_data_from_client_receive", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // Output parameters
                    var idd = new NpgsqlParameter("idd", NpgsqlTypes.NpgsqlDbType.Integer)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idd);

                    var client_idd = new NpgsqlParameter("client_idd", NpgsqlTypes.NpgsqlDbType.Varchar,50)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(client_idd);

                    var client_request_idd = new NpgsqlParameter("client_request_idd", NpgsqlTypes.NpgsqlDbType.Varchar,50)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(client_request_idd);

                    var unique_request_idd = new NpgsqlParameter("unique_request_idd", NpgsqlTypes.NpgsqlDbType.Integer)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(unique_request_idd);

                    var operatorr = new NpgsqlParameter("operatorr", NpgsqlTypes.NpgsqlDbType.Varchar, 50)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(operatorr);

                    var msisdnn = new NpgsqlParameter("msisdnn", NpgsqlTypes.NpgsqlDbType.Varchar, 50)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(msisdnn);

                    var extrefnumm = new NpgsqlParameter("extrefnumm", NpgsqlTypes.NpgsqlDbType.Varchar, 50)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(extrefnumm);

                    var msisdn22 = new NpgsqlParameter("msisdn22", NpgsqlTypes.NpgsqlDbType.Varchar, 50)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(msisdn22);

                    var clii = new NpgsqlParameter("clii", NpgsqlTypes.NpgsqlDbType.Varchar, 50)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(clii);

                    var messagee = new NpgsqlParameter("messagee", NpgsqlTypes.NpgsqlDbType.Text)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messagee);

                    var messagetypee = new NpgsqlParameter("messagetypee", NpgsqlTypes.NpgsqlDbType.Varchar,10)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(messagetypee);

                    var ismaskingg = new NpgsqlParameter("ismaskingg", NpgsqlTypes.NpgsqlDbType.Varchar, 10)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(ismaskingg);

                    var maskingg = new NpgsqlParameter("maskingg", NpgsqlTypes.NpgsqlDbType.Varchar, 11)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(maskingg);

                    var no_of_msgg = new NpgsqlParameter("no_of_msgg", NpgsqlTypes.NpgsqlDbType.Integer)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(no_of_msgg);

                    var unicodee = new NpgsqlParameter("unicode", NpgsqlTypes.NpgsqlDbType.Varchar,20)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(unicodee);

                    var outdataa = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 20)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outdataa);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        //output.Value.ToString();
                        if (int.TryParse(idd.Value.ToString().Trim(), out id) == false)
                        {
                            id = 0;
                        }
                        else
                        {
                            id = Convert.ToInt32(idd.Value.ToString());
                        }
                        //id = Convert.ToInt32(idd.Value.ToString());
                        client_id = client_idd.Value.ToString().Trim();
                        client_request_id = client_request_idd.Value.ToString().Trim();
                        if (int.TryParse(unique_request_idd.Value.ToString().Trim(), out unique_request_id) == false)
                        {
                            unique_request_id = 0;
                        }
                        else
                        {
                            unique_request_id = Convert.ToInt32(unique_request_idd.Value.ToString());
                        }
                        opt = operatorr.Value.ToString().Trim();
                        msisdn = msisdnn.Value.ToString().Trim();
                        extrefnum = extrefnumm.Value.ToString().Trim();
                        msisdn2 = msisdn22.Value.ToString().Trim();
                        cli = clii.Value.ToString().Trim();
                        message = messagee.Value.ToString().Trim();
                        messagetype = messagetypee.Value.ToString().Trim();
                        ismasking = ismaskingg.Value.ToString().Trim();
                        masking = maskingg.Value.ToString().Trim();
                        if (int.TryParse(no_of_msgg.Value.ToString().Trim(), out amount) == false)
                        {
                            no_of_msg = 0;
                        }
                        else
                        {
                            no_of_msg = Convert.ToInt32(no_of_msgg.Value.ToString());
                        }
                        unicode = unicodee.Value.ToString().Trim();
                        string outdata = outdataa.Value.ToString().Trim();

                        Console.WriteLine("opt: " + opt);
                        Console.WriteLine("no_of_msg: " + no_of_msg);
                        Console.WriteLine("outdata : " + outdata);
                        message = message.Replace("\r", String.Empty);
                        message = message.Replace("\t", String.Empty);
                    }
                    catch (Exception ep)
                    {
                        Console.WriteLine(ep.ToString());
                        conn.Close();
                    }
                }
            }

            if (unicode == "true")
            {
                unicode_value = "1";
                messagetype1 = "3";

            }
            else if (unicode == "false")
            {
                unicode_value = "0";
                messagetype1 = "1";

            }
            if (ismasking.ToLower() == "true")
            {
                if (msisdn2.Substring(0, 3) != "880")
                {
                    msisdn2 = "88" + msisdn2;
                }
                if (opt.ToLower() == "gp")
                {
                    //create proc masking_verification_proc @client_id varchar(50),@masking varchar(11),@opt varchar(50),@outdata varchar(160) output
                    /*sampleCMD1 = new OleDbCommand("masking_verification_proc", connectObj1);
                    sampleCMD1.CommandType = CommandType.StoredProcedure;

                    sampParm1 = new OleDbParameter();

                    sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_id;

                    sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                    sampParm1.Value = masking.ToString();

                    sampParm1 = sampleCMD1.Parameters.Add("@opt", OleDbType.VarChar, 50);
                    sampParm1.Value = opt.ToString();

                    sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                    sampParm1.Direction = ParameterDirection.Output;


                    try
                    {

                        connectObj1.Open();
                        sampleCMD1.ExecuteNonQuery();
                        connectObj1.Close();

                        outdata_masking = sampleCMD1.Parameters["@outdata"].Value.ToString();
                    }


                    //  }

                    catch (Exception ext)
                    {
                        connectObj1.Close();
                        //response = ext.ToString();
                    }*/
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        //conn.Open();

                        using (var cmd = new NpgsqlCommand("masking_verification_proc", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            // Input parameter
                            cmd.Parameters.AddWithValue("client_idd", client_id);
                            cmd.Parameters.AddWithValue("maskingg", masking.ToString());
                            cmd.Parameters.AddWithValue("optt", opt.ToString());

                            // Output parameters
                            var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar,160)
                            {
                                Direction = System.Data.ParameterDirection.Output
                            };
                            cmd.Parameters.Add(output);

                            // Execute the command



                            // Retrieve output values
                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();


                                outdata_masking = output.Value.ToString();
                            }
                            catch (Exception ext)
                            {
                                conn.Close();
                            }

                            // Example: Display the results
                            //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                        }
                    }


                    if (outdata_masking == "masking matched")
                    {
                        if (masking == "Md.Iqbal")
                        {
                            masking = "Md. Iqbal";
                        }
                        else if (masking == "DR.NADIA")
                        {
                            masking = "DR. NADIA";
                        }                        

                        try
                        {
                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "RAPIDAdmin",
                                    password = "$Winapiwin9%$",
                                    billMsisdn = "01729021852",
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = masking,
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine("GP :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }

                        JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                        centraldata oRootObject2 = oJS2.Deserialize<centraldata>(backstr);

                        //{"serverTxnId":"f470e954-ef82-4d8d-ad5e-3228ab9e9b28","serverResponseCode":9000,"serverResponseMessage":"Request successful!","mnoTxnId":"GP20230321145336-01729021852-1332115331679388816642830","mnoResponseCode":"1000","mnoResponseMessage":"Success"}
                        string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = "";

                        if (oRootObject2.mnoTxnId != null)
                        {
                            mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        }
                        else
                        {
                            mnoTxnId = "";
                        }
                        string mnoResponseCode = "";
                        if (oRootObject2.mnoResponseCode != null)
                        {
                            mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        }
                        else
                        {
                            mnoResponseCode = "";
                        }

                        /*sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                        sampleCMD1.CommandType = CommandType.StoredProcedure;

                        sampParm1 = new OleDbParameter();
                        sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                        sampParm1.Value = unique_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                        sampParm1.Value = opt;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn;
                        //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                        //     sampParm1.Value = type;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn2;
                        //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                        //          sampParm1.Value = amount;
                        //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                        //            sampParm1.Value = rsp_txnstatus;
                        sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                        sampParm1.Value = extrefnum;

                        sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                        sampParm1.Value = cli;
                        sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                        sampParm1.Value = message;
                        sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                        sampParm1.Value = messagetype;
                        sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                        sampParm1.Value = masking;

                        sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                        sampParm1.Value = no_of_msg;
                        sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                        // sampParm1.Value = rsp_message;
                        sampParm1.Value = serverResponseCode;
                        sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                        //  sampParm1.Value = req_type;
                        sampParm1.Value = "";
                        sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                        //  sampParm1.Value = rsp_date;
                        sampParm1.Value = 0;

                        sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                        //sampParm1.Value = rsp_txnid;
                        sampParm1.Value = 0;
                        sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                        //sampParm1.Value = str;
                        if (mnoResponseCode == "1000")
                        {
                            sampParm1.Value = "success";
                        }
                        else
                        {
                            sampParm1.Value = "fail : mnoResponseCode : " + mnoResponseCode;
                        }
                        sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 200);
                        //sampParm1.Value = req_type;
                        sampParm1.Value = "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId;
                        sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                        //sampParm1.Value = rsp_date;
                        sampParm1.Value = DateTime.Now;

                        sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                        sampParm1.Value = ismasking;

                        sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                        sampParm1.Value = unicode;

                        sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                        sampParm1.Direction = ParameterDirection.Output;


                        try
                        {
                            Console.WriteLine("execute1");
                            connectObj1.Open();
                            sampleCMD1.ExecuteNonQuery();
                            connectObj1.Close();
                            Console.WriteLine("execute2");
                        }
                        catch (Exception ep)
                        {

                            Console.WriteLine(ep.ToString());

                        }*/

                        using (var conn = new NpgsqlConnection(connString))
                        {
                            //conn.Open();

                            using (var cmd = new NpgsqlCommand("a2p_insert_server_receive", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                // Input parameter
                                cmd.Parameters.AddWithValue("client_idd", client_id);
                                cmd.Parameters.AddWithValue("client_request_idd", client_request_id);
                                cmd.Parameters.AddWithValue("unique_request_idd", unique_request_id);
                                cmd.Parameters.AddWithValue("operatorr", opt);
                                cmd.Parameters.AddWithValue("msisdnn", msisdn);
                                cmd.Parameters.AddWithValue("msisdn22", msisdn2);
                                cmd.Parameters.AddWithValue("extrefnumm", extrefnum);
                                cmd.Parameters.AddWithValue("clii", cli);
                                cmd.Parameters.AddWithValue("messagee", message);
                                cmd.Parameters.AddWithValue("messagetypee", messagetype);
                                cmd.Parameters.AddWithValue("maskingg", masking);
                                cmd.Parameters.AddWithValue("no_of_msgg", no_of_msg);
                                cmd.Parameters.AddWithValue("error_codee", serverResponseCode);
                                cmd.Parameters.AddWithValue("contactt", "");
                                cmd.Parameters.AddWithValue("creditDeductedd", 0);
                                cmd.Parameters.AddWithValue("currentBalancee", 0);
                                if (mnoResponseCode == "1000")
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "success");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "fail : mnoResponseCode : " + mnoResponseCode);
                                }

                                cmd.Parameters.AddWithValue("smsIDD", "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId);
                                cmd.Parameters.AddWithValue("server_process_datee", DateTime.Now);
                                cmd.Parameters.AddWithValue("ismaskingg", ismasking);
                                cmd.Parameters.AddWithValue("unicodee", unicode);

                                // Output parameters
                                var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar,160)
                                {
                                    Direction = System.Data.ParameterDirection.Output
                                };
                                cmd.Parameters.Add(output);

                                // Execute the command



                                // Retrieve output values
                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    Console.WriteLine("execute1");
                                    Console.WriteLine("execute2");
                                }
                                catch (Exception ext)
                                {
                                    conn.Close();
                                    Console.WriteLine(ext.ToString());
                                }

                                // Example: Display the results
                                //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                            }
                        }
                    }



                }
                else if (opt.ToLower() == "teletalk")
                {
                    //create proc masking_verification_proc @client_id varchar(50),@masking varchar(11),@opt varchar(50),@outdata varchar(160) output
                    /*sampleCMD1 = new OleDbCommand("masking_verification_proc", connectObj1);
                    sampleCMD1.CommandType = CommandType.StoredProcedure;

                    sampParm1 = new OleDbParameter();

                    sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_id;

                    sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                    sampParm1.Value = masking.ToString();

                    sampParm1 = sampleCMD1.Parameters.Add("@opt", OleDbType.VarChar, 50);
                    sampParm1.Value = opt.ToString();

                    sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                    sampParm1.Direction = ParameterDirection.Output;
                    try
                    {

                        connectObj1.Open();
                        sampleCMD1.ExecuteNonQuery();
                        connectObj1.Close();

                        outdata_masking = sampleCMD1.Parameters["@outdata"].Value.ToString();
                    }


                    //  }

                    catch (Exception ext)
                    {
                        connectObj1.Close();
                        //response = ext.ToString();
                    }*/
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        //conn.Open();

                        using (var cmd = new NpgsqlCommand("masking_verification_proc", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            // Input parameter
                            cmd.Parameters.AddWithValue("client_idd", client_id);
                            cmd.Parameters.AddWithValue("maskingg", masking.ToString());
                            cmd.Parameters.AddWithValue("optt", opt.ToString());

                            // Output parameters
                            var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                            {
                                Direction = System.Data.ParameterDirection.Output
                            };
                            cmd.Parameters.Add(output);

                            // Execute the command



                            // Retrieve output values
                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();


                                outdata_masking = output.Value.ToString();
                            }
                            catch (Exception ext)
                            {
                                conn.Close();
                            }

                            // Example: Display the results
                            //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                        }
                    }


                    if (outdata_masking == "masking matched")
                    {
                        try
                        {
                            if (masking == "DR.NADIA")
                            {
                                masking = "DR. NADIA";
                            }
                            if (masking == "HNSmart")
                            {
                                masking = "HNSmart ";
                            }

                            string md5_sppassword = string.Empty;
                            string Pmd5 = "WinTP@45R5z";
                            md5_sppassword = getMd5Hashtt(Pmd5);

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "wintel2",
                                    password = md5_sppassword,
                                    billMsisdn = "01552146271",
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = masking,
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine("TT :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }

                        JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                        centraldata oRootObject2 = oJS2.Deserialize<centraldata>(backstr);

                        //{"serverTxnId":"f470e954-ef82-4d8d-ad5e-3228ab9e9b28","serverResponseCode":9000,"serverResponseMessage":"Request successful!","mnoTxnId":"GP20230321145336-01729021852-1332115331679388816642830","mnoResponseCode":"1000","mnoResponseMessage":"Success"}
                        /*string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        string mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        string mnoResponseMessage = oRootObject2.mnoResponseMessage.ToString();*/



                        //
                        string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = "";

                        if (oRootObject2.mnoTxnId != null)
                        {
                            mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        }
                        else
                        {
                            mnoTxnId = "";
                        }
                        string mnoResponseCode = "";
                        if (oRootObject2.mnoResponseCode != null)
                        {
                            mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        }
                        else
                        {
                            mnoResponseCode = "";
                        }

                        //

                        //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                        //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");


                        /*sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                        sampleCMD1.CommandType = CommandType.StoredProcedure;

                        sampParm1 = new OleDbParameter();
                        sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                        sampParm1.Value = unique_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                        sampParm1.Value = opt;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn;
                        //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                        //     sampParm1.Value = type;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn2;
                        //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                        //          sampParm1.Value = amount;
                        //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                        //            sampParm1.Value = rsp_txnstatus;
                        sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                        sampParm1.Value = extrefnum;

                        sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                        sampParm1.Value = cli;
                        sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                        sampParm1.Value = message;
                        sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                        sampParm1.Value = messagetype;
                        sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                        sampParm1.Value = masking;

                        sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                        sampParm1.Value = no_of_msg;
                        sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                        // sampParm1.Value = rsp_message;
                        sampParm1.Value = serverResponseCode;
                        sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                        //  sampParm1.Value = req_type;
                        sampParm1.Value = "";
                        sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                        //  sampParm1.Value = rsp_date;
                        sampParm1.Value = 0;

                        sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                        //sampParm1.Value = rsp_txnid;
                        sampParm1.Value = 0;
                        sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                        //sampParm1.Value = str;
                        if (mnoResponseCode == "1000")
                        {
                            sampParm1.Value = "success";
                        }
                        else
                        {
                            sampParm1.Value = "fail : mnoResponseCode : " + mnoResponseCode;
                        }
                        sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 200);
                        //sampParm1.Value = req_type;
                        sampParm1.Value = "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId;
                        sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                        //sampParm1.Value = rsp_date;
                        sampParm1.Value = DateTime.Now;

                        sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                        sampParm1.Value = ismasking;

                        sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                        sampParm1.Value = unicode;

                        sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                        sampParm1.Direction = ParameterDirection.Output;


                        try
                        {
                            Console.WriteLine("execute1");
                            connectObj1.Open();
                            sampleCMD1.ExecuteNonQuery();
                            connectObj1.Close();
                            Console.WriteLine("execute2");
                        }
                        catch (Exception ep)
                        {

                            Console.WriteLine(ep.ToString());

                        }*/
                        using (var conn = new NpgsqlConnection(connString))
                        {
                            //conn.Open();

                            using (var cmd = new NpgsqlCommand("a2p_insert_server_receive", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                // Input parameter
                                cmd.Parameters.AddWithValue("client_idd", client_id);
                                cmd.Parameters.AddWithValue("client_request_idd", client_request_id);
                                cmd.Parameters.AddWithValue("unique_request_idd", unique_request_id);
                                cmd.Parameters.AddWithValue("operatorr", opt);
                                cmd.Parameters.AddWithValue("msisdnn", msisdn);
                                cmd.Parameters.AddWithValue("msisdn22", msisdn2);
                                cmd.Parameters.AddWithValue("extrefnumm", extrefnum);
                                cmd.Parameters.AddWithValue("clii", cli);
                                cmd.Parameters.AddWithValue("messagee", message);
                                cmd.Parameters.AddWithValue("messagetypee", messagetype);
                                cmd.Parameters.AddWithValue("maskingg", masking);
                                cmd.Parameters.AddWithValue("no_of_msgg", no_of_msg);
                                cmd.Parameters.AddWithValue("error_codee", serverResponseCode);
                                cmd.Parameters.AddWithValue("contactt", "");
                                cmd.Parameters.AddWithValue("creditDeductedd", 0);
                                cmd.Parameters.AddWithValue("currentBalancee", 0);
                                if (mnoResponseCode == "1000")
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "success");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "fail : mnoResponseCode : " + mnoResponseCode);
                                }

                                cmd.Parameters.AddWithValue("smsIDD", "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId);
                                cmd.Parameters.AddWithValue("server_process_datee", DateTime.Now);
                                cmd.Parameters.AddWithValue("ismaskingg", ismasking);
                                cmd.Parameters.AddWithValue("unicodee", unicode);

                                // Output parameters
                                var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                                {
                                    Direction = System.Data.ParameterDirection.Output
                                };
                                cmd.Parameters.Add(output);

                                // Execute the command



                                // Retrieve output values
                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    Console.WriteLine("execute1");
                                    Console.WriteLine("execute2");
                                }
                                catch (Exception ext)
                                {
                                    conn.Close();
                                    Console.WriteLine(ext.ToString());
                                }

                                // Example: Display the results
                                //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                            }
                        }
                    }
                }
                else if (opt.ToLower() == "bl")
                {
                    //create proc masking_verification_proc @client_id varchar(50),@masking varchar(11),@opt varchar(50),@outdata varchar(160) output
                    /*sampleCMD1 = new OleDbCommand("masking_verification_proc", connectObj1);
                    sampleCMD1.CommandType = CommandType.StoredProcedure;

                    sampParm1 = new OleDbParameter();

                    sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_id;

                    sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                    sampParm1.Value = masking.ToString();

                    sampParm1 = sampleCMD1.Parameters.Add("@opt", OleDbType.VarChar, 50);
                    sampParm1.Value = opt.ToString();

                    sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                    sampParm1.Direction = ParameterDirection.Output;
                    try
                    {

                        connectObj1.Open();
                        sampleCMD1.ExecuteNonQuery();
                        connectObj1.Close();

                        outdata_masking = sampleCMD1.Parameters["@outdata"].Value.ToString();
                    }


                    //  }

                    catch (Exception ext)
                    {
                        connectObj1.Close();
                        //response = ext.ToString();
                    }*/

                    using (var conn = new NpgsqlConnection(connString))
                    {
                        //conn.Open();

                        using (var cmd = new NpgsqlCommand("masking_verification_proc", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            // Input parameter
                            cmd.Parameters.AddWithValue("client_idd", client_id);
                            cmd.Parameters.AddWithValue("maskingg", masking.ToString());
                            cmd.Parameters.AddWithValue("optt", opt.ToString());

                            // Output parameters
                            var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                            {
                                Direction = System.Data.ParameterDirection.Output
                            };
                            cmd.Parameters.Add(output);

                            // Execute the command



                            // Retrieve output values
                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();


                                outdata_masking = output.Value.ToString();
                            }
                            catch (Exception ext)
                            {
                                conn.Close();
                            }

                            // Example: Display the results
                            //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                        }
                    }


                    if (outdata_masking == "masking matched")
                    {

                       try
                        {

                            if (masking == "SALMAN UCL")
                            {
                                masking = "SALMAN UCL ";
                            }
                            else if (masking == "NAFISA REZA")
                            {
                                masking = "NAFISA RESA";
                            }

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "WINTEL1",
                                    password = "wIncenT#&2k24",
                                    billMsisdn = "01905440573",
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = masking,
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine("BL :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }

                        JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                        centraldata oRootObject2 = oJS2.Deserialize<centraldata>(backstr);

                        //{"serverTxnId":"f470e954-ef82-4d8d-ad5e-3228ab9e9b28","serverResponseCode":9000,"serverResponseMessage":"Request successful!","mnoTxnId":"GP20230321145336-01729021852-1332115331679388816642830","mnoResponseCode":"1000","mnoResponseMessage":"Success"}
                        /*string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        string mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        string mnoResponseMessage = oRootObject2.mnoResponseMessage.ToString();*/

                        string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = "";

                        if (oRootObject2.mnoTxnId != null)
                        {
                            mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        }
                        else
                        {
                            mnoTxnId = "";
                        }
                        string mnoResponseCode = "";
                        if (oRootObject2.mnoResponseCode != null)
                        {
                            mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        }
                        else
                        {
                            mnoResponseCode = "";
                        }

                        //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                        //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");


                        /*sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                        sampleCMD1.CommandType = CommandType.StoredProcedure;

                        sampParm1 = new OleDbParameter();
                        sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                        sampParm1.Value = unique_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                        sampParm1.Value = opt;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn;
                        //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                        //     sampParm1.Value = type;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn2;
                        //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                        //          sampParm1.Value = amount;
                        //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                        //            sampParm1.Value = rsp_txnstatus;
                        sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                        sampParm1.Value = extrefnum;

                        sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                        sampParm1.Value = cli;
                        sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                        sampParm1.Value = message;
                        sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                        sampParm1.Value = messagetype;
                        sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                        sampParm1.Value = masking;

                        sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                        sampParm1.Value = no_of_msg;
                        sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                        // sampParm1.Value = rsp_message;
                        sampParm1.Value = serverResponseCode;
                        sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                        //  sampParm1.Value = req_type;
                        sampParm1.Value = "";
                        sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                        //  sampParm1.Value = rsp_date;
                        sampParm1.Value = 0;

                        sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                        //sampParm1.Value = rsp_txnid;
                        sampParm1.Value = 0;
                        sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                        //sampParm1.Value = str;
                        if (mnoResponseCode == "1000")
                        {
                            sampParm1.Value = "success";
                        }
                        else
                        {
                            sampParm1.Value = "fail : mnoResponseCode : " + mnoResponseCode;
                        }
                        sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 200);
                        //sampParm1.Value = req_type;
                        sampParm1.Value = "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId;
                        sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                        //sampParm1.Value = rsp_date;
                        sampParm1.Value = DateTime.Now;

                        sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                        sampParm1.Value = ismasking;

                        sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                        sampParm1.Value = unicode;

                        sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                        sampParm1.Direction = ParameterDirection.Output;


                        try
                        {
                            Console.WriteLine("execute1");
                            connectObj1.Open();
                            sampleCMD1.ExecuteNonQuery();
                            connectObj1.Close();
                            Console.WriteLine("execute2");
                        }
                        catch (Exception ep)
                        {

                            Console.WriteLine(ep.ToString());

                        }*/

                        using (var conn = new NpgsqlConnection(connString))
                        {
                            //conn.Open();

                            using (var cmd = new NpgsqlCommand("a2p_insert_server_receive", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                // Input parameter
                                cmd.Parameters.AddWithValue("client_idd", client_id);
                                cmd.Parameters.AddWithValue("client_request_idd", client_request_id);
                                cmd.Parameters.AddWithValue("unique_request_idd", unique_request_id);
                                cmd.Parameters.AddWithValue("operatorr", opt);
                                cmd.Parameters.AddWithValue("msisdnn", msisdn);
                                cmd.Parameters.AddWithValue("msisdn22", msisdn2);
                                cmd.Parameters.AddWithValue("extrefnumm", extrefnum);
                                cmd.Parameters.AddWithValue("clii", cli);
                                cmd.Parameters.AddWithValue("messagee", message);
                                cmd.Parameters.AddWithValue("messagetypee", messagetype);
                                cmd.Parameters.AddWithValue("maskingg", masking);
                                cmd.Parameters.AddWithValue("no_of_msgg", no_of_msg);
                                cmd.Parameters.AddWithValue("error_codee", serverResponseCode);
                                cmd.Parameters.AddWithValue("contactt", "");
                                cmd.Parameters.AddWithValue("creditDeductedd", 0);
                                cmd.Parameters.AddWithValue("currentBalancee", 0);
                                if (mnoResponseCode == "1000")
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "success");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "fail : mnoResponseCode : " + mnoResponseCode);
                                }

                                cmd.Parameters.AddWithValue("smsIDD", "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId);
                                cmd.Parameters.AddWithValue("server_process_datee", DateTime.Now);
                                cmd.Parameters.AddWithValue("ismaskingg", ismasking);
                                cmd.Parameters.AddWithValue("unicodee", unicode);

                                // Output parameters
                                var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                                {
                                    Direction = System.Data.ParameterDirection.Output
                                };
                                cmd.Parameters.Add(output);

                                // Execute the command



                                // Retrieve output values
                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    Console.WriteLine("execute1");
                                    Console.WriteLine("execute2");
                                }
                                catch (Exception ext)
                                {
                                    conn.Close();
                                    Console.WriteLine(ext.ToString());
                                }

                                // Example: Display the results
                                //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                            }
                        }

                    }
                }
                else if (opt.ToLower() == "robi" || opt.ToLower() == "airtel")
                {
                    //create proc masking_verification_proc @client_id varchar(50),@masking varchar(11),@opt varchar(50),@outdata varchar(160) output
                    /*sampleCMD1 = new OleDbCommand("masking_verification_proc", connectObj1);
                    sampleCMD1.CommandType = CommandType.StoredProcedure;

                    sampParm1 = new OleDbParameter();

                    sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_id;

                    sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                    sampParm1.Value = masking.ToString();

                    sampParm1 = sampleCMD1.Parameters.Add("@opt", OleDbType.VarChar, 50);
                    sampParm1.Value = "robi";

                    sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                    sampParm1.Direction = ParameterDirection.Output;
                    try
                    {

                        connectObj1.Open();
                        sampleCMD1.ExecuteNonQuery();
                        connectObj1.Close();

                        outdata_masking = sampleCMD1.Parameters["@outdata"].Value.ToString();
                    }


                    //  }

                    catch (Exception ext)
                    {
                        connectObj1.Close();
                        //response = ext.ToString();
                    }*/

                    using (var conn = new NpgsqlConnection(connString))
                    {
                        //conn.Open();

                        using (var cmd = new NpgsqlCommand("masking_verification_proc", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            // Input parameter
                            cmd.Parameters.AddWithValue("client_idd", client_id);
                            cmd.Parameters.AddWithValue("maskingg", masking.ToString());
                            cmd.Parameters.AddWithValue("optt", opt.ToString());

                            // Output parameters
                            var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                            {
                                Direction = System.Data.ParameterDirection.Output
                            };
                            cmd.Parameters.Add(output);

                            // Execute the command



                            // Retrieve output values
                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();


                                outdata_masking = output.Value.ToString();
                            }
                            catch (Exception ext)
                            {
                                conn.Close();
                            }

                            // Example: Display the results
                            //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                        }
                    }


                    if (outdata_masking == "masking matched" || opt.ToLower() == "airtel")
                    {
                        string url = string.Empty;
                        if (masking == "RED ORIGIN")
                        {
                            masking = "RED ORIGIN.";
                        }
                        if (masking == "NasirMahmud")
                        {
                            masking = "NASIRMAHMUD";
                        }
                        if (masking == "FarukSikder")
                        {
                            masking = "FARUKSIKDER";
                        }
                        if (masking == "Md.Iqbal")
                        {
                            masking = "MD.IQBAL";
                        }
                        if (masking == "FRESH LPG")
                        {
                            masking = "FRESH_LPG";
                        }

                        //string sender = "Wintel";
                        
                        try
                        {

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "wintel",
                                    password = "WinA2p362@",
                                    billMsisdn = "01847170181",
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = masking,
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine("ROBI :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }

                        JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                        centraldata oRootObject2 = oJS2.Deserialize<centraldata>(backstr);

                        //{"serverTxnId":"f470e954-ef82-4d8d-ad5e-3228ab9e9b28","serverResponseCode":9000,"serverResponseMessage":"Request successful!","mnoTxnId":"GP20230321145336-01729021852-1332115331679388816642830","mnoResponseCode":"1000","mnoResponseMessage":"Success"}
                        /*string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        string mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        string mnoResponseMessage = oRootObject2.mnoResponseMessage.ToString();*/

                        string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = "";

                        if (oRootObject2.mnoTxnId != null)
                        {
                            mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        }
                        else
                        {
                            mnoTxnId = "";
                        }
                        string mnoResponseCode = "";
                        if (oRootObject2.mnoResponseCode != null)
                        {
                            mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        }
                        else
                        {
                            mnoResponseCode = "";
                        }

                        //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                        //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");


                        /*sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                        sampleCMD1.CommandType = CommandType.StoredProcedure;

                        sampParm1 = new OleDbParameter();
                        sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                        sampParm1.Value = unique_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                        sampParm1.Value = opt;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn;
                        //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                        //     sampParm1.Value = type;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn2;
                        //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                        //          sampParm1.Value = amount;
                        //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                        //            sampParm1.Value = rsp_txnstatus;
                        sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                        sampParm1.Value = extrefnum;

                        sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                        sampParm1.Value = cli;
                        sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                        sampParm1.Value = message;
                        sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                        sampParm1.Value = messagetype;
                        sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                        sampParm1.Value = masking;

                        sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                        sampParm1.Value = no_of_msg;
                        sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                        // sampParm1.Value = rsp_message;
                        sampParm1.Value = serverResponseCode;
                        sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                        //  sampParm1.Value = req_type;
                        sampParm1.Value = "";
                        sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                        //  sampParm1.Value = rsp_date;
                        sampParm1.Value = 0;

                        sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                        //sampParm1.Value = rsp_txnid;
                        sampParm1.Value = 0;
                        sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                        //sampParm1.Value = str;
                        if (mnoResponseCode == "1000")
                        {
                            sampParm1.Value = "success";
                        }
                        else
                        {
                            sampParm1.Value = "fail : mnoResponseCode : " + mnoResponseCode;
                        }
                        sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 200);
                        //sampParm1.Value = req_type;
                        sampParm1.Value = "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId;
                        sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                        //sampParm1.Value = rsp_date;
                        sampParm1.Value = DateTime.Now;

                        sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                        sampParm1.Value = ismasking;

                        sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                        sampParm1.Value = unicode;

                        sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                        sampParm1.Direction = ParameterDirection.Output;


                        try
                        {
                            Console.WriteLine("execute1");
                            connectObj1.Open();
                            sampleCMD1.ExecuteNonQuery();
                            connectObj1.Close();
                            Console.WriteLine("execute2");
                        }
                        catch (Exception ep)
                        {

                            Console.WriteLine(ep.ToString());

                        }*/

                        using (var conn = new NpgsqlConnection(connString))
                        {
                            //conn.Open();

                            using (var cmd = new NpgsqlCommand("a2p_insert_server_receive", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                // Input parameter
                                cmd.Parameters.AddWithValue("client_idd", client_id);
                                cmd.Parameters.AddWithValue("client_request_idd", client_request_id);
                                cmd.Parameters.AddWithValue("unique_request_idd", unique_request_id);
                                cmd.Parameters.AddWithValue("operatorr", opt);
                                cmd.Parameters.AddWithValue("msisdnn", msisdn);
                                cmd.Parameters.AddWithValue("msisdn22", msisdn2);
                                cmd.Parameters.AddWithValue("extrefnumm", extrefnum);
                                cmd.Parameters.AddWithValue("clii", cli);
                                cmd.Parameters.AddWithValue("messagee", message);
                                cmd.Parameters.AddWithValue("messagetypee", messagetype);
                                cmd.Parameters.AddWithValue("maskingg", masking);
                                cmd.Parameters.AddWithValue("no_of_msgg", no_of_msg);
                                cmd.Parameters.AddWithValue("error_codee", serverResponseCode);
                                cmd.Parameters.AddWithValue("contactt", "");
                                cmd.Parameters.AddWithValue("creditDeductedd", 0);
                                cmd.Parameters.AddWithValue("currentBalancee", 0);
                                if (mnoResponseCode == "1000")
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "success");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "fail : mnoResponseCode : " + mnoResponseCode);
                                }

                                cmd.Parameters.AddWithValue("smsIDD", "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId);
                                cmd.Parameters.AddWithValue("server_process_datee", DateTime.Now);
                                cmd.Parameters.AddWithValue("ismaskingg", ismasking);
                                cmd.Parameters.AddWithValue("unicodee", unicode);

                                // Output parameters
                                var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                                {
                                    Direction = System.Data.ParameterDirection.Output
                                };
                                cmd.Parameters.Add(output);

                                // Execute the command



                                // Retrieve output values
                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    Console.WriteLine("execute1");
                                    Console.WriteLine("execute2");
                                }
                                catch (Exception ext)
                                {
                                    conn.Close();
                                    Console.WriteLine(ext.ToString());
                                }

                                // Example: Display the results
                                //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                            }
                        }



                    }


                }
                else       // masking default
                {

                    try
                    {

                        System.Net.ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                        //    url = "https://cmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=" + gpusername + "&password= " + gppassword + "&apicode=1&msisdn=" + mobileno + "&countrycode=880&cli=" + sender + "&messagetype=" + messagetype + "&message=" + message + "&messageid=0";
                        //string url = "https://cmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=" + mask_username + "&password=" + mask_password + "&apicode=1&msisdn=" + mobile_gp + "&countrycode=880&cli=" + sender + "&messagetype=" + messagetype + "&message=" + System.Uri.EscapeDataString(message) + "&messageid=0";
                        //  string url = "https://cmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=WINAdmin&password=WINAdmin123&apicode=1&msisdn=01712056555&countrycode=880&cli=Wintel&messagetype=1&message=" + System.Uri.EscapeDataString("this is test") + "&messageid=0";
                        string url = "http://api.rankstelecom.com/api/v3/sendsms/plain?user=SQLQUEST&password=wiNTelSOL2021@&sender=8804445616355&SMSText=" + message + "&GSM=" + msisdn2;
                        //url = "https://cmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=" + mask_username + "&password=" + mask_password + "&apicode=1&msisdn=" + mobile_gp + "&countrycode=880&cli=" + sender + "&messagetype=" + messagetype + "&message=" + System.Web.HttpUtility.UrlEncode(message) + "&messageid=0";

                        // WINAdmin123
                        //   "https://cmp.grameenphone.com/gpcmpapi/messageplatform/controller.home?username=WINAdmin&password=WINAdmin123&apicode=1&msisdn=" + 01712056555 + "&countrycode=880&cli=Wintel&messagetype=1&message=" + test + "&messageid=0";
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                        //       webRequest.AllowAutoRedirect = true;
                        webRequest.Timeout = 15000;
                        //   webRequest.KeepAlive = false;

                        //// for untrusted https
                        System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                             delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                                     System.Security.Cryptography.X509Certificates.X509Chain chain,
                                                      System.Net.Security.SslPolicyErrors sslPolicyErrors)
                             {
                                 return true; // **** Always accept
                             };



                        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                        Stream responsedata = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responsedata);
                        str = reader.ReadToEnd();


                        //    int des_return = (int)response.StatusCode;
                        response.Close();
                        Console.WriteLine(str);

                        DataSet ds = new DataSet();
                        ds.ReadXml(new System.IO.StringReader(str));


                        rsp_error_code = ds.Tables[0].Rows[0]["status"].ToString();
                        rsp_smsID = ds.Tables[0].Rows[0]["messageid"].ToString();
                        rsp_msisdn = ds.Tables[0].Rows[0]["destination"].ToString();
                        //   rsp_extrefnum = ds.Tables[0].Rows[0]["EXTREFNUM"].ToString();
                        //     rsp_txnid = ds.Tables[0].Rows[0]["TXNID"].ToString();
                        //    rsp_message = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                        Console.WriteLine(rsp_error_code);
                        Console.WriteLine(rsp_smsID);
                        Console.WriteLine(rsp_msisdn);





                    }
                    catch (Exception ep)
                    {
                        Console.WriteLine(ep.ToString());

                    }


                    //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                    //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");


                    /*sampleCMD1 = new OleDbCommand("itopup_insert_server_receive", connectObj1);
                    sampleCMD1.CommandType = CommandType.StoredProcedure;

                    sampParm1 = new OleDbParameter();
                    sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_id;
                    sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_request_id;
                    sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                    sampParm1.Value = unique_request_id;
                    sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                    sampParm1.Value = opt;
                    sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                    sampParm1.Value = msisdn;
                    //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                    //     sampParm1.Value = type;
                    sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                    //      sampParm1.Value = msisdn2;
                    sampParm1.Value = rsp_msisdn;

                    //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                    //          sampParm1.Value = amount;
                    //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                    //            sampParm1.Value = rsp_txnstatus;
                    sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                    sampParm1.Value = rsp_extrefnum;

                    sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                    sampParm1.Value = cli;
                    sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.VarWChar, 1000);
                    sampParm1.Value = message;
                    sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                    sampParm1.Value = messagetype;
                    sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                    sampParm1.Value = masking;

                    sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                    sampParm1.Value = no_of_msg;
                    sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarWChar, 10);
                    // sampParm1.Value = rsp_message;
                    sampParm1.Value = rsp_error_code;
                    sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                    //  sampParm1.Value = req_type;
                    sampParm1.Value = "";
                    sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                    //  sampParm1.Value = rsp_date;
                    sampParm1.Value = "";

                    sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                    //sampParm1.Value = rsp_txnid;
                    sampParm1.Value = "";
                    sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                    if (rsp_error_code == "0")
                    {
                        sampParm1.Value = "success";
                    }
                    else
                    {
                        sampParm1.Value = "fail";
                    }
                    sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 50);
                    //sampParm1.Value = req_type;
                    sampParm1.Value = rsp_smsID;
                    sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 11);
                    //sampParm1.Value = rsp_date;
                    sampParm1.Value = "";



                    sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                    sampParm1.Direction = ParameterDirection.Output;


                    try
                    {
                        Console.WriteLine("execute1");
                        connectObj1.Open();
                        sampleCMD1.ExecuteNonQuery();
                        connectObj1.Close();
                        Console.WriteLine("execute2");
                    }
                    catch (Exception ep)
                    {

                        Console.WriteLine(ep.ToString());

                    }*/




                }
            }
            else  // non masking
            {
                if (msisdn2.Length > 0)
                {
                    if (msisdn2.Substring(0, 3) != "880")
                    {
                        msisdn2 = "88" + msisdn2;
                    }
                    /* if (client_id == "win")
                     {
                        try
                        {

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            string url = "http://api.rankstelecom.com/api/v3/sendsms/plain?user=SQLQUEST&password=wiNTelSOL2021@&sender=8804445616355&SMSText=" + message + "&GSM=88" + msisdn2 + "&datacoding=8&type=longSMS";
                                          //http://api.rankstelecom.com/api/v3/sendsms/plain?user=test&password=test&sender=044XXXXXXXX&SMSText=ccš & GSM = 88017XXXXXXXX & datacoding = 8

                            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                            //       webRequest.AllowAutoRedirect = true;
                            webRequest.Timeout = 15000;
                            //   webRequest.KeepAlive = false;

                            //// for untrusted https
                            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                                 delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                                         System.Security.Cryptography.X509Certificates.X509Chain chain,
                                                          System.Net.Security.SslPolicyErrors sslPolicyErrors)
                                 {
                                     return true; // **** Always accept
                             };



                            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                            Stream responsedata = response.GetResponseStream();
                            StreamReader reader = new StreamReader(responsedata);
                            str = reader.ReadToEnd();


                            //    int des_return = (int)response.StatusCode;
                            response.Close();
                            Console.WriteLine(str);

                            DataSet ds = new DataSet();
                            ds.ReadXml(new System.IO.StringReader(str));


                            rsp_error_code = ds.Tables[0].Rows[0]["status"].ToString();
                            rsp_smsID = ds.Tables[0].Rows[0]["messageid"].ToString();
                            rsp_msisdn = ds.Tables[0].Rows[0]["destination"].ToString();
                            //   rsp_extrefnum = ds.Tables[0].Rows[0]["EXTREFNUM"].ToString();
                            //     rsp_txnid = ds.Tables[0].Rows[0]["TXNID"].ToString();
                            //    rsp_message = ds.Tables[0].Rows[0]["MESSAGE"].ToString();
                            Console.WriteLine(rsp_error_code);
                            Console.WriteLine(rsp_smsID);
                            Console.WriteLine(rsp_msisdn);





                        }
                        catch (Exception ep)
                        {
                            Console.WriteLine(ep.ToString());

                        }


                        //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                        //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");

                        //create proc a2p_insert_server_receive @client_id varchar(50),@client_request_id varchar(50),@unique_request_id int, @operator varchar(50),@msisdn varchar(50),@msisdn2 varchar(50),
                        //@extrefnum varchar(50),@cli varchar(50),@message nvarchar(760),@messagetype varchar(10),@masking varchar(11),
                        //@no_of_msg int, @error_code varchar(10),@contact varchar(10),@creditDeducted int, @currentBalance int, @description varchar(400),
                        //@smsID varchar(50),@server_process_date varchar(100),@ismasking varchar(10),@outdata varchar(160) output

                        sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                        sampleCMD1.CommandType = CommandType.StoredProcedure;

                        sampParm1 = new OleDbParameter();
                        sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                        sampParm1.Value = unique_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                        sampParm1.Value = opt;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn;
                        //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                        //     sampParm1.Value = type;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                        //      sampParm1.Value = msisdn2;
                        sampParm1.Value = rsp_msisdn;

                        //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                        //          sampParm1.Value = amount;
                        //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                        //            sampParm1.Value = rsp_txnstatus;
                        sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                        sampParm1.Value = extrefnum;

                        sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                        sampParm1.Value = cli;
                        sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 760);
                        sampParm1.Value = message;
                        sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                        sampParm1.Value = messagetype;
                        sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                        sampParm1.Value = masking;

                        sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                        sampParm1.Value = no_of_msg;
                        sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                        // sampParm1.Value = rsp_message;
                        sampParm1.Value = rsp_error_code;
                        sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                        //  sampParm1.Value = req_type;
                        sampParm1.Value = rsp_contact;
                        sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                        //sampParm1.Value = no_of_msg;
                        sampParm1.Value = no_of_msg;

                        sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                        sampParm1.Value = 1;
                        //sampParm1.Value = rsp_currentBalance;
                        sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarChar, 400);
                        if (rsp_error_code == "0")
                        {
                            sampParm1.Value = "success";
                        }
                        else
                        {
                            sampParm1.Value = "fail";
                        }
                        sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 50);
                        //sampParm1.Value = req_type;
                        sampParm1.Value = rsp_smsID;
                        sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                        //sampParm1.Value = rsp_date;
                        sampParm1.Value = DateTime.Now;

                        sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                        sampParm1.Value = ismasking;

                        sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                        sampParm1.Value = unicode;

                        sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                        sampParm1.Direction = ParameterDirection.Output;


                        try
                        {
                            Console.WriteLine("execute1");
                            connectObj1.Open();
                            sampleCMD1.ExecuteNonQuery();
                            connectObj1.Close();
                            Console.WriteLine("execute2");
                        }
                        catch (Exception ep)
                        {

                            Console.WriteLine(ep.ToString());

                        }
                    }*/

                    //else
                    //{ 

                    // using teletalk API



                    /*try
                    {

                        System.Net.ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12


                        //HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://agentapi.paywellonline.com/Recharge/mobileRecharge/singleTopup");
                        //HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://agentapi.paywellonline.com/Recharge/mobileRecharge/mobileRechargeEnquiry");
                        HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("http://bulkmsg.teletalk.com.bd/api/sendSMS");



                        httpPost.Headers.Add("ContentType", "application/json");
                        httpPost.Method = "POST";





                        using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                        {

                            string json = new JavaScriptSerializer().Serialize(new
                            {
                                auth = new
                                {
                                    username = "wintel2nd",
                                    password = "WinTtmgsP#45R5z",
                                    acode = "1005210"

                                },

                                smsInfo = new
                                {
                                    message = message,
                                    //masking = "8801552146270",
                                    is_unicode = unicode_value,
                                    masking = "8801552146271",
                                    msisdn = new[] { msisdn2 },
                                    //01534983669
                                }

                            });


                            streamWriter.Write(json);
                        }



                        //string backstr = string.Empty;

                        HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                        using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                        {
                            backstr = sr.ReadToEnd();
                            res.Close();
                        }
                        //sr.Close();
                        //res.Close();

                        try
                        {

                            // {"error_code":0,"contact":1,"creditDeducted":2,"currentBalance":"3","description":"Success",
                            //"smsInfo":[{"smsID":"202010051243335f7ac0957a440","msisdn":"8801550156198"}]}


                            Console.WriteLine("backstr :" + backstr);
                            JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                            rspdata oRootObject2 = oJS2.Deserialize<rspdata>(backstr);

                            // int status = oRootObject2.data.status;
                            rsp_error_code = oRootObject2.error_code.ToString();
                            // if (oRootObject2.contact != null)
                            // {
                            rsp_contact = oRootObject2.contact.ToString();
                            //  }
                            if (oRootObject2.creditDeducted.ToString() != null)
                            {
                                rsp_creditDeducted = oRootObject2.creditDeducted.ToString();
                            }

                            if (oRootObject2.currentBalance.ToString() != null)
                            {

                                rsp_currentBalance = oRootObject2.currentBalance.ToString();
                            }
                            if (oRootObject2.description.ToString() != null)
                            {
                                rsp_description = oRootObject2.description.ToString();
                            }
                            foreach (smsInfo cad in oRootObject2.smsInfo)
                            {
                                rsp_smsID = cad.smsID.ToString();
                                rsp_msisdn = cad.msisdn.ToString();
                            }
                            //status,message,trans_id,msisdn,amount,con_type,operator,clientTrxId

                            Console.WriteLine("rsp_error_code : " + rsp_error_code.ToString());
                            //  Console.WriteLine("<br>");
                            Console.WriteLine("rsp_contact :" + rsp_contact.ToString());
                            //  Console.WriteLine("<br>");
                            Console.WriteLine("rsp_creditDeducted :" + rsp_creditDeducted.ToString());
                            //  Console.WriteLine("<br>");
                            Console.WriteLine("rsp_currentBalance :" + rsp_currentBalance.ToString());
                            Console.WriteLine("rsp_description :" + rsp_description.ToString());
                            Console.WriteLine("rsp_smsID :" + rsp_smsID.ToString());
                            Console.WriteLine("rsp_msisdn :" + rsp_msisdn.ToString());
                            //   Console.WriteLine("clientTrxId :" + clientTrxId.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());

                        }




                    }
                    catch (System.Exception etext)
                    {

                        Console.WriteLine(etext.ToString());

                    }




















                    //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                    //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");

                    //create proc a2p_insert_server_receive @client_id varchar(50),@client_request_id varchar(50),@unique_request_id int, @operator varchar(50),@msisdn varchar(50),@msisdn2 varchar(50),
                    //@extrefnum varchar(50),@cli varchar(50),@message nvarchar(760),@messagetype varchar(10),@masking varchar(11),
                    //@no_of_msg int, @error_code varchar(10),@contact varchar(10),@creditDeducted int, @currentBalance int, @description varchar(400),
                    //@smsID varchar(50),@server_process_date varchar(100),@ismasking varchar(10),@outdata varchar(160) output

                    sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                    sampleCMD1.CommandType = CommandType.StoredProcedure;

                    sampParm1 = new OleDbParameter();
                    sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_id;
                    sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                    sampParm1.Value = client_request_id;
                    sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                    sampParm1.Value = unique_request_id;
                    sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                    sampParm1.Value = opt;
                    sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                    sampParm1.Value = msisdn;
                    //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                    //     sampParm1.Value = type;
                    sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                    //      sampParm1.Value = msisdn2;
                    sampParm1.Value = rsp_msisdn;

                    //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                    //          sampParm1.Value = amount;
                    //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                    //            sampParm1.Value = rsp_txnstatus;
                    sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                    sampParm1.Value = extrefnum;

                    sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                    sampParm1.Value = cli;
                    sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                    sampParm1.Value = message;
                    sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                    sampParm1.Value = messagetype;
                    sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                    sampParm1.Value = masking;

                    sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                    sampParm1.Value = no_of_msg;
                    sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                    // sampParm1.Value = rsp_message;
                    sampParm1.Value = rsp_error_code;
                    sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                    //  sampParm1.Value = req_type;
                    sampParm1.Value = rsp_contact;
                    sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                    //sampParm1.Value = no_of_msg;
                    sampParm1.Value = rsp_creditDeducted;

                    sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                    //sampParm1.Value = 1;
                    sampParm1.Value = rsp_currentBalance;
                    sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarChar, 400);
                    if (rsp_error_code == "0")
                    {
                        sampParm1.Value = "success";
                    }
                    else
                    {
                        sampParm1.Value = "fail";
                    }
                    sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 50);
                    //sampParm1.Value = req_type;
                    sampParm1.Value = rsp_smsID;
                    sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                    //sampParm1.Value = rsp_date;
                    sampParm1.Value = DateTime.Now;

                    sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                    sampParm1.Value = ismasking;

                    sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                    sampParm1.Value = unicode;

                    sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                    sampParm1.Direction = ParameterDirection.Output;


                    try
                    {
                        Console.WriteLine("execute1");
                        connectObj1.Open();
                        sampleCMD1.ExecuteNonQuery();
                        connectObj1.Close();
                        Console.WriteLine("execute2");
                    }
                    catch (Exception ep)
                    {

                        Console.WriteLine(ep.ToString());

                    }*/

                    if (client_id == "ibbl" || client_id == "Rockstreamer" || client_id == "samsung")
                    {
                        try
                        {
                            //string longcode = string.Empty;
                            string bilmsdn = string.Empty;

                            if (client_id == "ibbl")
                            {
                                longcode = "8809617516259";
                                bilmsdn = "8809617516259";
                            }
                            else if (client_id == "Rockstreamer" || client_id == "samsung")
                            {
                                longcode = "8809617613688";
                                bilmsdn = "8809617613688";
                            }

                            string isLongSMSchk = string.Empty;

                            if (no_of_msg > 1)
                            {
                                isLongSMSchk = "true";
                            }
                            else
                            {
                                isLongSMSchk = "false";
                            }

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms-iptsp/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "WINTEL-BD",
                                    password = "@WINA2Pranks2k&",
                                    billMsisdn = bilmsdn,
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = longcode,
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    isLongSMS = isLongSMSchk,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine(client_id + " : RangtsITT :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }


                        ///////
                        ///
                        try
                        {
                            JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                            centraldata oRootObject2 = oJS2.Deserialize<centraldata>(backstr);

                            //{"serverTxnId":"f470e954-ef82-4d8d-ad5e-3228ab9e9b28","serverResponseCode":9000,"serverResponseMessage":"Request successful!","mnoTxnId":"GP20230321145336-01729021852-1332115331679388816642830","mnoResponseCode":"1000","mnoResponseMessage":"Success"}
                            /*string serverTxnId = oRootObject2.serverTxnId.ToString();
                            string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                            string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                            string mnoTxnId = oRootObject2.mnoTxnId.ToString();
                            string mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                            string mnoResponseMessage = oRootObject2.mnoResponseMessage.ToString();*/

                            //string serverTxnId = oRootObject2.serverTxnId.ToString();
                            string serverTxnId = "";
                            if (oRootObject2.serverTxnId.Length > 0)
                            {
                                serverTxnId = oRootObject2.serverTxnId.ToString();
                            }
                            else
                            {
                                serverTxnId = "";
                            }
                            string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                            string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                            string mnoTxnId = "";

                            if (oRootObject2.mnoTxnId != null)
                            {
                                mnoTxnId = oRootObject2.mnoTxnId.ToString();
                            }
                            else
                            {
                                mnoTxnId = "";
                            }
                            string mnoResponseCode = "";
                            if (oRootObject2.mnoResponseCode != null)
                            {
                                mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                            }
                            else
                            {
                                mnoResponseCode = "";
                            }

                            //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                            //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");


                            /*sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                            sampleCMD1.CommandType = CommandType.StoredProcedure;

                            sampParm1 = new OleDbParameter();
                            sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                            sampParm1.Value = client_id;
                            sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                            sampParm1.Value = client_request_id;
                            sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                            sampParm1.Value = unique_request_id;
                            sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                            sampParm1.Value = opt;
                            sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                            sampParm1.Value = msisdn;
                            //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                            //     sampParm1.Value = type;
                            sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                            sampParm1.Value = msisdn2;
                            //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                            //          sampParm1.Value = amount;
                            //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                            //            sampParm1.Value = rsp_txnstatus;
                            sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                            sampParm1.Value = extrefnum;

                            sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                            sampParm1.Value = cli;
                            sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                            sampParm1.Value = message;
                            sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                            sampParm1.Value = messagetype;
                            sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                            sampParm1.Value = "";

                            sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                            sampParm1.Value = no_of_msg;
                            sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                            // sampParm1.Value = rsp_message;
                            sampParm1.Value = serverResponseCode;
                            sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                            //  sampParm1.Value = req_type;
                            sampParm1.Value = "";
                            sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                            //  sampParm1.Value = rsp_date;
                            sampParm1.Value = 0;

                            sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                            //sampParm1.Value = rsp_txnid;
                            sampParm1.Value = 0;
                            sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                            //sampParm1.Value = str;
                            if (mnoResponseCode == "1000")
                            {
                                sampParm1.Value = "success";
                            }
                            else
                            {
                                sampParm1.Value = "fail : mnoResponseCode : " + mnoResponseCode;
                            }
                            sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 200);
                            //sampParm1.Value = req_type;
                            sampParm1.Value = "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId;
                            sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                            //sampParm1.Value = rsp_date;
                            sampParm1.Value = DateTime.Now;

                            sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                            sampParm1.Value = ismasking;

                            sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                            sampParm1.Value = unicode;

                            sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                            sampParm1.Direction = ParameterDirection.Output;


                            try
                            {
                                Console.WriteLine("execute1");
                                connectObj1.Open();
                                sampleCMD1.ExecuteNonQuery();
                                connectObj1.Close();
                                Console.WriteLine("execute2");
                            }
                            catch (Exception ep)
                            {

                                Console.WriteLine(ep.ToString());

                            }*/
                            using (var conn = new NpgsqlConnection(connString))
                            {
                                //conn.Open();

                                using (var cmd = new NpgsqlCommand("a2p_insert_server_receive", conn))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                    // Input parameter
                                    cmd.Parameters.AddWithValue("client_idd", client_id);
                                    cmd.Parameters.AddWithValue("client_request_idd", client_request_id);
                                    cmd.Parameters.AddWithValue("unique_request_idd", unique_request_id);
                                    cmd.Parameters.AddWithValue("operatorr", opt);
                                    cmd.Parameters.AddWithValue("msisdnn", longcode);
                                    cmd.Parameters.AddWithValue("msisdn22", msisdn2);
                                    cmd.Parameters.AddWithValue("extrefnumm", extrefnum);
                                    cmd.Parameters.AddWithValue("clii", cli);
                                    cmd.Parameters.AddWithValue("messagee", message);
                                    cmd.Parameters.AddWithValue("messagetypee", messagetype);
                                    cmd.Parameters.AddWithValue("maskingg", "");
                                    cmd.Parameters.AddWithValue("no_of_msgg", no_of_msg);
                                    cmd.Parameters.AddWithValue("error_codee", serverResponseCode);
                                    cmd.Parameters.AddWithValue("contactt", "");
                                    cmd.Parameters.AddWithValue("creditDeductedd", 0);
                                    cmd.Parameters.AddWithValue("currentBalancee", 0);
                                    if (mnoResponseCode == "1000")
                                    {
                                        cmd.Parameters.AddWithValue("descriptionn", "success");
                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("descriptionn", "fail : mnoResponseCode : " + mnoResponseCode);
                                    }

                                    cmd.Parameters.AddWithValue("smsIDD", "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId);
                                    cmd.Parameters.AddWithValue("server_process_datee", DateTime.Now);
                                    cmd.Parameters.AddWithValue("ismaskingg", ismasking);
                                    cmd.Parameters.AddWithValue("unicodee", unicode);

                                    // Output parameters
                                    var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                                    {
                                        Direction = System.Data.ParameterDirection.Output
                                    };
                                    cmd.Parameters.Add(output);

                                    // Execute the command



                                    // Retrieve output values
                                    try
                                    {
                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                        conn.Close();
                                        Console.WriteLine("execute1");
                                        Console.WriteLine("execute2");
                                    }
                                    catch (Exception ext)
                                    {
                                        conn.Close();
                                        Console.WriteLine(ext.ToString());
                                    }

                                    // Example: Display the results
                                    //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                                }
                            }
                        }
                        catch (Exception ep)
                        {
                            Console.WriteLine("Infozillion API down");
                        }

                    }
                    /*else if (client_id == "fresh" || client_id == "NorthSouthGroup" || client_id == "skincafeltd" || client_id == "etymology" || client_id == "eduskill" || client_id == "motionview" || client_id == "zenditsolution" || client_id == "dmoney" || client_id == "samsung")
                    {
                        try
                        {
                            string longcode = string.Empty;
                            string bilmsdn = string.Empty;
                            longcode = "8809604905000";
                            bilmsdn = "8809604905000";

                            string isLongSMSchk = string.Empty;

                            if (no_of_msg > 1)
                            {
                                isLongSMSchk = "true";
                            }
                            else
                            {
                                isLongSMSchk = "false";
                            }

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms-iptsp/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "wintel",
                                    password = "wintel@bd",
                                    billMsisdn = bilmsdn,
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = longcode,
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    isLongSMS = isLongSMSchk,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine(client_id + " : FUSION :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }


                        ///////
                        ///
                        try
                        {
                            JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                            centraldata oRootObject2 = oJS2.Deserialize<centraldata>(backstr);

                            //{"serverTxnId":"f470e954-ef82-4d8d-ad5e-3228ab9e9b28","serverResponseCode":9000,"serverResponseMessage":"Request successful!","mnoTxnId":"GP20230321145336-01729021852-1332115331679388816642830","mnoResponseCode":"1000","mnoResponseMessage":"Success"}


                            //string serverTxnId = oRootObject2.serverTxnId.ToString();
                            string serverTxnId = "";
                            if (oRootObject2.serverTxnId.Length > 0)
                            {
                                serverTxnId = oRootObject2.serverTxnId.ToString();
                            }
                            else
                            {
                                serverTxnId = "";
                            }
                            string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                            string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                            string mnoTxnId = "";

                            if (oRootObject2.mnoTxnId != null)
                            {
                                mnoTxnId = oRootObject2.mnoTxnId.ToString();
                            }
                            else
                            {
                                mnoTxnId = "";
                            }
                            string mnoResponseCode = "";
                            if (oRootObject2.mnoResponseCode != null)
                            {
                                mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                            }
                            else
                            {
                                mnoResponseCode = "";
                            }

                            //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                            //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");


                            sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                            sampleCMD1.CommandType = CommandType.StoredProcedure;

                            sampParm1 = new OleDbParameter();
                            sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                            sampParm1.Value = client_id;
                            sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                            sampParm1.Value = client_request_id;
                            sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                            sampParm1.Value = unique_request_id;
                            sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                            sampParm1.Value = opt;
                            sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                            sampParm1.Value = msisdn;
                            //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                            //     sampParm1.Value = type;
                            sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                            sampParm1.Value = msisdn2;
                            //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                            //          sampParm1.Value = amount;
                            //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                            //            sampParm1.Value = rsp_txnstatus;
                            sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                            sampParm1.Value = extrefnum;

                            sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                            sampParm1.Value = cli;
                            sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                            sampParm1.Value = message;
                            sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                            sampParm1.Value = messagetype;
                            sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                            sampParm1.Value = "";

                            sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                            sampParm1.Value = no_of_msg;
                            sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                            // sampParm1.Value = rsp_message;
                            sampParm1.Value = serverResponseCode;
                            sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                            //  sampParm1.Value = req_type;
                            sampParm1.Value = "";
                            sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                            //  sampParm1.Value = rsp_date;
                            sampParm1.Value = 0;

                            sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                            //sampParm1.Value = rsp_txnid;
                            sampParm1.Value = 0;
                            sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                            //sampParm1.Value = str;
                            if (mnoResponseCode == "1000")
                            {
                                sampParm1.Value = "success";
                            }
                            else
                            {
                                sampParm1.Value = "fail";
                            }
                            sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 200);
                            //sampParm1.Value = req_type;
                            sampParm1.Value = "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId;
                            sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                            //sampParm1.Value = rsp_date;
                            sampParm1.Value = DateTime.Now;

                            sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                            sampParm1.Value = ismasking;

                            sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                            sampParm1.Value = unicode;

                            sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                            sampParm1.Direction = ParameterDirection.Output;


                            try
                            {
                                Console.WriteLine("execute1");
                                connectObj1.Open();
                                sampleCMD1.ExecuteNonQuery();
                                connectObj1.Close();
                                Console.WriteLine("execute2");
                            }
                            catch (Exception ep)
                            {

                                Console.WriteLine(ep.ToString());

                            }
                        }
                        catch (Exception ep)
                        {
                            Console.WriteLine("Infozillion API down");
                        }

                    }*/



                    //non masking through TT central platform

                    else
                    {
                        try
                        {

                            string md5_sppassword = string.Empty;
                            string Pmd5 = "WinTP@45R5z";
                            md5_sppassword = getMd5Hashtt(Pmd5);

                            //

                            //string longcode = string.Empty;

                            if (client_id == "shwapno")
                            {
                                longcode = "01552146388";
                                //bilmsdn = "8809617516259";
                            }
                            else
                            {
                                longcode = "01552146271";
                                //bilmsdn = "8809617613688";
                            }

                            //

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "wintel2",
                                    password = md5_sppassword,
                                    billMsisdn = "01552146271",
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = longcode,
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine("TT :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }

                        //non masking through BL central platform

                        /*try
                        {

                            System.Net.ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // SecurityProtocolType.Tls12

                            HttpWebRequest httpPost = (HttpWebRequest)WebRequest.Create("https://api.mnpspbd.com/a2p-sms/api/v1/send-sms");

                            httpPost.ContentType = "application/json";
                            httpPost.Method = "POST";

                            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream()))
                            {

                                string json = new JavaScriptSerializer().Serialize(new
                                {
                                    username = "WINTEL1",
                                    password = "wIncenT#&2k24",
                                    billMsisdn = "01905440573",
                                    //usernameSecondary = "rana@wintelbd.com",
                                    //passwordSecondary = "8eKS1tymXm",
                                    //billMsisdnSecondary = "8801810077622",
                                    apiKey = "yDRGoPpkTELT974ya9i3uwENrhse3RUO",
                                    cli = "01905440573",
                                    msisdnList = new[] { msisdn2 },
                                    transactionType = "T",
                                    messageType = messagetype1,
                                    //campaignId = "cmp-aw5v34ix2o",
                                    message = message
                                });


                                streamWriter.Write(json);
                            }





                            HttpWebResponse res = (HttpWebResponse)httpPost.GetResponse();

                            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default))
                            {
                                backstr = sr.ReadToEnd();
                                res.Close();
                            }
                            try
                            {
                                Console.WriteLine("BL :" + backstr);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());

                            }


                        }
                        catch (System.Exception etext)
                        {

                            Console.WriteLine(etext.ToString());

                        }*/

                        JavaScriptSerializer oJS2 = new JavaScriptSerializer();
                        centraldata oRootObject2 = oJS2.Deserialize<centraldata>(backstr);

                        //{"serverTxnId":"f470e954-ef82-4d8d-ad5e-3228ab9e9b28","serverResponseCode":9000,"serverResponseMessage":"Request successful!","mnoTxnId":"GP20230321145336-01729021852-1332115331679388816642830","mnoResponseCode":"1000","mnoResponseMessage":"Success"}
                        /*string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        string mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        string mnoResponseMessage = oRootObject2.mnoResponseMessage.ToString();*/

                        string serverTxnId = oRootObject2.serverTxnId.ToString();
                        string serverResponseCode = oRootObject2.serverResponseCode.ToString();
                        string serverResponseMessage = oRootObject2.serverResponseMessage.ToString();
                        string mnoTxnId = "";

                        if (oRootObject2.mnoTxnId != null)
                        {
                            mnoTxnId = oRootObject2.mnoTxnId.ToString();
                        }
                        else
                        {
                            mnoTxnId = "";
                        }
                        string mnoResponseCode = "";
                        if (oRootObject2.mnoResponseCode != null)
                        {
                            mnoResponseCode = oRootObject2.mnoResponseCode.ToString();
                        }
                        else
                        {
                            mnoResponseCode = "";
                        }

                        //OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.125;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");
                        //                          OleDbConnection connectObj1 = new OleDbConnection("Provider=SQLOLEDB;Data Source=192.168.3.9;uid=sa;pwd=k7b8a9;" + "Initial Catalog=smscontentnew");


                        /*sampleCMD1 = new OleDbCommand("a2p_insert_server_receive", connectObj1);
                        sampleCMD1.CommandType = CommandType.StoredProcedure;

                        sampParm1 = new OleDbParameter();
                        sampParm1 = sampleCMD1.Parameters.Add("@client_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@client_request_id", OleDbType.VarChar, 50);
                        sampParm1.Value = client_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@unique_request_id", OleDbType.Integer);
                        sampParm1.Value = unique_request_id;
                        sampParm1 = sampleCMD1.Parameters.Add("@operator", OleDbType.VarChar, 50);
                        sampParm1.Value = opt;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn;
                        //     sampParm1 = sampleCMD1.Parameters.Add("@type", OleDbType.VarChar, 50);
                        //     sampParm1.Value = type;
                        sampParm1 = sampleCMD1.Parameters.Add("@msisdn2", OleDbType.VarChar, 50);
                        sampParm1.Value = msisdn2;
                        //             sampParm1 = sampleCMD1.Parameters.Add("@amount", OleDbType.Integer);
                        //          sampParm1.Value = amount;
                        //            sampParm1 = sampleCMD1.Parameters.Add("@txnstatus", OleDbType.VarChar, 50);
                        //            sampParm1.Value = rsp_txnstatus;
                        sampParm1 = sampleCMD1.Parameters.Add("@extrefnum", OleDbType.VarChar, 50);
                        sampParm1.Value = extrefnum;

                        sampParm1 = sampleCMD1.Parameters.Add("@cli", OleDbType.VarChar, 50);
                        sampParm1.Value = cli;
                        sampParm1 = sampleCMD1.Parameters.Add("@message", OleDbType.WChar, 1000);
                        sampParm1.Value = message;
                        sampParm1 = sampleCMD1.Parameters.Add("@messagetype", OleDbType.VarChar, 10);
                        sampParm1.Value = messagetype;
                        sampParm1 = sampleCMD1.Parameters.Add("@masking", OleDbType.VarChar, 11);
                        sampParm1.Value = "";

                        sampParm1 = sampleCMD1.Parameters.Add("@no_of_msg", OleDbType.Integer);
                        sampParm1.Value = no_of_msg;
                        sampParm1 = sampleCMD1.Parameters.Add("@error_code", OleDbType.VarChar, 10);
                        // sampParm1.Value = rsp_message;
                        sampParm1.Value = serverResponseCode;
                        sampParm1 = sampleCMD1.Parameters.Add("@contact", OleDbType.VarChar, 10);
                        //  sampParm1.Value = req_type;
                        sampParm1.Value = "";
                        sampParm1 = sampleCMD1.Parameters.Add("@creditDeducted", OleDbType.Integer);
                        //  sampParm1.Value = rsp_date;
                        sampParm1.Value = 0;

                        sampParm1 = sampleCMD1.Parameters.Add("@currentBalance", OleDbType.Integer);
                        //sampParm1.Value = rsp_txnid;
                        sampParm1.Value = 0;
                        sampParm1 = sampleCMD1.Parameters.Add("@description", OleDbType.VarWChar, 400);
                        //sampParm1.Value = str;
                        if (mnoResponseCode == "1000")
                        {
                            sampParm1.Value = "success";
                        }
                        else
                        {
                            sampParm1.Value = "fail : mnoResponseCode : " + mnoResponseCode;
                        }
                        sampParm1 = sampleCMD1.Parameters.Add("@smsID", OleDbType.VarChar, 200);
                        //sampParm1.Value = req_type;
                        sampParm1.Value = "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId;
                        sampParm1 = sampleCMD1.Parameters.Add("@server_process_date", OleDbType.VarChar, 100);
                        //sampParm1.Value = rsp_date;
                        sampParm1.Value = DateTime.Now;

                        sampParm1 = sampleCMD1.Parameters.Add("@ismasking", OleDbType.VarChar, 10);
                        sampParm1.Value = ismasking;

                        sampParm1 = sampleCMD1.Parameters.Add("@unicode", OleDbType.VarChar, 20);
                        sampParm1.Value = unicode;

                        sampParm1 = sampleCMD1.Parameters.Add("@outdata", OleDbType.VarChar, 160);
                        sampParm1.Direction = ParameterDirection.Output;


                        try
                        {
                            Console.WriteLine("execute1");
                            connectObj1.Open();
                            sampleCMD1.ExecuteNonQuery();
                            connectObj1.Close();
                            Console.WriteLine("execute2");
                        }
                        catch (Exception ep)
                        {
                            Console.WriteLine(ep.ToString());
                        }*/
                        using (var conn = new NpgsqlConnection(connString))
                        {
                            //conn.Open();

                            using (var cmd = new NpgsqlCommand("a2p_insert_server_receive", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                                // Input parameter
                                cmd.Parameters.AddWithValue("client_idd", client_id);
                                cmd.Parameters.AddWithValue("client_request_idd", client_request_id);
                                cmd.Parameters.AddWithValue("unique_request_idd", unique_request_id);
                                cmd.Parameters.AddWithValue("operatorr", opt);
                                cmd.Parameters.AddWithValue("msisdnn", longcode);
                                cmd.Parameters.AddWithValue("msisdn22", msisdn2);
                                cmd.Parameters.AddWithValue("extrefnumm", extrefnum);
                                cmd.Parameters.AddWithValue("clii", cli);
                                cmd.Parameters.AddWithValue("messagee", message);
                                cmd.Parameters.AddWithValue("messagetypee", messagetype);
                                cmd.Parameters.AddWithValue("maskingg", "");
                                cmd.Parameters.AddWithValue("no_of_msgg", no_of_msg);
                                cmd.Parameters.AddWithValue("error_codee", serverResponseCode);
                                cmd.Parameters.AddWithValue("contactt", "");
                                cmd.Parameters.AddWithValue("creditDeductedd", 0);
                                cmd.Parameters.AddWithValue("currentBalancee", 0);
                                if (mnoResponseCode == "1000")
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "success");
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("descriptionn", "fail : mnoResponseCode : " + mnoResponseCode);
                                }

                                cmd.Parameters.AddWithValue("smsIDD", "serverTxnId : " + serverTxnId + " mnoTxnId : " + mnoTxnId);
                                cmd.Parameters.AddWithValue("server_process_datee", DateTime.Now);
                                cmd.Parameters.AddWithValue("ismaskingg", ismasking);
                                cmd.Parameters.AddWithValue("unicodee", unicode);

                                // Output parameters
                                var output = new NpgsqlParameter("outdata", NpgsqlTypes.NpgsqlDbType.Varchar, 160)
                                {
                                    Direction = System.Data.ParameterDirection.Output
                                };
                                cmd.Parameters.Add(output);

                                // Execute the command



                                // Retrieve output values
                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    Console.WriteLine("execute1");
                                    Console.WriteLine("execute2");
                                }
                                catch (Exception ext)
                                {
                                    conn.Close();
                                    Console.WriteLine(ext.ToString());
                                }

                                // Example: Display the results
                                //Response.Write($"Name: {empName}<br/>Department: {empDepartment}");
                            }
                        }
                    }
                }
            }
        }
        public static string getMd5Hashtt(string input)
        {
            // We have created an instance of the MD5CryptoServiceProvider class.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //We converted the data as a parameter to a byte array.
            byte[] array = Encoding.UTF8.GetBytes(input);
            //We have calculated the hash of the array.
            array = md5.ComputeHash(array);
            //We created a StringBuilder object to store hashed data.
            StringBuilder sb = new StringBuilder();
            //We have converted each byte from string into string type.

            foreach (byte ba in array)
            {
                sb.Append(ba.ToString("x2"));
            }

            //We returned the hexadecimal string.
            return sb.ToString();
        }
        public class centraldata
        {
            public string serverTxnId { get; set; }
            public int serverResponseCode { get; set; }
            public string serverResponseMessage { get; set; }
            public string mnoTxnId { get; set; }
            public string mnoResponseCode { get; set; }
            public string mnoResponseMessage { get; set; }
        }
    }
}
