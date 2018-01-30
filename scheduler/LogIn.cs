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
using scheduler.Extensions;

namespace scheduler
{
    public partial class LogIn : Form
    {
        public bool IsAuthorised = false;
        public ShedulerContext context;
        public LogIn()
        {
            InitializeComponent();
           context = new ShedulerContext();

            var users = context.Users.ToList();

            User initial = context.Users.FirstOrDefault(x => x.Password == "23");
            if (initial == null)
            {
                context.CreateDB();
            }

        }



        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            Scheduler mainForm = new Scheduler(context);
            mainForm.Show();

            //if (inputPassword.Text == "" || inputName.Text == "")
            //{
            //    MessageBox.Show("Поля повинні бути заповнені!!!");
            //    return;
            //}

            //this.IsAuthorised = CheckIfUserExist(inputName.Text, inputPassword.Text);

            //if (!IsAuthorised)
            //{
            //    MessageBox.Show("Введено невірні дані!!!");
            //}
            //else
            //{
            //    this.Hide();

            //    Scheduler mainForm = new Scheduler(context);
            //    mainForm.Show();

            //}
        }


        public bool CheckIfUserExist(string name, string password)
        {
            using (ShedulerContext db = new ShedulerContext())
            {
                List<User> user = db.Users.Where(x => x.Name.ToUpper() == name.ToUpper()).ToList();
                List<User> userPerPassword = user.Where(z => z.Password == password).ToList();

                if (userPerPassword.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
    }
}
