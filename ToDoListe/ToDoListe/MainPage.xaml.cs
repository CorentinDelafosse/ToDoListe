using PCLStorage;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListe.Interface;
using ToDoListe.Models;
using Xamarin.Forms;
using static Android.Content.ClipData;

namespace ToDoListe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetListe();
            AddTodo.Clicked += AddTodo_Clicked;
            SuppTodo.Clicked += SuppTodo_Clicked;

        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as TodoEle;
            if (item != null)
            {
                var elePage = await TodoElePage.Create(item);
                await Navigation.PushAsync(elePage);
            }
        }

        //page get focus
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetListe();
        }


        private async void AddTodo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AjoutTodo());
            
        }

        public void SetListe()
        {
            //lire ligne d'un fichier et stocker dans une liste
            List<string> listeNom = new List<string>();
            List<string> listeDesc = new List<string>();
            string path = DependencyService.Get<IFileService>().GetLocalFilePath("ListeTodo.txt");
            if (File.Exists(path))
            {
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        int i = 1;
                        while ((line = sr.ReadLine()) != null)
                        {
                            //si une ligne pair
                            if (i % 2 == 1)
                            {
                                listeNom.Add(line);
                            }
                            else
                            {
                                listeDesc.Add(line);
                            }
                            i++;
                        }
                    }
                }
                var ListItem = new List<TodoEle>
                {
                };

                for (int i = 0; i < listeNom.Count; i++)
                {
                    var item = new TodoEle
                    {
                        nom = listeNom[i],
                        description = listeDesc[i]
                    };
                    ListItem.Add(item);
                }

                TodoListe.ItemsSource = ListItem;

            }
            else
            {
                TodoListe.ItemsSource = null;
            }
        }
        
        public async void SuppTodo_Clicked(object sender, EventArgs e)
        {
            //message confirmation suppresion
            var action = await DisplayAlert("Suppression", "Voulez-vous vraiment supprimer vos tâches ?", "Oui", "Non");
            if (action)
            {
                DependencyService.Get<IFileService>().DeleteFile();
            }
            SetListe();
        }
    }
}
