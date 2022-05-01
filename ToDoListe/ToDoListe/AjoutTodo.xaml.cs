using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListe.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutTodo : ContentPage
    {
        public AjoutTodo()
        {
            InitializeComponent();
            AddConfirm.Clicked += AddConfirm_Clicked;
        }

        public void AddConfirm_Clicked(object sender, EventArgs e)
        {
            if(txtNom.CursorPosition != 0 && txtDesc.CursorPosition != 0)
            {
                var messageNom = txtNom.Text;
                var messageDesc = txtDesc.Text;

                var message = messageNom + "\n" + messageDesc + "\n";

                DependencyService.Get<IFileService>().CreateFile(message);

                //fermer la page
                Navigation.PopAsync();
               
            }
        }
    }
}