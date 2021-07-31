using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetAlert
{
    static class MainApp
    {
        public static MainForm m_main_frm;
                
        public static log4net.ILog logger;

        public static FreelancerHelper betfair_helper;
        public static String dbFile = "db.db";
        public static TimeSpan g_time_diff;
        public static SQLWrapper m_sql = new SQLWrapper();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Calculate the AU time
            var cst_tz = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            var local_tz = TimeZoneInfo.Local;
            var now = DateTimeOffset.UtcNow;
            TimeSpan cst_off = cst_tz.GetUtcOffset(now);
            TimeSpan local_off = local_tz.GetUtcOffset(now);
            g_time_diff = local_off - cst_off;

            if (!File.Exists(dbFile))
            {
                m_sql.CreateFile(dbFile);
                m_sql.CreatConnection("db.db");
                m_sql.Open();
                createTable();
            }
            else
            {
                m_sql.CreatConnection("db.db");
                m_sql.Open();
            }

            MainApp.log_info("Start...");            

            
            try
            {
                m_main_frm = new MainForm();
                Application.Run(m_main_frm);
            }
            catch (Exception){}
                        
        }        

        public static DateTime AuNow()
        {
            return DateTime.Now.Subtract(g_time_diff);
        }

        public static void createTable()
        {
            string _sql = "CREATE TABLE \"alerthistory\" (\"id\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                "\"bookmaker\"  TEXT,\"account_name\"  TEXT,\"time\"  TEXT,\"result\"  TEXT)";

            m_sql.ExecuteNonQuery(_sql);

            _sql = "CREATE TABLE \"account_info\" (\"id\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                "\"bookmaker\"  TEXT,\"account_name\"  TEXT,\"account_password\"  TEXT,\"answer\"  TEXT)";
            
            m_sql.ExecuteNonQuery(_sql);

            _sql = "CREATE TABLE \"content\" (\"id\"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL," +
                "\"title\"  TEXT,\"content\"  TEXT,\"flag\"  TEXT)";

            m_sql.ExecuteNonQuery(_sql);
        }

        public static void log_info(string msg, bool msgbox = false)
        {
            try
            {
                logger.Info(msg);
                if (msgbox)
                    MessageBox.Show(msg);
                if (msgbox)
                    m_main_frm.setLog(msg);
            }
            catch (Exception){}
        }
        
        public static void log_error(string msg, bool msgbox = false)
        {
            try
            {
                logger.Error(msg);
                if (msgbox)
                    MessageBox.Show(msg);
            }
            catch (Exception){}
        }
        
    }
}
