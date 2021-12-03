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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ProgramEntities2 bd = new ProgramEntities2();
        public Window1()
        {
            InitializeComponent();
        }
        private void CloseAcc_Click(object sender, RoutedEventArgs e)
        {
            //Переменные логина и пароля
            string login = mailBox.Text;
            string password = passBox.Password;
            if (login.Length > 2 && password.Length >= 3)
            {
                //Если введенные пароли совпадают, то
                if (passBox.Password == repassBox.Password)
                {
                    //Используем базу данных для создания нового пользователя
                    using (ProgramEntities2 dataBase = new ProgramEntities2())
                    {
                        //Запрос к базе
                        var query = dataBase.Registratciya.Where(x => x.Login.Equals(mailBox.Text)).FirstOrDefault();
                        //Если логина в базе нет, тогда он вносится в базу
                        {
                            if (query == null)
                            //Добавление нового пользователя
                            {
                                dataBase.Registratciya.Add(new Registratciya
                                {
                                    Login = mailBox.Text,
                                    Password = passBox.Password
                                });
                                MessageBox.Show("Вы успешно зарегистрировались!");
                                //Сохранение изменений
                                dataBase.SaveChanges();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Данный логин уже существует!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введенные пароли не совпадают!");
                }
            }
            else
            {
                MessageBox.Show("Ненадежный логин или пароль!");
            }
        }
    }
}
