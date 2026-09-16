using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace _0916
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;

            // 顯示彈窗
            MessageBox.Show($"您輸入的資訊如下：\n姓名：{name}\n電話：{phone}", "提交成功", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtResult == null || txtNumber == null) return;

            if (int.TryParse(txtNumber.Text, out int maxNumber) && maxNumber > 0)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 1; i <= maxNumber; i++)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        string item = $"{i}×{j}={i * j}";
                        sb.Append(item.PadRight(12));
                    }
                    sb.AppendLine();
                }

                txtResult.Text = sb.ToString();
            }
            else
            {
                txtResult.Text = "請輸入有效的正整數";
            }
        }
    }
}