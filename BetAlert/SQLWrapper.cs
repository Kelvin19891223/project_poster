using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetAlert
{
    class SQLWrapper
    {
        public SQLiteConnection sql_con;
        public SQLiteCommand sql_cmd;
        private System.Object locker = new System.Object();

        public SQLWrapper() { }

        public void CreateFile(string file_name)
        {
            SQLiteConnection.CreateFile(file_name);
        }

        public void CreatConnection(string file_name)
        {
            try
            {
                string conn = "Data Source=" + file_name + ";Version=3;New=True;Compress=True;";
                sql_con = new SQLiteConnection(conn);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to create SQLite connection. {ex.Message}");
            }
        }

        public void Open()
        {
            try
            {
                sql_con.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to open SQLite connection.  {ex.Message}");
            }
        }

        public void Close()
        {
            try
            {
                sql_con.Close();
                sql_con.Dispose();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to close SQLite connection.  {ex.Message}");
            }
        }

        public void ExecuteNonQuery(string txtQuery)
        {
            try
            {
                lock (locker)
                {
                    sql_cmd = sql_con.CreateCommand();
                    sql_cmd.CommandText = txtQuery;
                    sql_cmd.ExecuteNonQuery();
                    sql_cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to execute SQLite query.\n{txtQuery}\n {ex.Message}");
            }
        }

        public DataTable ExecuteQuery(string txtQuery)
        {
            try
            {
                lock (locker)
                {
                    DataTable dt = new DataTable();
                    sql_cmd = sql_con.CreateCommand();
                    SQLiteDataAdapter DB = new SQLiteDataAdapter(txtQuery, sql_con);
                    DB.SelectCommand.CommandType = CommandType.Text;
                    DB.Fill(dt);
                    sql_cmd.Dispose();
                    System.Diagnostics.Debug.WriteLine("Execute SQLite Query: " + txtQuery + " -> " + dt.Rows.Count.ToString());
                    return dt;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to execute SQLite query.\n{txtQuery}\n {ex.Message}");
            }
            return null;
        }

        public List<string> getMarketIds(string today)
        {
            List<string> result = new List<string>();
            try
            {
                DataTable DT = new DataTable();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = string.Format("SELECT selection_id from bethistory WHERE date='{0}'", today);
                //sql_cmd.CommandText = string.Format("SELECT selection_id from bethistory WHERE date={0} and result='Success' ", today);
                var adapter = new SQLiteDataAdapter(sql_cmd);
                adapter.AcceptChangesDuringFill = false;
                adapter.Fill(DT);

                DT.TableName = "bethistory";
                foreach (DataRow row in DT.Rows)
                {
                    row.AcceptChanges();
                }

                for(var k=0; k< DT.Rows.Count; k++)
                {
                    result.Add(DT.Rows[k]["selection_id"].ToString());
                }

            } catch(Exception) { }
            return result;
        }

        public DataTable getAccountInfo()
        {            
            try
            {
                DataTable DT = new DataTable();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = string.Format("SELECT * from account_info");
                var adapter = new SQLiteDataAdapter(sql_cmd);
                adapter.AcceptChangesDuringFill = false;
                adapter.Fill(DT);

                DT.TableName = "account_info";
                foreach (DataRow row in DT.Rows)
                {
                    row.AcceptChanges();
                }

                return DT;
            }
            catch (Exception) { }
            return null;
        }

        public void deleteAccountInfo(string id)
        {
            try
            {
                string query = string.Format("delete from account_info where id={0}", id);
                this.ExecuteNonQuery(query);
            } catch(Exception) { }
        }

        public void saveAccountInfo(string bookmaker, string username, string password, string answer)
        {
            try
            {
                sql_cmd = sql_con.CreateCommand();
                String query = "insert into account_info(bookmaker,account_name,account_password, answer) values(@bookmaker,@account_name,@account_password,@answer)";

                sql_cmd = new SQLiteCommand(query, sql_cmd.Connection);
                sql_cmd.Parameters.Add("@bookmaker", DbType.String, 100);
                sql_cmd.Parameters.Add("@account_name", DbType.String, 255);
                sql_cmd.Parameters.Add("@account_password", DbType.String, 255);
                sql_cmd.Parameters.Add("@answer", DbType.String, 255);

                sql_cmd.Parameters["@bookmaker"].Value = bookmaker;
                sql_cmd.Parameters["@account_name"].Value = username;
                sql_cmd.Parameters["@account_password"].Value = password;
                sql_cmd.Parameters["@answer"].Value = answer;

                sql_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save parameter.{ex.Message}");
            }
        }    
        
        public void saveHistory(string account_name, string bookmaker, string result)
        {
            try
            {
                sql_cmd = sql_con.CreateCommand();
                String query = "insert into alerthistory(bookmaker,account_name,time,result) values(@bookmaker,@account_name,@time,@result)";

                sql_cmd = new SQLiteCommand(query, sql_cmd.Connection);
                sql_cmd.Parameters.Add("@bookmaker", DbType.String, 100);
                sql_cmd.Parameters.Add("@account_name", DbType.String, 255);
                sql_cmd.Parameters.Add("@time", DbType.String, 255);
                sql_cmd.Parameters.Add("@result", DbType.String, 255);

                sql_cmd.Parameters["@bookmaker"].Value = bookmaker;
                sql_cmd.Parameters["@account_name"].Value = account_name;
                sql_cmd.Parameters["@time"].Value = MainApp.AuNow().ToString("yyyy-MM-dd HH:mm:ss");
                sql_cmd.Parameters["@result"].Value = result;

                sql_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save parameter.{ex.Message}");
            }
        }

        public DataTable getHistory(string from, string to)
        {
            try
            {
                DataTable DT = new DataTable();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = string.Format("SELECT * from alerthistory where time>'{0} 00:00:00' and time < '{1} 23:59:59'",from,to);
                var adapter = new SQLiteDataAdapter(sql_cmd);
                adapter.AcceptChangesDuringFill = false;
                adapter.Fill(DT);

                DT.TableName = "alerthistory";
                foreach (DataRow row in DT.Rows)
                {
                    row.AcceptChanges();
                }

                return DT;
            }
            catch (Exception) { }
            return null;
        }

        public void saveContent(string title, string _content, string flag)
        {
            try
            {
                sql_cmd = sql_con.CreateCommand();
                String query = "insert into content(title,content,flag) values(@title,@content,@flag)";

                sql_cmd = new SQLiteCommand(query, sql_cmd.Connection);
                sql_cmd.Parameters.Add("@title", DbType.String, 1000);
                sql_cmd.Parameters.Add("@content", DbType.String, 255);
                sql_cmd.Parameters.Add("@flag", DbType.String, 20);

                sql_cmd.Parameters["@title"].Value = title;
                sql_cmd.Parameters["@content"].Value = _content;
                sql_cmd.Parameters["@flag"].Value = flag;

                sql_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save parameter.{ex.Message}");
            }
        }

        public void deleteContent(string id)
        {
            try
            {
                string query = string.Format("delete from content where id={0}",id);
                this.ExecuteNonQuery(query);
            }
            catch (Exception) { }
        }

        public void updateContentFlag(string id, string flag)
        {
            try
            {
                string query = string.Format("update content set flag='{0}' where id={1}", flag, id);
                this.ExecuteNonQuery(query);
            }
            catch (Exception) { }
        }

        public DataTable getContent()
        {
            try
            {
                DataTable DT = new DataTable();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = string.Format("SELECT * from content");
                var adapter = new SQLiteDataAdapter(sql_cmd);
                adapter.AcceptChangesDuringFill = false;
                adapter.Fill(DT);

                DT.TableName = "Content";
                foreach (DataRow row in DT.Rows)
                {
                    row.AcceptChanges();
                }

                return DT;
            }
            catch (Exception) { }
            return null;
        }
    }
}
