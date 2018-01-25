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

       

        private void PrintRecursive(Control control, int width)
        {
            foreach (Control c in control.Controls)
            {
                if (c.GetType() == typeof(TabPage) || c.GetType() == typeof(DataGridView) )
                {
                    c.Width = width;
                    PrintRecursive(c, width);

                }

            }
        }

        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }


        private void Scheduler_Resize(object sender, EventArgs e)
        {
            if (sender == null) return;
            var width = Screen.PrimaryScreen.WorkingArea.Width;

            this.tabControl1.Width = width;
                     
            var controls = GetAll(this.tabControl1, typeof(TabControl));

            foreach (Control c in controls)
            {
                c.Width = width;
            }
            var grids = GetAll(this.tabControl1, typeof(DataGridView));
            foreach (Control c in grids)
            {
                c.Width = width;
            }

            var groupBox = GetAll(this.tabControl1, typeof(GroupBox));
            foreach (Control c in groupBox)
            {
                c.Width = width;
            }

            
        }
    }
}
