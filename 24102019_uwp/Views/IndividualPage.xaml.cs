using _24102019_uwp.Business;
using _24102019_uwp.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IndividualPage : Page
    {
        ObservableCollection<customDisk> lsDisk;
        bool add, modify;
        const int preID = 160;
        int index;
        TitleBS TitleControler;
        DiskBS DiskControler;

        public IndividualPage()
        {
            this.InitializeComponent();
            TitleControler = new TitleBS();
            DiskControler = new DiskBS();
            lsDisk = new ObservableCollection<customDisk>(DiskControler.getDisks());
            lvDisk.ItemsSource = lsDisk;
            cbTitle.ItemsSource = TitleControler.getTitlesMain();
            cbTitle.DisplayMemberPath = "Name";
            SetStatusTextBox(false);

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < int.Parse(diskCount.Text); i++)
            {
                Disk d = CreateObject(i + "");
                DiskControler.AddDisk(d);
            }
            UpdateList();
            SetStatusTextBox(false);
            add = false;
            BtnAdd.IsEnabled = true;
            BtnDelete.IsEnabled = true;
            btnSave.IsEnabled = false;
            ClearText();
            DisplayDialog("Add");
            if (Regex.IsMatch(diskCount.Text, "/^[0-9]*$/"))
            {

            }
        }
        private void lvDisk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Display();
        }
        private void Display()
        {
            try
            {
                customDisk d = (customDisk)lvDisk.SelectedItem;
                userRent.Content = DiskControler.getUserRent(d.DiskID);
                dueDate.Text = DiskControler.getDueDate(d.DiskID);
                switch (d.ChkOutStatus)
                {
                    case (short)Checkout.DiskStatus.ONHOLD:
                        status.Text = "On Hold";
                        break;
                    case (short)Checkout.DiskStatus.RENTED:
                        status.Text = "Rented";
                        break;
                    case (short)Checkout.DiskStatus.SHELF:
                        status.Text = "One Shelf";
                        break;
                    default:
                        break;
                }
                
            }
            catch (Exception)
            {
                userRent.Content = "None";
                dueDate.Text = "None";
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList(((Title)cbTitle.SelectedItem).Name);
        }

        private void UpdateList(string name = null)
        {
            if (name == null)
            {
                lsDisk = new ObservableCollection<customDisk>(DiskControler.getDisks());
            }
            else
            {
                lsDisk = new ObservableCollection<customDisk>(DiskControler.getDisks().Where(n => n.TitleName == name).ToList());
            }
            lvDisk.ItemsSource = lsDisk;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            ClearText();
            SetStatusTextBox(true);
            RandomID();
            (sender as Button).IsEnabled = false;
            BtnDelete.IsEnabled = false;
            add = true;
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
            customDisk d = (customDisk)lvDisk.SelectedItem;
            if (DiskControler.RemoveDisk(d.DiskID))
            {
                lsDisk.Remove(lsDisk.Single(n => n.DiskID == d.DiskID));
                cd.Content = "Successfully deleted title";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
                (sender as ContentDialog).Hide();
                cd.ShowAsync();
                return;
            }
            else
            {
                cd.Content = "Delete title failed";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
                cd.ShowAsync();
            }
        }

        private Disk CreateObject(string t = null)
        {
            if (t == null)
            {
                return new Disk()
                {
                    ChkOutStatus = 0,
                    Deleted = false,
                    DiskID = RandomID(),
                    TitleID = ((Title)cbTitle.SelectedItem).TitleID
                };
            }
            else
            {
                return new Disk()
                {
                    ChkOutStatus = (short)Checkout.DiskStatus.SHELF,
                    Deleted = false,
                    DiskID = RandomID() + int.Parse(t),
                    TitleID = ((Title)cbTitle.SelectedItem).TitleID
                };
            }
        }
        private int RandomID()
        {
            //CustomerBS controller = new CustomerBS();
            while (true)
            {
                var now = DateTime.Now;
                var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
                int uniqueId = (int)(zeroDate.Ticks / 10000000);
                return uniqueId;
            }
        }

        private void SetStatusTextBox(bool e)
        {
            diskCount.IsEnabled = e;
            btnSave.IsEnabled = e;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void ClearText()
        {
            diskCount.Text = "";
        }
        private bool isNumber(string key)
        {
            if (Regex.IsMatch(key, @"^\d+$"))
            {
                return true;
            }

            return false;
        }
        private void Autobox_PreviewKeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                if (isNumber(autobox.Text))
                {
                    lvDisk.ItemsSource = lsDisk.Where(x => x.DiskID.ToString().Contains(autobox.Text));
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

    public class customDisk
    {
        public int DiskID { get; set; }

        public short ChkOutStatus { get; set; }

        public string TitleName { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public bool Deleted { get; set; }

        public customDisk() { }
        public customDisk(int diskID, short chkOutStatus, string titleName, decimal price, bool isAvailable, bool deleted)
        {
            DiskID = diskID;
            ChkOutStatus = chkOutStatus;
            TitleName = titleName;
            Price = price;
            IsAvailable = isAvailable;
            Deleted = deleted;
        }
    }

    
}
