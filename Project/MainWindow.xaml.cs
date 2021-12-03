using Project;
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

namespace Auth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            //Если длина логина > 2 и пароля >= 3, то идет подключение к базе
            if (textBoxLogin.Text.Length > 2 && passBox.Password.Length >= 3)
            {
                using (ProgramEntities2 dataBase = new ProgramEntities2())
                {
                    //Запрос, где логин и пароль должны совпадать с данными в базе
                    var query = dataBase.Registratciya.Where(x => x.Login == textBoxLogin.Text
                                                         && x.Password == passBox.Password
                                                         ).FirstOrDefault();
                    //Если запрос не пустой, то открывается личный кабинет
                    if (query != null)
                    {
                            MessageBox.Show("Вы вошли!");
                            Window2 Window = new Window2();
                            this.Close();
                            Window.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
            
        }
        //Открытие окна регистрации
        private void agreedreg_Click(object sender, RoutedEventArgs e)
        {
            Window1 Window = new Window1();
            Window.Show();
        }
    }
}
