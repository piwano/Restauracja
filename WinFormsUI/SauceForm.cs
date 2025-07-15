using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsUI
{
    public class SauceForm : Form
    {
        public string SelectedSauce { get; private set; }

        public SauceForm()
        {
            Text = "Wybierz sos";
            Width = 400;
            Height = 250;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label label = new Label
            {
                Text = "Wybierz sos do pizzy:",
                Top = 20,
                Left = 20,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true
            };
            Controls.Add(label);

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Top = 60,
                Left = 20,
                Width = 400,
                Height = 130,
                AutoScroll = false
            };

            panel.Controls.Add(CreateSauceButton("Czosnkowy", "🧄"));
            panel.Controls.Add(CreateSauceButton("Barbecue", "🔥"));
            panel.Controls.Add(CreateSauceButton("Pomidorowy", "🍅"));

            Controls.Add(panel);
        }

        private Button CreateSauceButton(string name, string emoji)
        {
            Button button = new Button
            {
                Text = $"{emoji} {name}",
                Width = 100,
                Height = 40,
                Margin = new Padding(10),
                Font = new Font("Arial", 10, FontStyle.Regular),
                Tag = name
            };

            button.Click += (s, e) =>
            {
                SelectedSauce = ((Button)s).Tag.ToString();
                DialogResult = DialogResult.OK;
                Close();
            };

            return button;
        }
    }
}
