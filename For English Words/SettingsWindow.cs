using System;
using System.Drawing;
using System.Windows.Forms;

namespace For_English_Words
{
    public partial class SettingsWindow : Form
    {
        Size screenSize = Screen.PrimaryScreen.Bounds.Size;
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            Size = new Size(966, 410);
            panel1.Size = new Size(771, 361);
            panel1.Location = new Point(196, 50);
            Location = new Point((screenSize.Width/2)-(Size.Width/2),
                (screenSize.Height/2)-(Size.Height/2));
            panel4.Visible = false;
        }

        private void HideColorPanel()
        {
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(390, 0);
            panel3.Visible = false;
            panel2.Visible = true;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Location = new Point(390, 0);
            panel3.Visible = true;
        }
        //----------------------------------------------------------------------------------
        // Black
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            HideColorPanel();
        }
        // White
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Blue
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Brown
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        //Gray
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Green
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Light Blue
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Light Green
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Orange
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Pink
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Red
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        // Yellow
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            HideColorPanel();
        }
        //------------------------------------------------------------------
        // Black
        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }
        // White
        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }
        // Blue
        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }
        // Brown
        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }
        // Gray
        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }
        // Green
        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }
        // Light Blue
        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }
        // Light Green
        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }
        // Orange
        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }
        // Pink
        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }
        // Red
        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }
        // Yellow
        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Записуємо вибрану ноду у змінну
            TreeNode tNode1 = treeView1.SelectedNode;
            // пошук підходящої ноди по системному імені
            switch (tNode1.Name)
            {
                case "FontMain":
                    break;

                case "ColorMain":
                    break;

                case "BackColorMain":
                    break;

                case "TextColorMain":
                    break;

                case "FontAdd":
                    break;

                case "ColorAdd":
                    break;

                case "BackColorAdd":
                    break;

                case "TextColorAdd":
                    break;

                case "FontSettings":
                    break;

                case "ColorSettings":
                    break;

                case "BackColorSettings":
                    break;

                case "TextColorSettings":
                    break;

                case "HotKeys1":
                    break;
            }
        }
    }
}
