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
using System.Xml.Linq;

namespace Laba5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
public void BtnLogin_Click(object sender, RoutedEventArgs e)
{
    string username = Username;
    string password = password.Password;

    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
    {
        MessageBox.Show("Пожалуйста, введите имя пользователя и пароль");
        return;
    }
    try
    {
        bool isAuthenticated = UserManager.AuthenticateUser(username, password);

        if (isAuthenticated)
        {
            Role role = UserManager.GetUserRole(username);

            if (role == Role.Manager)
            {
                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.ShowDialog();
            }
            else if (role == Role.Chef)
            {
                ChefWindow chefWindow = new ChefWindow();
                chefWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильная роль пользователя");
            }

            Close();
        }
        else
        {
            MessageBox.Show("Неправильное имя пользователя или пароль");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Произошла ошибка: {ex.Message}");
    }
}

public enum Role
{
    Manager,
    Chef
}

public static class UserManager
{
    public static bool AuthenticateUser(string username, string password)
    {
    }

    public static Role GetUserRole(string username)
    {
    }

    internal static void RegisterUser(User user)
    {
        throw new NotImplementedException();
    }
}

public partial class ManagerWindow : Window
{
    public List<Ingredient> DataGrid { get; private set; }
    public string Quantityt { get; private set; }
    public string PizzaIdt { get; private set; }
    public string PizzaId { get; private set; }
    public string Quantity { get; private set; }

    public ManagerWindow()
    {
        InitializeComponent();
        LoadIngredientsData();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void LoadIngredientsData()
    {
        DataGrid = DataManager.LoadIngredientsData();
    }

    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
        DataManager.AddIngredient(new Ingredient()
        {
            Name = Name,
            Quantity = int.Parse(Quantityt),
            PizzaId = int.Parse(PizzaIdt)
        });

        LoadIngredientsData();
    }

    private void BtnUpdate_Click(object sender, RoutedEventArgs e)
    {
        Ingredient ingredient = (Ingredient)DataGrid;
        ingredient.Name = Name;
        ingredient.Quantity = int.Parse(Quantity);
        ingredient.PizzaId = int.Parse(PizzaId);

        DataManager.UpdateIngredient(ingredient);

        LoadIngredientsData();
    }

    private void BtnDelete_Click(object sender, RoutedEventArgs e)
    {
        Ingredient ingredient = (Ingredient)DataGrid;

        DataManager.DeleteIngredient(ingredient.Id);

        LoadIngredientsData();
    }
}

public partial class ChefWindow : Window
{
    public ChefWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}

public static class DataManager
{
    public static List<Ingredient> LoadIngredientsData()
    {

    }

    public static void AddIngredient(Ingredient ingredient)
    {
    }

    public static void UpdateIngredient(Ingredient ingredient)
    {
    }

    public static void DeleteIngredient(int ingredientId)
    {
    }
}

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int PizzaId { get; set; }

    public static explicit operator Ingredient(List<Ingredient> v)
    {
        throw new NotImplementedException();
    }
}

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}

public partial class RegistrationWindow : Window
{
    public RegistrationWindow()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void BtnRegister_Click(object sender, RoutedEventArgs e)
    {
        UserManager.RegisterUser(new User()
        {
            Name = Name,
            Role = Role.Manager
        });

        MessageBox.Show("Пользователь успешно зарегистрирован");
        Close();
    }
}

public class User
{
    public string Name { get; set; }
    public Role Role { get; set; }
}