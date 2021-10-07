using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppClientes.Model
{
    class LoginViewModel
    {
        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    LoginCommand.ChangeCan=Execute();
                }
            }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set
            {
                if (_senha != value)
                {
                    _senha = value;
                    LoginCommand.ChangeCanExecute();
                }
            }
        }

        public ICommand IncluirUsuario
        {
            get
            {
                var clienteDAL = new ClienteDAL();
                return new MvvmHelpers.Commands.Command(() =>
                {
                    Usuario cli = new Usuario();
                    cli.Nome = "mac";
                    cli.Senha = "numsey";
                    clienteDAL.Add(cli);
                    App.Current.MainPage.DisplayAlert("Novo Usuario", "Inclusão realizada com sucesso", "OK");
                });
            }
        }

        public MvvmHelpers.Commands.Command LoginCommand { get; }
        private INavigation _navigation;

        public LoginViewModel(INavigation navigation)
        {
            LoginCommand = new MvvmHelpers.Commands.Command<string>(VerificarLogin);
            _navigation = navigation;
        }

        private void VerificarLogin(string senha)
        {
            Usuario usuario = new Usuario();
            var clienteDAL = new ClienteDAL();
            usuario = clienteDAL.GetUsuarioLogin(senha);
            if (usuario != null)
            {
                _navigation.PushAsync(new ClientesPage());
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Não foi possível logar", "Dados inválidos...", "Ok");
            }
        }
    }
}
