using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Cadastro_Clientes___Back_end.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sobrenome { get; set; }
        public string Nacionalidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

       
    }
}
