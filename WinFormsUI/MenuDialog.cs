using System;
using System.Linq;
using System.Windows.Forms;
using Core.Models;
using Infrastructure.Repositories;

namespace WinFormsUI
{
    public class MenuDialog : Form
    {
        private ListBox menuListBox;

        public MenuDialog()
        {
            Text = "Menu restauracji";
            Width = 400;
            Height = 500;
            StartPosition = FormStartPosition.CenterParent;

            menuListBox = new ListBox
            {
                Top = 10,
                Left = 10,
                Width = 360,
                Height = 420
            };

            Controls.Add(menuListBox);

            LoadMenu();
        }

        private void LoadMenu()
        {
            var foodRepo = new JsonRepository<Food>("foods.json");
            var drinkRepo = new JsonRepository<Drink>("drinks.json");

            var foods = foodRepo.GetAll().Select(f => "🍕 " + f.GetDescription());
            var drinks = drinkRepo.GetAll().Select(d => "🥤 " + d.GetDescription());

            menuListBox.Items.Add("== Pizza ==");
            foreach (var item in foods)
                menuListBox.Items.Add(item);

            menuListBox.Items.Add("");
            menuListBox.Items.Add("== Napoje ==");
            foreach (var item in drinks)
                menuListBox.Items.Add(item);
        }
    }
}
