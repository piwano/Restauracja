using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Core.Models;

namespace WinFormsUI
{
    public class MainForm : Form
    {
        private Label titleLabel;
        private ListBox listBox;
        private Button addFoodButton;
        private Button chooseSauceButton;
        private Button addDrinkButton;
        private ComboBox drinkComboBox;
        private Label totalLabel;
        private Button removeSelectedButton;
        private ComboBox filterComboBox;
        private Button orderButton;
        private Button backButton;

        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private RadioButton pickupRadioButton;
        private RadioButton deliveryRadioButton;
        private Label addressLabel;
        private TextBox addressTextBox;

        private List<Drink> availableDrinks = new List<Drink>();
        private Form previousForm;

        public MainForm(Form previousForm)
        {
            this.previousForm = previousForm;
            Text = "Restaurant Manager";
            Width = 800;
            Height = 950;
            StartPosition = FormStartPosition.CenterScreen;

            titleLabel = new Label
            {
                Text = "Twoje zamówienie",
                Top = 10,
                Left = 10,
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                AutoSize = true
            };

            listBox = new ListBox { Top = 40, Left = 10, Width = 760, Height = 300 };

            addFoodButton = new Button { Text = "Dodaj Pizza", Top = 360, Left = 10 };
            chooseSauceButton = new Button { Text = "Wybierz sos", Top = 360, Left = 120 };

            drinkComboBox = new ComboBox { Top = 400, Left = 10, Width = 200 };
            addDrinkButton = new Button { Text = "Dodaj", Top = 400, Left = 220 };

            removeSelectedButton = new Button
            {
                Text = "Usuń wybraną pozycję",
                Top = 440,
                Left = 10,
                Width = 200
            };

            totalLabel = new Label
            {
                Text = "Suma zamówienia: 0,00 zł",
                Top = 480,
                Left = 10,
                Width = 300,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };

            filterComboBox = new ComboBox { Top = 520, Left = 10, Width = 200 };
            filterComboBox.Items.AddRange(new[] { "Wszystko", "Pizze", "Napoje" });
            filterComboBox.SelectedIndex = 0;

            firstNameTextBox = new TextBox { PlaceholderText = "Imię", Top = 560, Left = 10, Width = 200 };
            lastNameTextBox = new TextBox { PlaceholderText = "Nazwisko", Top = 590, Left = 10, Width = 200 };
            emailTextBox = new TextBox { PlaceholderText = "Adres e-mail", Top = 620, Left = 10, Width = 200 };
            phoneTextBox = new TextBox { PlaceholderText = "Telefon", Top = 650, Left = 10, Width = 200 };

            phoneTextBox.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            orderButton = new Button { Text = "Zamów na wynos", Top = 690, Left = 10, Width = 200 };

            pickupRadioButton = new RadioButton { Text = "Odbiór osobisty", Top = 560, Left = 250, AutoSize = true };
            deliveryRadioButton = new RadioButton { Text = "Dowóz do domu", Top = 590, Left = 250, AutoSize = true };

            addressLabel = new Label
            {
                Text = "Adres dostawy:",
                Top = 620,
                Left = 250,
                AutoSize = true,
                Visible = false
            };
            addressTextBox = new TextBox
            {
                Top = 640,
                Left = 250,
                Width = 300,
                Visible = false
            };

            backButton = new Button { Text = "Wróć", Top = 725, Left = 10, Width = 100 };

            deliveryRadioButton.CheckedChanged += (s, e) =>
            {
                bool showAddress = deliveryRadioButton.Checked;
                addressLabel.Visible = showAddress;
                addressTextBox.Visible = showAddress;
            };

            addFoodButton.Click += AddFoodButton_Click;
            chooseSauceButton.Click += ChooseSauceButton_Click;
            addDrinkButton.Click += AddDrinkButton_Click;
            removeSelectedButton.Click += RemoveSelectedButton_Click;
            filterComboBox.SelectedIndexChanged += (s, e) => { };
            orderButton.Click += OrderButton_Click;
            backButton.Click += BackButton_Click;

            Controls.AddRange(new Control[]
            {
                titleLabel, listBox, addFoodButton, chooseSauceButton, drinkComboBox, addDrinkButton,
                removeSelectedButton, totalLabel, filterComboBox, firstNameTextBox, lastNameTextBox,
                emailTextBox, phoneTextBox, orderButton, pickupRadioButton, deliveryRadioButton,
                addressLabel, addressTextBox, backButton
            });

            LoadDrinks();
        }

        private void LoadDrinks()
        {
            availableDrinks = new List<Drink>
            {
                new Drink { Id = 1, Name = "Cola", IsAlcoholic = false, Price = 8.0m },
                new Drink { Id = 2, Name = "Piwo", IsAlcoholic = true, Price = 12.0m },
                new Drink { Id = 3, Name = "Woda", IsAlcoholic = false, Price = 5.0m }
            };

            drinkComboBox.DataSource = availableDrinks;
            drinkComboBox.DisplayMember = "Name";
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            using var pizzaForm = new PizzaForm();
            if (pizzaForm.ShowDialog() == DialogResult.OK)
            {
                var pizzaDescription = pizzaForm.SelectedPizza.GetDescription();
                listBox.Items.Add(pizzaDescription);
                UpdateTotal();
            }
        }

        private void ChooseSauceButton_Click(object sender, EventArgs e)
        {
            using var sauceForm = new SauceForm();
            if (sauceForm.ShowDialog() == DialogResult.OK)
            {
                listBox.Items.Add($"{sauceForm.SelectedSauce} - 2,00 zł");
                UpdateTotal();
            }
        }

        private void AddDrinkButton_Click(object sender, EventArgs e)
        {
            if (drinkComboBox.SelectedItem is Drink selectedDrink)
            {
                listBox.Items.Add($"{selectedDrink.Name} - {selectedDrink.Price.ToString("0.00", new CultureInfo("pl-PL"))} zł");
                UpdateTotal();
            }
        }

        private void RemoveSelectedButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                listBox.Items.Remove(listBox.SelectedItem);
                UpdateTotal();
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnej pozycji.", "Uwaga");
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (var item in listBox.Items)
            {
                string priceStr = ExtractPrice(item.ToString());
                if (decimal.TryParse(priceStr, NumberStyles.Number, new CultureInfo("pl-PL"), out decimal price))
                    total += price;
            }
            totalLabel.Text = $"Suma zamówienia: {total:0.00} zł";
        }

        private string ExtractPrice(string text)
        {
            var match = Regex.Match(text, @"(\d+[.,]\d{2})\s*(zł|PLN)?", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value : "0";
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            if (listBox.Items.Count == 0 || string.IsNullOrWhiteSpace(firstNameTextBox.Text)
                || string.IsNullOrWhiteSpace(lastNameTextBox.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text)
                || string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie dane i dodaj produkty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Wprowadź poprawny adres e-mail (musi zawierać '@').", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!pickupRadioButton.Checked && !deliveryRadioButton.Checked)
            {
                MessageBox.Show("Wybierz sposób odbioru.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (deliveryRadioButton.Checked && string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                MessageBox.Show("Podaj adres dostawy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = 0;
            foreach (var item in listBox.Items)
            {
                var priceStr = ExtractPrice(item.ToString());
                if (decimal.TryParse(priceStr, NumberStyles.Number, new CultureInfo("pl-PL"), out decimal price))
                    total += price;
            }

            int czas = new Random().Next(30, 91);
            string odbior = pickupRadioButton.Checked ? "Odbiór osobisty" : $"Dowóz do domu\nAdres: {addressTextBox.Text}";

            string orderSummary =
                $"Zamówienie złożone!\n\n" +
                $"Pozycji: {listBox.Items.Count}\n" +
                $"Suma: {total:0.00} zł\n\n" +
                $"Klient: {firstNameTextBox.Text} {lastNameTextBox.Text}\n" +
                $"Email: {emailTextBox.Text}\n" +
                $"Telefon: {phoneTextBox.Text}\n\n" +
                $"Sposób odbioru: {odbior}\n" +
                $"Czas oczekiwania: {czas} minut";

            SaveOrderToFile(orderSummary);

            MessageBox.Show(orderSummary, "Potwierdzenie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listBox.Items.Clear();
            UpdateTotal();

            firstNameTextBox.Text = lastNameTextBox.Text = emailTextBox.Text = phoneTextBox.Text = addressTextBox.Text = "";
            pickupRadioButton.Checked = deliveryRadioButton.Checked = false;
            addressLabel.Visible = addressTextBox.Visible = false;
        }

        private void SaveOrderToFile(string content)
        {
            try
            {
                // Ustawiona na folder C:\Temp\Zamowienia, zmień jeśli chcesz inną ścieżkę
                string folderPath = @"C:\Temp\Zamowienia";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = $"Zamowienie_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string filePath = Path.Combine(folderPath, fileName);

                File.WriteAllText(filePath, content);

                MessageBox.Show($"Zamówienie zapisane do pliku:\n{filePath}", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisu zamówienia: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }
    }
}
