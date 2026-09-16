using System.Windows;
using System.Xml.Linq;

namespace _0916
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;

            // 顯示彈窗
            MessageBox.Show($"您輸入的資訊如下：\n姓名：{name}\n電話：{phone}", "提交成功", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}