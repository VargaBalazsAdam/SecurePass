using SecurePass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    private int id;

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
      if (LbItemTempName.Visibility == Visibility.Collapsed)
      {
        var auth = authRepository.GetById(id);
        auth.name = TxtBoxTempName.Text;
        auth.username = TxtBoxUsername.Text;
        auth.password = TxtBoxPassVisible.Text;
        auth.email = TxtBoxEmail.Text;
        auth.link = TxtBoxLink.Text;
        authRepository.Update(auth);
      }
      else { 
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
    }

    private void CreateNewModel(object sender, RoutedEventArgs e)
    {
      LbItemTempName.Visibility = Visibility.Visible;
      TxtBoxUsername.Text = "";
      TxtBoxPassVisible.Text = "";
      PassBoxPassHidden.Password = "";
      TxtBoxEmail.Text = "";
      TxtBoxLink.Text = "";
    }

    private void CopyPasswordToClipboard(object sender, RoutedEventArgs e)
    {
      Clipboard.SetText(TxtBoxPassVisible.Text);
    }

    private void ChangeVisibilityOfThePassword(object sender, RoutedEventArgs e)
    {
      if (PassBoxPassHidden.Visibility == Visibility.Collapsed)
      {
        PassBoxPassHidden.Visibility = Visibility.Visible;
        TxtBoxPassVisible.Visibility = Visibility.Collapsed;
      }
      else
      {
        PassBoxPassHidden.Visibility = Visibility.Collapsed;
        TxtBoxPassVisible.Visibility = Visibility.Visible;
      }
    }

    private void OpenLink(object sender, RoutedEventArgs e)
    {
      System.Diagnostics.Process.Start("cmd", "/C start" + " " + TxtBoxLink.Text);
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
      TxtBoxPassVisible.Text = PassBoxPassHidden.Password;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var auth = (LbNames.SelectedItem) as Auth;
      if (auth is not null)
      {
        id = auth.id;
        TxtBoxUsername.Text = auth.username;
        TxtBoxPassVisible.Text = auth.password;
        PassBoxPassHidden.Password = auth.password;
        TxtBoxEmail.Text = auth.email;
        TxtBoxLink.Text = auth.link;
      }
    }

    private void TxtBoxPassVisible_TextChanged(object sender, TextChangedEventArgs e)
    {
      PassBoxPassHidden.Password = TxtBoxPassVisible.Text;
    }

    private async void Delete(object sender, RoutedEventArgs e)
    {
      authRepository.Delete(id);

      var itemToRemove = auths.FirstOrDefault(auth => auth.id == id);
      if (itemToRemove != null)
      {
        auths.Remove(itemToRemove);
      }
      TxtBoxUsername.Text = "";
      TxtBoxPassVisible.Text = "";
      PassBoxPassHidden.Password = "";
      TxtBoxEmail.Text = "";
      TxtBoxLink.Text = "";
      LbNames.Items.Refresh();
    }
  }
}
