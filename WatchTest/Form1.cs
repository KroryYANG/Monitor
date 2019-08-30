using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using WatchTest.Model;
using WatchTest.DAL;
using System.IO;
using System.Timers;

namespace WatchTest
{
    public partial class Form1 : Form
    {
        Configuration config = null;
        String exString1 = null;
        String exString2 = null;
        String exString3 = null;
        String exString = null;

        public Form1()
        {
            InitializeComponent();            
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            this.fileSystemWatcher1.Path = this.textBox1.Text;     //监测文件夹
            config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);   
            exString1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
            exString2 = "D:/WatchTest/混砂数据.xls";
            exString3 = "; Extended Properties=Excel 8.0";

        }

        //private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        //{
        //    if (e.Name.IndexOf(".xls") == -1 || e.Name.Length != 8)
        //        return;
        //    exString = exString1 + e.FullPath + exString3;
        //    OleDbConnection objConn = new OleDbConnection(exString);
        //    objConn.Open();
        //    string sql = "select * from [Roto$]";
        //    OleDbDataAdapter da = new OleDbDataAdapter(sql, objConn); //创建适配对象
        //    DataTable dt = new DataTable(); //新建表对象
        //    da.Fill(dt); //用适配对象填充表对象   
        //    updateSQL(dt);  //写入SQL
        
        //}


        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            if (e.Name.IndexOf(".xls") == -1 || e.Name.Length != 8) //要添加.xls文件，文件名长度为4（不计格式）
                return;
            exString = exString1 + e.FullPath + exString3;  //生成连接字符串
            OleDbConnection objConn = new OleDbConnection(exString);    //新建连接
            objConn.Open();
            string sql = "select * from [Roto$]";
            OleDbDataAdapter da = new OleDbDataAdapter(sql, objConn); //创建适配对象
            DataTable dt = new DataTable(); //新建表对象
            da.Fill(dt); //用适配对象填充表对象
            updateSQL(dt);  //写入SQL
        }

        //写入SQL
        private void updateSQL(DataTable dt)
        {
            int rowsCount = dt.Rows.Count;
            SandMix sandMix = new SandMix();
            SandMixSupp sandMixSupp = new SandMixSupp();
            sandMixSupp.SandMixSID = SandMixDAL.GetSandMixSID();
            int result = 0;
            int success = 0;

            for (int i = 0; i < rowsCount; i++)
            {

                sandMixSupp.Time = DateTime.Today; //时间
                sandMixSupp.Batch = Convert.ToInt32(dt.Rows[i]["N°Cycle"].ToString()); //批次
                sandMixSupp.SetCompactability = Convert.ToDouble(dt.Rows[i]["ASVisée"].ToString().Replace(',', '.')); //设定紧实率
                sandMixSupp.SandTem = Convert.ToDouble(dt.Rows[i]["°CSable"].ToString().Replace(',', '.')); //旧沙温度
                sandMixSupp.MSetCompactability = Convert.ToDouble(dt.Rows[i]["ASCorr"].ToString().Replace(',', '.')); //补偿紧实率
                sandMixSupp.FirstWater = Convert.ToInt32(dt.Rows[i]["EauReg"].ToString());    //第一次加水量
                sandMixSupp.Bias = Convert.ToDouble(dt.Rows[i]["Ecart"].ToString().Replace(',', '.')); //偏差（有正负）
                sandMixSupp.TotalWater = Convert.ToInt32(dt.Rows[i]["EauTotal"].ToString());    //总加水量
                sandMixSupp.CircleTime = Convert.ToInt32(dt.Rows[i]["TpsCycle"].ToString());    //循环时间
                sandMixSupp.SetStrength = Convert.ToInt32(dt.Rows[i]["RCVisée"].ToString());     //强度设定值
                sandMixSupp.RealStrength = Convert.ToInt32(dt.Rows[i]["ValRC"].ToString());       //实际强度值
                sandMixSupp.Bentonite = Convert.ToDouble(dt.Rows[i]["Additif1"].ToString().Replace(',', '.')); //膨润土量
                sandMixSupp.Additive = Convert.ToDouble(dt.Rows[i]["Additif2"].ToString().Replace(',', '.')); //综合添加剂
                sandMixSupp.Support1 = Convert.ToDouble(dt.Rows[i]["Additif3"].ToString().Replace(',', '.')); //其他辅料1
                sandMixSupp.Support2 = Convert.ToDouble(dt.Rows[i]["Additif3"].ToString().Replace(',', '.')); //其他辅料2
                sandMixSupp.SandWeight = Convert.ToInt32(dt.Rows[i]["PoidsVS"].ToString());       //旧沙重量
                sandMixSupp.RealCompactability = Convert.ToDouble(dt.Rows[i]["ValASFin"].ToString().Replace(',', '.'));       //实际紧实率
                    
                try
                {
                    result = 0;
                    result = SandMixSuppDAL.AddSandMixSupp(sandMixSupp);
                    if (result == 1)
                    {
                        success++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
               
            }
            MessageBox.Show("成功数"+success);

        }

        //更改监视路径
        private void button1_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入文件夹路径", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!System.IO.Directory.Exists(this.textBox1.Text))
            {
                MessageBox.Show("选择的不是一个文件夹", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.fileSystemWatcher1.Path = this.textBox1.Text;     //监测文件夹更改
            MessageBox.Show("目录更改完成");
        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("监视的文件名长度为4，以.xls结尾","说明");
        }
    }
}
