using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Laba5
{
    public partial class DataManager : Window
    {
        public DataManager()
        {
            InitializeComponent();
            LoadPizzasData();
        }

        public static List<Ingredient> LoadIngredientsData(Laba5DataSet laba5DataSet)
        {
            using (var context = new Laba5DataSet())
            {
                List<Ingredient> ingredientList = new List<Ingredient>();
                foreach (Laba5DataSet.IngredientsRow row in laba5DataSet.Ingredients)
                {
                    Ingredient ingredient = new Ingredient
                    {
                        Name = row.Name,
                        Quantity = row.Quantity
                    };

                    ingredientList.Add(ingredient);
                }
                return ingredientList;
            }
        }

        public static void AddIngredient(Ingredient ingredient)
        {
            using (var context = new Laba5DataSet())
            {
                context.Ingredients.Add(ingredient);
                context.SaveChanges();
            }
        }

        public static void UpdateIngredient(Ingredient ingredient)
        {
            using (var context = new Laba5DataSet())
            {
                var existingIngredient = context.Ingredients.FindByingredients_ID(ingredient.Id);

                if (existingIngredient != null)
                {
                    existingIngredient.Name = ingredient.Name;
                    existingIngredient.Quantity = ingredient.Quantity;
                    existingIngredient.PizzaId = ingredient.PizzaId;

                    context.SaveChanges();
                }
            }
        }

        public static void DeleteIngredient(int ingredientId)
        {
            using (var context = new Laba5DataSet())
            {
                var existingIngredient = context.Ingredients.FindByingredients_ID(ingredientId);

                if (existingIngredient != null)
                {
                    context.Ingredients.RemoveIngredientsRow(existingIngredient);
                    context.SaveChanges();
                }
            }
        }

        private static List<Pizza> LoadPizzasData()
        {
            using (var context = new Laba5DataSet())
            {
                List<Pizza> pizzaList = new List<Pizza>();
                foreach (Laba5DataSet.PizzasRow row in context.Pizzas)
                {
                    Pizza pizza = new Pizza();
                    pizzaList.Add(pizza);
                }
                return pizzaList;
            }
        }

        public static List<Employee> LoadEmployeesData()
        {
            using (var context = new Laba5DataSet())
            {
                return context.Employees.ToList();
            }
        }
    }

    public class Employee
    {
    }

    internal class Pizza
    {
    }
}