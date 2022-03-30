using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steam_DLC_Tool
{
    public partial class Form2 : Form
    {
        string chooseGame;
        public string gameFolderPath;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox1.Items[0];
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chooseGame = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            gameFolderPath = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (chooseGame)
            {
                case "Cities: Skylines":
                    if (gameFolderPath.Contains("Cities_Skylines"))
                    {
                        label3.Text = "当前状态：执行中";
                        try
                        {
                            string fromUrl = "https://file1.fogmoe.top/SteamDLCTool/FogMoe-Cities_Skylines.zip";
                            CrackgameDLC.ModifyFileName(gameFolderPath, "steam_api64.dll", "steam_api64_o.dll",gameFolderPath);
                            CrackgameDLC.DownloadFile(fromUrl, gameFolderPath);
                            CrackgameDLC.Unzip(gameFolderPath);
                            CrackgameDLC.DeleteFile(gameFolderPath + "\\FogMoe-TempData.zip");
                            label3.Text = "当前状态：执行完成";
                            MessageBox.Show("DLC解锁完成！");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("错误: 解锁未完成！");
                            label3.Text = "当前状态：执行失败";
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择正确的游戏文件夹！");
                    }
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://file1.fogmoe.top/SteamDLCTool/FogMoe-EA-DLC-Unlocker-v2.zip");
        }
    }
}
