using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.Models;

namespace WinFormsUI
{
    public partial class PizzaForm : Form
    {
        private ComboBox pizzaComboBox;
        private CheckedListBox toppingsList;
        private Button okButton;

        public Food SelectedPizza { get; private set; }

        private List<Food> pizzaTemplates = new()
        {
            new Food { Name = "Margherita", BasePrice = 20m, IsVegetarian = true },
            new Food { Name = "Pepperoni", BasePrice = 25m, IsVegetarian = false },
            new Food { Name = "Capricciosa", BasePrice = 26m, IsVegetarian = false },
            new Food { Name = "Funghi", BasePrice = 22m, IsVegetarian = true },
        };

        private List<Topping> allToppings = new()
        {
            new Topping("Szynka", 3.0m),
            new Topping("Pieczarki", 2.0m),
            new Topping("Ser dodatkowy", 2.5m),
            new Topping("Oliwki", 1.5m),
            new Topping("Bekon", 3.5m),
            new Topping("Cebula", 1.0m)
        };

        public PizzaForm()
        {
            Width = 350;
            Height = 350;
            Text = "Wybierz pizzę";

            pizzaComboBox = new ComboBox { Top = 20, Left = 20, Width = 280 };
            pizzaComboBox.DataSource = pizzaTemplates;
            pizzaComboBox.DisplayMember = "Name";

            toppingsList = new CheckedListBox { Top = 60, Left = 20, Width = 280, Height = 180 };
            foreach (var topping in allToppings)
            {
                toppingsList.Items.Add(topping);
            }

            okButton = new Button { Text = "OK", Top = 260, Left = 20, Width = 280 };
            okButton.Click += OkButton_Click;

            Controls.Add(pizzaComboBox);
            Controls.Add(toppingsList);
            Controls.Add(okButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (pizzaComboBox.SelectedItem is Food basePizza)
            {
                var selectedToppings = toppingsList.CheckedItems
                    .OfType<Topping>()
                    .ToList();

                SelectedPizza = new Food
                {
                    Id = new Random().Next(1, 1000),
                    Name = basePizza.Name,
                    BasePrice = basePizza.BasePrice,
                    IsVegetarian = basePizza.IsVegetarian,
                    Toppings = selectedToppings
                };

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}