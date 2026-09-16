using System.Windows;
using System.Windows.Media;

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

        // 登入按鈕
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            // 預設驗證帳號密碼
            string correctUser = "1";
            string correctPass = "1";

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
                txtMessage.Foreground = Brushes.LightGreen;
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