using _24102019_uwp.Business;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _24102019_uwp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MiscellaneousPage : Page
    {
        TypeBS typeController;
        List<Models.Type> lsType;
        public MiscellaneousPage()
        {
            this.InitializeComponent();
            typeController = new TypeBS();
            lsType = typeController.getTypes();
            cbTypes.ItemsSource = lsType;
            cbTypes.DisplayMemberPath = "TypeName";


        }

        private void Save(object sender, RoutedEventArgs e)
        {
            ContentDialog cd;
            if (cbTypes.SelectedIndex != -1 && RentalPeriod.Text.Trim().Length > 0 && RentalRate.Text.Trim().Length > 0)
            {
                Models.Type t = new Models.Type()
                {
                    TypeID = ((Models.Type)cbTypes.SelectedItem).TypeID,
                    RentCharge = decimal.Parse(RentalRate.Text),
                    RentPeriod = short.Parse(RentalPeriod.Text),
                    TypeName = ((Models.Type)cbTypes.SelectedItem).TypeName
                };
                Models.Type n = lsType.Single(m => m.TypeID == ((Models.Type)cbTypes.SelectedItem).TypeID);
                n.TypeID = t.TypeID;
                n.RentCharge = t.RentCharge;
                n.RentPeriod = t.RentPeriod;
                n.TypeName = t.TypeName;
                typeController.ModifyType(t);

                cd = new ContentDialog();
                cd.Content = "Successfully deleted title";
                cd.Title = "Notification";
                cd.PrimaryButtonText = "Close";
                cd.ShowAsync();
                return;
            }

            cd = new ContentDialog();
            cd.Content = "Infomation Error !!!";
            cd.Title = "Notification";
            cd.PrimaryButtonText = "Close";
            cd.ShowAsync();
        }

        private void loadInfo(object sender, SelectionChangedEventArgs e)
        {
            RentalRate.Text = ((Models.Type)cbTypes.SelectedItem).RentCharge + "";
            RentalPeriod.Text = ((Models.Type)cbTypes.SelectedItem).RentPeriod + "";
        }
    }
}
