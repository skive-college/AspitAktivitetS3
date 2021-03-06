﻿using AspitAktivitet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AspitAktivitet.Healpers;

namespace AspitAktivitet.GUI
{
    /// <summary>
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : UserControl
    {
        public AdminUsers()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            using (DB db = new DB())
            {
                lwUsers.DataContext = db.Users.ToList();
            }
        }
        private void CmdCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    using (DB db = new DB())
                    {
                        bool admin = false;
                        if (cbAdmin.IsChecked == true)
                        {
                            admin = true;
                        }
                        User u = new User() { Name = txtName.Text, Password = txtPassword.Text, Admin = admin };

                        db.Users.Add(u);
                        db.SaveChanges();
                        txtName.Text = "";
                        txtPassword.Text = "";
                        cbAdmin.IsChecked = false;
                    }
                    load();
                }
                catch (Exception)
                {
                    //giv Besked om fejl
                }
            }
        }

        private void CmdDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lwUsers.SelectedIndex != -1)
            {
                User u = lwUsers.SelectedItem as User;

                using (DB db = new DB())
                {
                    db.Users.Attach(u);
                    db.Users.Remove(u);
                    db.SaveChanges();
                }
                load();
            }
        }

        private void CmdEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lwUsers.SelectedIndex != -1)
            {
                User u = lwUsers.SelectedItem as User;

                using (DB db = new DB())
                {
                    db.Users.Attach(u);
                    txtName.Text = u.Name;
                    txtPassword.Text = u.Password;
                    cbAdmin.IsChecked = u.Admin;
                }
            }
            cmdUpdate.IsEnabled = true;
            cmdCreate.IsEnabled = false;
            cmdDelete.IsEnabled = false;
        }

        private void CmdUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lwUsers.SelectedIndex != -1)
            {
                User u = lwUsers.SelectedItem as User;

                using (DB db = new DB())
                {
                    db.Users.Attach(u);
                    u.Name = txtName.Text;
                    u.Password = txtPassword.Text;
                    bool admin = false;
                    if (cbAdmin.IsChecked == true)
                    {
                        admin = true;
                    }
                    u.Admin = admin;
                    db.SaveChanges();
                    txtName.Text = "";
                    txtPassword.Text = "";
                    cbAdmin.IsChecked = false;
                }
                load();
            }
            cmdUpdate.IsEnabled = false;
            cmdCreate.IsEnabled = true;
            cmdDelete.IsEnabled = true;
        }

        private void LwUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmdEdit.IsEnabled = true;
            cmdDelete.IsEnabled = true;
        }
    }
}
