using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppClientes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginViews : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
            //remove a barra de navegação
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}