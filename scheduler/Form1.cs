using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scheduler
{
    public partial class Scheduler : Form
    {
        public Scheduler()
        {
            InitializeComponent();
        }

        private void button38_Click(object sender, EventArgs e)
        {

        }

        private void Scheduler_Resize(object sender, EventArgs e)
        {
            this.dataGridView1.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView2.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView3.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView4.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView5.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView6.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView7.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView8.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView9.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView10.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView11.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView12.Width = (sender as Scheduler).ClientSize.Width;
            this.dataGridView13.Width = (sender as Scheduler).ClientSize.Width;
            this.tabControl1.Width = (sender as Scheduler).ClientSize.Width;
            this.tabControl2.Width = (sender as Scheduler).ClientSize.Width;
            this.tabControl3.Width = (sender as Scheduler).ClientSize.Width;
            this.ControlLists.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox1.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox2.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox3.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox4.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox5.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox6.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox7.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox8.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox9.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox10.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox11.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox12.Width = (sender as Scheduler).ClientSize.Width;
            this.groupBox13.Width = (sender as Scheduler).ClientSize.Width;
        }
    }
}
