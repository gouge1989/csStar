using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;

namespace csStar
{
    public partial class Form1 : Form
    {
        string mainPath;
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AppConfig.SetValue("defPath","D:\\WolServer");
            update();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = mainPath + @"\GameCenter.exe";
            start(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start(mainPath);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            start(@"D:\传世元神");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            start(@"E:\传奇世界");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            start("E:\\传奇世界Ⅱ");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            start("E:\\传奇世界急速\\传奇世界");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            start("D:\\传世元神\\彩虹引擎说明书 v2022-11-22.chm");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            start("D:\\传世元神\\传世外观集合 v2022-11-10.chm");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\QuestDiary");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\Robot_def");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\Market_def\QFunction-0.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\Market_def");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\MapQuest_def\QManage.txt");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\MapInfo.txt");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\MonGen.txt");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            start(mainPath + @"\Mir200\Envir\MerChant.txt");
        }
        private void start(string path)
        {
            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("文件/文件夹不存在!请检查目录设置!");
            }

            
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))

            {

                e.Effect = DragDropEffects.All;

            }
        }
        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();     //获取文件路径
            AppConfig.SetValue(path, path);
            AppConfig.SetValue("defPath", path);
            update();

        }
        private void update()
        {
            //更新下拉列表框
            //更新主路径
            mainPath = AppConfig.GetValue("defPath");
          //  Console.WriteLine("mainpath:"+mainPath);
            //更新标签1内容
            label1.Text = mainPath;
            updateCombobox();
        }

        //读取配置项更新下拉列表框
        private void updateCombobox()
        {
            //遍历配置项
            foreach (string text in ConfigurationManager.AppSettings.AllKeys)
            {
                //添加至下拉列表框
                if (text.Equals("defPath")) continue;
                comboBox1.Items.Add(AppConfig.GetValue(text));
              //  Console.WriteLine(text+" "+AppConfig.GetValue(text));

            }
            //更新下拉列表框文本
            comboBox1.Text = mainPath;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            mainPath = comboBox1.Text;
            label1.Text = mainPath;
            AppConfig.SetValue("defpath", mainPath);
         //   Console.WriteLine("combox_2");
        }

    }
}
