using scheduler.Models;
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
        ShedulerContext context;
        List<int> indexesOfChangedRows;

        public Scheduler(ShedulerContext _context)
        {
            context = _context;
            InitializeComponent();
            indexesOfChangedRows = new List<int>();

            var kafedras = context.Kafedras.ToList();
            foreach (Kafedra k in kafedras)
            {
                kafedrasGridView1.Rows.Add(new object[] { k.FullName, k.ShortName });
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

        private void ControlLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            var grids = GetAll(this.tabControl1, typeof(DataGridView));
            foreach (DataGridView c in grids)
            {
                c.Rows.Clear();
            }


            //kafedras
            switch((sender as TabControl).SelectedIndex)
            {
                case 0: {
                        var kafedras = context.Kafedras.ToList();
                        foreach (Kafedra k in kafedras)
                        {
                            kafedrasGridView1.Rows.Add(new object[] { k.FullName, k.ShortName });
                        }
                        break;
                    }
                case 1: {
                        var specialty = context.Specialties.ToList();
                        foreach (Specialty s in specialty)
                        {
                            specialtyGridView2.Rows.Add(new object[] { s.FullName, s.ShortName });
                        }
                        break;
                    }
                case 2:
                    {
                        var groups = context.Groups.ToList();
                        foreach (Group g in groups)
                        {
                            string vacations = ",";
                            foreach (Vacation v in g.Vacations) {
                                vacations += v.Day + " ";
                            }
                            
                            groupsGridView3.Rows.Add(new object[] { g.Name,g.Specialty.FullName,g.StudentsCount,vacations });
                        }
                        break;
                    }
                case 3:
                    {
                        var subjects = context.Subjects.ToList();
                        foreach (Subject g in subjects)
                        {                           

                            subjectsGridView4.Rows.Add(new object[] { g.FullName, g.ShortName, g.Period });
                        }
                        break;
                    }

                case 4:
                    {
                        var auditories = context.Audiences.ToList();
                        foreach (Audience a in auditories)
                        {                             
                            audienceGridView5.Rows.Add(new object[] {a.Name,a.kafedra.FullName,a.CountOfPlaces,context.Сorpses.FirstOrDefault(x=>x.Id == a.СorpsId).Name});
                        }
                        break;
                    }

                case 5:
                    {
                        var lectors = context.Lektors.ToList();
                        foreach (Lektor a in lectors)
                        {
                            string metoddni = ",";
                            string windows = ",";
                            string vacations = ",";
                            foreach (MetodDni v in a.MetodDni)
                            {
                                metoddni += v.Day + " ";
                            }
                            foreach (Window v in a.Windows)
                            {
                                windows += v.Value + " ";
                            }
                            foreach (Vacation v in a.Vacations)
                            {
                                vacations += v.Day + " ";
                            }
                            lectorsGridView6.Rows.Add(new object[] { a.Name, a.Primitka, a.Kafedra.FullName, metoddni,windows,vacations });
                        }
                        break;
                    }

                case 6:
                    {
                        var subtypes = context.SubjectTypes.ToList();
                        foreach (SubjectType a in subtypes)
                        {

                            subjectTypesGridView7.Rows.Add(new object[] { a.FullName,a.ShortName });
                        }
                        break;
                    }

            }
        }

        private void kafedrasGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            InsertChangedRow(e.RowIndex);
        }

        private void InsertChangedRow(int index)
        {
            this.indexesOfChangedRows.Add(index);
        }

        private void kafedraAddbutton1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in kafedrasGridView1.Rows)
            {

                foreach (int changedIndex in indexesOfChangedRows)
                {
                    if (row.Index == changedIndex)
                    {

                        context.Kafedras.Add(new Kafedra { FullName = row.Cells[0].Value.ToString(), ShortName = row.Cells[1].Value.ToString() });


                    }
                }
                context.SaveChanges();
                ClearIndexes();

            }
        }

        private void ClearIndexes() {
            this.indexesOfChangedRows = new List<int>();
        }
    }
}
