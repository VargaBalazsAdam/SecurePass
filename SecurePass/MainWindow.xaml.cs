using SecurePass.Models;
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

namespace SecurePass
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private AuthRepository authRepository;
    public List<Auth> auths { get; set; }
    public Auth NewAuth { get; set; }

    public MainWindow()
    {
      InitializeComponent();
      authRepository = new AuthRepository();
      NewAuth = new Auth();
      auths = authRepository.GetAll().ToList();
      LbNames.ItemsSource = auths;
    }

    private void Save(object sender, RoutedEventArgs e)
    {
      NewAuth = new()
      {
        name = TxtBoxTempName.Text,
        username = TxtBoxUsername.Text,
        password = TxtBoxPassVisible.Text,
        email = TxtBoxEmail.Text,
        link = TxtBoxLink.Text
      };
      authRepository.Add(NewAuth);
      LbItemTempName.Visibility = Visibility.Collapsed;
      TxtBoxTempName.Text = "";
      auths.Add(NewAuth);
      LbNames.ItemsSource = null;
      LbNames.ItemsSource = auths;
    }

    private void CreateNewModel(object sender, RoutedEventArgs e)
    {
      LbItemTempName.Visibility = Visibility.Visible;
    }

    private void CopyPasswordToClipboard(object sender, RoutedEventArgs e)
    {

    }

    private void ChangeVisibilityOfThePassword(object sender, RoutedEventArgs e)
    {

    }

    private void AddMoreAccessableSource(object sender, RoutedEventArgs e)
    {

    }

    private void OpenLink(object sender, RoutedEventArgs e)
    {

    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
      TxtBoxPassVisible.Text = PassBoxPassHidden.Password;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void TxtBoxPassVisible_TextChanged(object sender, TextChangedEventArgs e)
    {
      PassBoxPassHidden.Password = TxtBoxPassVisible.Text;
    }
  }
}
