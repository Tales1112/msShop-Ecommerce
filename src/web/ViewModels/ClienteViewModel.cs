namespace msShop.ViewModels
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
