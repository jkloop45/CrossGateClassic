using System;
using System.Windows.Forms;
using CrossGateClassic.Models;
namespace CrossGateClassic
{
    public partial class Form1 : Form
    {
        Game game;
        string[] hwnds;
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("尚未绑定游戏!");
                return;
            }
            if (checkBox1.Checked)
            {
                game.SpeedFightOn();
            }
            else
            {
                game.SpeedFightOff();
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (game == null)
            {
                MessageBox.Show("尚未绑定游戏!");
                return;
            }
            if (checkBox2.Checked)
            {
                game.EnemyEveryStepOn();
            }
            else
            {
                game.EnemyEveryStepOff();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshGameWindows();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshGameWindows();
        }


        
        private void RefreshGameWindows()
        {
            listBox1.Items.Clear();
            string gameWindows=Dm.instance.EnumWindow(0,"","魔力宝贝",1+2);
            if (gameWindows == "")
            {
                MessageBox.Show("未找到游戏窗口!");
                return;
            }
            hwnds= gameWindows.Split(',');
            foreach(string hwnd in hwnds)
            {
                Dm.instance.SetWindowText(Convert.ToInt32(hwnd),hwnd.ToString());
            }
            hwnds = gameWindows.Split(',');
            listBox1.Items.AddRange(hwnds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem == null) { MessageBox.Show("没有选择一个窗口");return; }
                int hwnd = Convert.ToInt32(listBox1.SelectedItem.ToString());
                if(Dm.instance.ReadInt(hwnd,"00564bde",0)!=1681401343) { MessageBox.Show("发生了点什么"); }
                game = new Game(hwnd);
                MessageBox.Show("绑定成功.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("绑定失败,错误信息:"+ex.Message);
                return;
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("尚未绑定游戏!");
                return;
            }
            label1.Text = "采集间隔(毫秒):" + trackBar1.Value.ToString();
            game.SetCollectSpeed(trackBar1.Value);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("尚未绑定游戏!");
                return;
            }
            game.FoodInCombatOn();
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("尚未绑定游戏!");
                return;
            }
            label2.Text = "移动速度:"+trackBar2.Value.ToString();
            game.MoveSpeed = trackBar2.Value;
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (game == null)
            {
                MessageBox.Show("尚未绑定游戏!");
                return;
            }
            if (checkBox3.Checked)
            {
                game.FoodInCombatOn();
            }
            else
            {
                game.FoodInCombatOff();
            }
        }
    }
}
