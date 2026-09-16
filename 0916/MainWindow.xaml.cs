using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _0916
{
    public partial class MainWindow : Window
    {
        // 定義浮游光點粒子
        private class Particle
        {
            public Ellipse Shape { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public double Vx { get; set; }
            public double Vy { get; set; }
            public double AlphaSpeed { get; set; }
        }

        private readonly List<Particle> _particles = new List<Particle>();
        private readonly Random _rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            double width = Math.Max(this.ActualWidth, 445);
            double height = Math.Max(this.ActualHeight, 270);

            // 產生 45 個半透明發光圓點
            for (int i = 0; i < 45; i++)
            {
                double size = _rand.Next(4, 14);
                var p = new Particle
                {
                    Shape = new Ellipse
                    {
                        Width = size,
                        Height = size,
                        Fill = Brushes.White,
                        Opacity = _rand.NextDouble() * 0.7 + 0.2
                    },
                    X = _rand.NextDouble() * width,
                    Y = _rand.NextDouble() * height,
                    // 隨機往各方向緩慢移動
                    Vx = (_rand.NextDouble() - 0.5) * 0.8,
                    Vy = (_rand.NextDouble() - 0.5) * 0.8,
                    AlphaSpeed = (_rand.NextDouble() * 0.02) + 0.005
                };

                Canvas.SetLeft(p.Shape, p.X);
                Canvas.SetTop(p.Shape, p.Y);
                ParticleCanvas.Children.Add(p.Shape);
                _particles.Add(p);
            }

            CompositionTarget.Rendering += OnUpdateFrame;
        }

        private void OnUpdateFrame(object sender, EventArgs e)
        {
            double width = Math.Max(this.ActualWidth, 445);
            double height = Math.Max(this.ActualHeight, 270);

            foreach (var p in _particles)
            {
                p.X += p.Vx;
                p.Y += p.Vy;

                // 碰到邊緣自動從對側穿出（環形空間）
                if (p.X < -15) p.X = width + 10;
                if (p.X > width + 15) p.X = -10;
                if (p.Y < -15) p.Y = height + 10;
                if (p.Y > height + 15) p.Y = -10;

                // 呼吸燈閃爍效果
                p.Shape.Opacity += p.AlphaSpeed;
                if (p.Shape.Opacity >= 0.85 || p.Shape.Opacity <= 0.2)
                {
                    p.AlphaSpeed = -p.AlphaSpeed;
                }

                Canvas.SetLeft(p.Shape, p.X);
                Canvas.SetTop(p.Shape, p.Y);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
        }

        // 登入按鈕
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            // 帳號密碼
            string correctUser = "Justin";
            string correctPass = "20080907";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtMessage.Foreground = Brushes.Red;
                txtMessage.Text = "請輸入帳號與密碼！";
                return;
            }

            if (username == correctUser && password == correctPass)
            {
                CompositionTarget.Rendering -= OnUpdateFrame;

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