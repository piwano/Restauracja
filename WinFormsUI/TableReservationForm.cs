using System;
using System.Windows.Forms;

namespace WinFormsUI
{
    public partial class TableReservationForm : Form
    {
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private DateTimePicker reservationTimePicker;
        private NumericUpDown peopleCountUpDown;
        private Button reserveButton;
        private Button backButton;
        private Button menuButton;

        public TableReservationForm()
        {
            Text = "Rezerwacja stolika";
            Width = 400;
            Height = 520;
            StartPosition = FormStartPosition.CenterScreen;

            var firstNameLabel = new Label
            {
                Text = "Imię:",
                Top = 20,
                Left = 20,
                AutoSize = true
            };

            firstNameTextBox = new TextBox
            {
                Top = 40,
                Left = 20,
                Width = 300
            };

            var lastNameLabel = new Label
            {
                Text = "Nazwisko:",
                Top = 80,
                Left = 20,
                AutoSize = true
            };

            lastNameTextBox = new TextBox
            {
                Top = 100,
                Left = 20,
                Width = 300
            };

            var emailLabel = new Label
            {
                Text = "Adres e-mail:",
                Top = 140,
                Left = 20,
                AutoSize = true
            };

            emailTextBox = new TextBox
            {
                Top = 160,
                Left = 20,
                Width = 300
            };

            var phoneLabel = new Label
            {
                Text = "Numer telefonu:",
                Top = 200,
                Left = 20,
                AutoSize = true
            };

            phoneTextBox = new TextBox
            {
                Top = 220,
                Left = 20,
                Width = 300
            };

            var reservationTimeLabel = new Label
            {
                Text = "Godzina rezerwacji:",
                Top = 260,
                Left = 20,
                AutoSize = true
            };

            reservationTimePicker = new DateTimePicker
            {
                Top = 280,
                Left = 20,
                Width = 200,
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true,
                Value = DateTime.Today.AddHours(12)
            };

            var peopleCountLabel = new Label
            {
                Text = "Liczba osób:",
                Top = 320,
                Left = 20,
                AutoSize = true
            };

            peopleCountUpDown = new NumericUpDown
            {
                Top = 340,
                Left = 20,
                Width = 100,
                Minimum = 2,
                Maximum = 10,
                Value = 2
            };

            reserveButton = new Button
            {
                Text = "Zarezerwuj",
                Top = 380,
                Left = 20,
                Width = 100
            };
            reserveButton.Click += ReserveButton_Click;

            backButton = new Button
            {
                Text = "Wróć",
                Top = 380,
                Left = 140,
                Width = 100
            };
            backButton.Click += (s, e) => this.Close();

            menuButton = new Button
            {
                Text = "Menu",
                Top = 380,
                Left = 260,
                Width = 100
            };
            menuButton.Click += MenuButton_Click;

            Controls.AddRange(new Control[]
            {
                firstNameLabel, firstNameTextBox,
                lastNameLabel, lastNameTextBox,
                emailLabel, emailTextBox,
                phoneLabel, phoneTextBox,
                reservationTimeLabel, reservationTimePicker,
                peopleCountLabel, peopleCountUpDown,
                reserveButton, backButton, menuButton
            });
        }

        private void ReserveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folderPath = @"C:\temp\Rezerwacje";

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"Rezerwacja_{timestamp}.txt";
            string filePath = System.IO.Path.Combine(folderPath, fileName);

            string reservationData =
                $"Imię: {firstNameTextBox.Text}\n" +
                $"Nazwisko: {lastNameTextBox.Text}\n" +
                $"Email: {emailTextBox.Text}\n" +
                $"Telefon: {phoneTextBox.Text}\n" +
                $"Godzina: {reservationTimePicker.Value:HH:mm}\n" +
                $"Liczba osób: {peopleCountUpDown.Value}\n" +
                $"Data rezerwacji: {DateTime.Now}\n" +
                "--------------------------\n";

            try
            {
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                System.IO.File.WriteAllText(filePath, reservationData);

                string message =
                    $"Rezerwacja została przyjęta!\n\n" +
                    reservationData;

                MessageBox.Show(message, "Potwierdzenie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu rezerwacji: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            using var menuDialog = new MenuDialog();
            menuDialog.ShowDialog();
        }
    }
}
