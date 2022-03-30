using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_DLC_Tool
{
    public partial class Form1 : Form
    {
        string dataToday = DateTime.Now.ToString("yyyy-MM-dd");
        public Form1()
        {
            InitializeComponent();            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://fog.moe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //格式是 FOGMOE-2022-03-27-Sawe25asg@             
            string keyPrefix = "FOGMOE-" + dataToday + "-";
            string inputKey = keyPrefix + textBox1.Text;
            string verifyKey = TheKey.EncodeBase64(inputKey);
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["verifyKey"] = verifyKey;
                var response = client.UploadValues("http://verify.fogmoe.top/verifyKey.php", values);
                var responseString = Encoding.Default.GetString(response);
                if (responseString == "True")
                {
                    MessageBox.Show("验证成功！");
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Visible = false;
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入密钥。");
                }
                else
                {
                    MessageBox.Show("密钥不正确。");
                }
            }           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ping baidu
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply pingReply = ping.Send("baidu.com");
                if (pingReply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    //success
                }
                else
                {
                    MessageBox.Show("网络连接失败，请检查网络连接！");
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接失败，请检查网络连接！");
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string thisVersion = label3.Text;
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["verifyVer"] = thisVersion;
                var response = client.UploadValues("http://verify.fogmoe.top/verifyVer.php", values);
                var responseString = Encoding.Default.GetString(response);
                if (responseString == "False")
                {
                    Visible = false;
                    MessageBox.Show("当前" + thisVersion + "不是最新版本，请下载最新版本使用。");
                    System.Diagnostics.Process.Start("https://fog.moe");
                    Close();
                }

            }
        }
    }
}
