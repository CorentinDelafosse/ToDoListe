using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListe.Interface;
using ToDoListe.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoElePage : ContentPage
    {

        string nomItem = null;
        string descriptionItem = null;
        
        public TodoElePage()
        {
            InitializeComponent();
            Supp1Todo.Clicked += Supp1Todo_Clicked;
        }

        public async void Supp1Todo_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("Suppression", "Voulez-vous vraiment supprimer cette tâche ?", "Oui", "Non");
            if (action)
            {
                DependencyService.Get<IFileService>().DeleteLigne(nomItem, descriptionItem);

                await Navigation.PopAsync();
            }

        }
            
            
        public static async Task<TodoElePage> Create(TodoEle item)
        {
            var page = new TodoElePage();
            
            TodoEle todoEle = await GetEleAsync(item);

            page.BindingContext = todoEle;

            page.nomItem = todoEle.nom;

            page.descriptionItem = todoEle.description;

            return page;
        }

        private static async Task<TodoEle> GetEleAsync(TodoEle item)
        {
            var todoEle = item;
            
            return todoEle;

        }

        
    }
}