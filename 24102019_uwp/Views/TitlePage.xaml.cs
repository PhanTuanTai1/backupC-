using _24102019_uwp.Business;
using _24102019_uwp.Models;
using System;
using System.Collections.Generic;
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
    public sealed partial class TitlePage : Page
    {

        ObservableCollection<customTitle> lstTitle;
        bool add, modify;
        const int preID = 160;
        int index;
        TitleBS TitleControler;
        TypeBS TypeController;
        List<Models.Type> lsType;

        public TitlePage()
        {
            this.InitializeComponent();
            TitleControler = new TitleBS();
            TypeController = new TypeBS();
            //lstTitle = new ObservableCollection<customTitle>(TitleControler.getTitles().Where(n => n.Deleted == false).ToList());

            lsType = TypeController.getTypes();

            Type.ItemsSource = lsType;
            lvTitle.ItemsSource = TitleControler.getTitles().Where(n => n.Deleted == false).ToList();//lstTitle;
            SetStatusTextBox(false);

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Title t = CreateObject();
            if (add == true && TitleControler.AddTitle(t))
            {
                UpdateList();
                SetStatusTextBox(false);
                add = false;
                BtnModify.IsEnabled = true;
                BtnAdd.IsEnabled = true;
                BtnDelete.IsEnabled = true;
                ClearText();
                DisplayDialog("Add");
                return;
            }
            if (modify == true && TitleControler.ModifyTitle(t))
            {
                UpdateList();
                SetStatusTextBox(false);
                modify = false;
                BtnModify.IsEnabled = true;
                BtnAdd.IsEnabled = true;
                BtnDelete.IsEnabled = true;
                DisplayDialog("Modify");
                ClearText();
            }
        }
        private void lvTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Display();
        }
        private void Display()
        {
            customTitle t = (customTitle)lvTitle.SelectedItem;
            if (t != null)
            {
                TitleID.Text = t.TitleID + "";
                Description.Text = t.Description;
                Name.Text = t.Name;
                Price.Text = t.Price + "";
                IsAvailable.IsChecked = (bool)t.IsAvailable;
                Deleted.IsChecked = (bool)t.Deleted;
                Type.SelectedIndex = lsType.IndexOf(lsType.Single(n => n.TypeName == t.TypeName));
            }
        }


        private void UpdateList()
        {
            lstTitle = new ObservableCollection<customTitle>();
            lstTitle = new ObservableCollection<customTitle>(TitleControler.getTitles().Where(n=>n.Deleted==false).ToList());
            lvTitle.ItemsSource = lstTitle;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            ClearText();
            SetStatusTextBox(true);
            RandomID();
            (sender as Button).IsEnabled = false;
            BtnModify.IsEnabled = false;
            BtnDelete.IsEnabled = false;
            Deleted.IsEnabled = false;
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
            Title t = (Title)lvTitle.SelectedItem;
            if (TitleControler.RemoveTitle(t.TitleID))
            {
                UpdateList();
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

        private Title CreateObject()
        {
            return new Title()
            {
                Deleted = (bool)Deleted.IsChecked,
                Description = Description.Text,
                IsAvailable = (bool)IsAvailable.IsChecked,
                Name = Name.Text,
                Price = Decimal.Parse(Price.Text),
                TitleID = int.Parse(TitleID.Text),
                TypeID = ((Models.Type)Type.SelectedItem).TypeID
            };
        }
        private void RandomID()
        {
            //CustomerBS controller = new CustomerBS();
            while (true)
            {
                var now = DateTime.Now;
                var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
                int uniqueId = (int)(zeroDate.Ticks / 10000000);
                if (TitleControler.CheckIDExists(int.Parse(preID.ToString() + uniqueId.ToString())) == false)
                {
                    TitleID.Text = preID.ToString() + uniqueId.ToString();
                    break;
                }
            }
        }

        private void SetStatusTextBox(bool e)
        {
            Deleted.IsEnabled = e;
            Description.IsEnabled = e;
            IsAvailable.IsEnabled = e;
            Name.IsEnabled = e;
            Price.IsEnabled = e;
            Type.IsEnabled = e;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void ClearText()
        {
            Deleted.IsChecked = false;
            Description.Text = "";
            IsAvailable.IsChecked = false;
            Name.Text = "";
            Price.Text = "";
            Type.SelectedIndex = -1;
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
                    lvTitle.ItemsSource = lstTitle.Where(x => x.TitleID == int.Parse(autobox.Text));
                }
                else
                {
                    lvTitle.ItemsSource = lstTitle.Where(x => x.Name.Contains(autobox.Text));
                }
            }
        }

        private void timKiem()
        {
            if (isNumber(autobox.Text))
            {
                lvTitle.ItemsSource = lstTitle.Where(x => x.TitleID == int.Parse(autobox.Text));
            }
            else
            {
                lvTitle.ItemsSource = lstTitle.Where(x => x.Name.Contains(autobox.Text));
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
