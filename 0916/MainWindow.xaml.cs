using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _0916
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
        }

        //登入按鈕
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            // 帳號密碼
            string correctUser = "Justin";
            string correctPass = "20080907";

            // 未輸入帳號密碼
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtMessage.Foreground = Brushes.Red;
                txtMessage.Text = "請輸入帳號與密碼！";
                return;
            }

            // 驗證帳密
            if (username == correctUser && password == correctPass)
            {
                txtMessage.Foreground = Brushes.Green;
                txtMessage.Text = "登入成功！歡迎回來，" + username;
                Window1 window1 = new Window1();
                window1.Show();
                this.Hide();


            }
            else
            {
                txtMessage.Foreground = Brushes.Red;
                txtMessage.Text = "帳號或密碼錯誤，請重新輸入！";
            }
        }
    }
}