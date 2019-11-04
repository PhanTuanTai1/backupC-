﻿using _24102019_uwp.Business;
using _24102019_uwp.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.System;
using System.Text.RegularExpressions;
using _24102019_uwp.Data;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerPage : Page
    {
        ObservableCollection<Customer> lstCustomer;
        bool add, modify;
        const int preID = 160;
        int index;
        CustomerBS controller;
        public CustomerPage()
        {
            this.InitializeComponent();
            SetStatusTextBox(false);
            controller = new CustomerBS();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Customer c = CreateObject();
            if (add == true && controller.AddCustomer(c))
            {
                lstCustomer.Add(c);
                SetStatusTextBox(false);
                add = false;
                BtnModify.IsEnabled = true;
                BtnAdd.IsEnabled = true;
                BtnDelete.IsEnabled = true;
                ClearText();
                DisplayDialog("Add");
                return;
            }
            if (modify == true && controller.ModifyCustomer(c))
            {
                Customer modifyOBJ = new Customer()
                {
                    CusID = c.CusID,
                    Name = c.Name,
                    Phone = c.Phone,
                    Address = c.Address,
                };
                lstCustomer.RemoveAt(index);
                lstCustomer.Insert(index, modifyOBJ);
                SetStatusTextBox(false);
                modify = false;
                BtnModify.IsEnabled = true;
                BtnAdd.IsEnabled = true;
                BtnDelete.IsEnabled = true;
                DisplayDialog("Modify");
                ClearText();
            }
        }
        private void lvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Display();
        }
        private void Display()
        {
            Customer c = (Customer)lvCustomer.SelectedItem;
            if (c != null)
            {
                Id.Text = c.CusID.ToString();
                Name.Text = c.Name;
                Phone.Text = c.Phone;
                Address.Text = c.Address;
                index = lstCustomer.IndexOf(c);
            }
        }


        private void UpdateList()
        {
            lstCustomer = new ObservableCollection<Customer>();
            foreach (var i in controller.GetCustomers().Where(x => x.Deleted == false))
            {
                lstCustomer.Add(i);
            }
            lvCustomer.ItemsSource = lstCustomer;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            ClearText();
            SetStatusTextBox(true);
            RandomID();
            (sender as Button).IsEnabled = false;
            BtnModify.IsEnabled = false;
            BtnDelete.IsEnabled = false;
            add = true;
        }
        private void Modify(object sender, RoutedEventArgs e)
        {
            SetStatusTextBox(true);
            (sender as Button).IsEnabled = false;
            BtnAdd.IsEnabled = false;
            BtnDelete.IsEnabled = false;
            modify = true;
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            ContentDialog cd = new ContentDialog();
            cd.Content = "Are you sure you want to delete this customer ?";
            cd.Title = "Delete Customer";
            cd.PrimaryButtonText = "Yes";
            cd.PrimaryButtonClick += Cd_PrimaryButtonClick;
            cd.SecondaryButtonText = "No";
            cd.ShowAsync();
        }

        private void Cd_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //CustomerBS controller = new CustomerBS();
            ContentDialog cd = new ContentDialog();
            Customer c = (Customer)lvCustomer.SelectedItem;
            if (controller.RemoveCustomer(c.CusID))
            {
                lstCustomer.Remove(c);
                cd.Content = "Successfully deleted customer";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
                (sender as ContentDialog).Hide();
                cd.ShowAsync();
                return;
            }
            else
            {
                cd.Content = "Delete customer failed";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
                cd.ShowAsync();
            }
        }

        private Customer CreateObject()
        {
            Customer c = new Customer()
            {
                CusID = int.Parse(Id.Text),
                Name = Name.Text,
                Phone = Phone.Text,
                Address = Address.Text
            };
            return c;
        }
        private void RandomID()
        {
            //CustomerBS controller = new CustomerBS();
            while (true)
            {
                var now = DateTime.Now;
                var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
                int uniqueId = (int)(zeroDate.Ticks / 10000000);
                if (controller.CheckIDExists(int.Parse(preID.ToString() + uniqueId.ToString())) == false)
                {
                    Id.Text = preID.ToString() + uniqueId.ToString();
                    break;
                }
            }
        }

        private void SetStatusTextBox(bool e)
        {
            Name.IsEnabled = e;
            Phone.IsEnabled = e;
            Address.IsEnabled = e;
            BtnSave.IsEnabled = e;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void ClearText()
        {
            Name.Text = "";
            Phone.Text = "";
            Address.Text = "";
            Id.Text = "";
        }
        private bool isNumber(string key)
        {
            if (Regex.IsMatch(key, @"^\d+$")) return true;
            return false;
        }
        private void Autobox_PreviewKeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                if (isNumber(autobox.Text))
                {
                    lvCustomer.ItemsSource = lstCustomer.Where(x => x.CusID == int.Parse(autobox.Text));
                }
                else
                {
                    lvCustomer.ItemsSource = lstCustomer.Where(x => x.Name.Contains(autobox.Text));
                }
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void BtnRefresh_PreviewKeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.F5)
            {
                UpdateList();
            }
        }

        public void DisplayDialog(string type)
        {
            ContentDialog cd = new ContentDialog();
            if (type == "Add")
            {
                cd.Content = "Successfully added customer";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
            }
            else if (type == "Modify")
            {
                cd.Content = "Successfully modified customer";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
            }
            cd.ShowAsync();
        }
    }
}
