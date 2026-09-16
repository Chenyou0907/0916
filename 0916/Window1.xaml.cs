using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _0916
{
    public partial class Window1 : Window
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

        public Window1()
        {
            InitializeComponent();
            this.Loaded += Window1_Loaded;
            this.Closed += Window1_Closed;
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            double width = Math.Max(this.ActualWidth, 900);
            double height = Math.Max(this.ActualHeight, 420);

            // 產生 60 個隨機浮游光點
            for (int i = 0; i < 60; i++)
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
            double width = Math.Max(this.ActualWidth, 900);
            double height = Math.Max(this.ActualHeight, 420);

            foreach (var p in _particles)
            {
                p.X += p.Vx;
                p.Y += p.Vy;

                // 邊緣穿透循環
                if (p.X < -15) p.X = width + 10;
                if (p.X > width + 15) p.X = -10;
                if (p.Y < -15) p.Y = height + 10;
                if (p.Y > height + 15) p.Y = -10;

                // 呼吸明滅
                p.Shape.Opacity += p.AlphaSpeed;
                if (p.Shape.Opacity >= 0.85 || p.Shape.Opacity <= 0.2)
                {
                    p.AlphaSpeed = -p.AlphaSpeed;
                }

                Canvas.SetLeft(p.Shape, p.X);
                Canvas.SetTop(p.Shape, p.Y);
            }
        }

        private void Window1_Closed(object sender, EventArgs e)
        {
            // 視窗關閉時卸載渲染事件，避免佔用記憶體
            CompositionTarget.Rendering -= OnUpdateFrame;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;

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