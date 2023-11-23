using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.Console.Classes
{
    /// <summary>
    /// Classe criada como exemplo para a oficina da UMFG 2023
    /// </summary>
    internal class User
    {
        private readonly string _login;

        public string Password { get; private set; }
        public string Name { get; private set; }

        public User(string login, string password)
        {
            _login = login ?? throw new ArgumentNullException(nameof(_login));
            Password = password ?? throw new ArgumentNullException(nameof(Password));
        }

        //Exemplos de metodo sobreescrito e sobrecarga de metodo
        public override string ToString() => $"{_login} - {Password}";
        public void SetValue(string password) => Password= password;
        public void SetValue(string password, string name)
        {
            Password = password;
            Name = name;
        }

        // não pode ser atribuido valor a uma vairavel readonly fora do método construtor
        //public void SetLogin(string login)
        //{
        //    _login = login;
        //}
    }
}
