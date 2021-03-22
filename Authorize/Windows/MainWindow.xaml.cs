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
using System.IO;
using Authorize.Windows;

namespace Authorize
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(@"C:\Users\Пользователь\Desktop\УУУ ОАиП\Данные.txt"))
            {
                string textRem;
                using (StreamReader SR = new StreamReader(@"C:\Users\Пользователь\Desktop\УУУ ОАиП\Данные.txt"))
                {
                    textRem = SR.ReadToEnd();
                }
                string[] split = textRem.Split(' ','\r','\n');
                tbLog.Text = split[0];
                tbPas.Password = split[1];
            }
        }

        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Логин")
            {
                textBox.Text = "";
            }
            if (textBox.Text == "Символы на рисунке")
            {
                textBox.Text = "";
            }
        }
        private void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "tbLog" && textBox.Text == "")
            {
                tbLog.Text = "Логин";
            }
            if (textBox.Name == "tbSims" && textBox.Text == "")
            {
                tbSims.Text = "Символы на рисунке";
            }
        }

        private void btnRes_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            string text = "";
            string sim = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
            {
                text += sim[rnd.Next(sim.Length)];
            }
            Caph.Text = text;
        }
        
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            


                if (tbLog.Text == "admin" && tbPas.Password == "admin")
                {
                    if (Caph.Visibility == Visibility.Visible && Caph.Text == tbSims.Text)
                    {
                        MessageBox.Show("Вы успешно авторизированы");

                        Profile profile = new Profile(tbLog.Text);
                        this.Hide();
                        profile.ShowDialog();
                        this.Show();
                    }
                    else if (Caph.Visibility == Visibility.Visible && Caph.Text != tbSims.Text)
                    {
                        MessageBox.Show("Капча введена неверно!");
                        Random rnd = new Random();
                        string textCaph = "";
                        string sim = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
                        for (int i = 0; i < 5; ++i)
                        {
                            textCaph += sim[rnd.Next(sim.Length)];
                        }
                        Caph.Text = textCaph;
                    }
                    else
                    {
                        MessageBox.Show("Вы успешно авторизированы");

                        Profile profile = new Profile(tbLog.Text);
                        this.Hide();
                        profile.ShowDialog();
                        this.Show();
                    }

                }
                else
                {
                    Random rnd = new Random();
                    string textCaph = "";
                    string sim = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
                    for (int i = 0; i < 5; ++i)
                    {
                        textCaph += sim[rnd.Next(sim.Length)];
                    }
                    Caph.Text = textCaph;
                    MessageBox.Show("Вы ввели неправильно логин или пароль");
                    Caph.Visibility = Visibility.Visible;
                    bordCaph.Visibility = Visibility.Visible;
                    btnRes.Visibility = Visibility.Visible;
                    tbCaph.Visibility = Visibility.Visible;
                    tbSims.Visibility = Visibility.Visible;
                }
                if (cbRemember.IsChecked == true)
                {
                    CRUD.Create("admin", "admin");
                }
            }


        
    }
}
