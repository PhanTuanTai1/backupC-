using _24102019_uwp.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using _24102019_uwp.Models;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReturnPage : Page
    {
        ReturnBS rb;
        List<int> selected;
        List<Disk> ListDisk;
        public ReturnPage()
        {
            this.InitializeComponent();
            rb = new ReturnBS();
            selected = new List<int>();
            ListDisk = rb.getAllDisk();
        }

        private void Autobox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            Trigger();
        }

        private void Autobox_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                Trigger();
            }
        }

        private DetailReturnDisk Search(string id)
        {
            if (Regex.IsMatch(id, @"^\d+$"))
            {
                return rb.Search(int.Parse(id));
            }
            return null;
        }
        private  void Trigger()
        {          
            DetailReturnDisk d = Search(autobox.Text.Trim());
            if (d != null)
            {
                notFound.Text = "";
                resultSearch.Navigate(typeof(DetailReturnDiskPage), d);
            }
            else
            {
                notFound.Text = "Disk doesn't exist or isn't yet rented";
            }
        }
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var disk = (Disk)args.SelectedItem;
            sender.Text = disk.DiskID.ToString();
            if (selected.Contains(disk.DiskID)) return;
            selected.Add(disk.DiskID);
        }
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                sender.ItemsSource = ListDisk.Where(p => p.DiskID.ToString().Contains(sender.Text));
            }
        }
    }
}
