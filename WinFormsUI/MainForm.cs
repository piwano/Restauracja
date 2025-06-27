using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core.Models;
using Infrastructure.Repositories;

namespace WinFormsUI
{
    public class MainForm : Form
    {
        private ListBox listBox;
        private Button addButton;
        private IRepository<Food> repository;

        public MainForm()
        {
            Text = "Restaurant Manager";
            Width = 400;
            Height = 300;

            listBox = new ListBox { Top = 10, Left = 10, Width = 360, Height = 200 };
            addButton = new Button { Text = "Dodaj Pizza", Top = 220, Left = 10 };

            addButton.Click += AddButton_Click;

            Controls.Add(listBox);
            Controls.Add(addButton);

            repository = new JsonRepository<Food>("foods.json");

            LoadData();
        }

        private void LoadData()
        {
            listBox.Items.Clear();
            foreach (var item in repository.GetAll())
            {
                listBox.Items.Add(item.GetDescription());
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newFood = new Food
            {
                Id = new Random().Next(1, 1000),
                Name = "Pizza",
                Price = 25.0m,
                IsVegetarian = false
            };

            repository.Add(newFood);
            repository.Save();
            LoadData();
        }
    }
}
