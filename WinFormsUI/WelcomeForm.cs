using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class WelcomeForm : Form
    {
        private Button Rezeracja;
        private Button Zamowienie;

        public WelcomeForm()
        {
            Text = "Witamy";
            Width = 400;
            Height = 500;
            StartPosition = FormStartPosition.CenterScreen;

            var pictureBox = new PictureBox
            {
                Image = Image.FromFile("pizza.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 350,
                Height = 200,
                Top = 20,
                Left = 20
            };

            var welcomeLabel = new Label
            {
                Text = "Witamy w restauracji!",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Top = 240,
                Left = 70
            };

            Rezeracja = new Button
            {
                Text = "Rezerwacja stolika",
                Top = 300,
                Left = 120,
                Width = 150
            };
            Rezeracja.Click += (s, e) =>
            {
                var tableReservationForm = new TableReservationForm();
                tableReservationForm.FormClosed += (sender, args) => this.Show();
                tableReservationForm.Show();
                this.Hide();
            };

            Zamowienie = new Button
            {
                Text = "Zamówienie",
                Top = 350,
                Left = 120,
                Width = 150
            };
            Zamowienie.Click += (s, e) =>
            {
                var mainForm = new MainForm(this);
                mainForm.Show();
                this.Hide();
            };

            Controls.Add(pictureBox);
            Controls.Add(welcomeLabel);
            Controls.Add(Rezeracja);
            Controls.Add(Zamowienie);
        }
    }
}
