using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace net.nutcore.aliddns
{
    public partial class Form_ngrok : Form
    {
        public Form_ngrok()
        {
            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
