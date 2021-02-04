namespace src.Entities
{
    internal class Usuario
    {
        public string Nome { get; set; }
        public string email { get; set; }
        public double Salario { get; set; }

        public Usuario(string nome, string email, double salario)
        {
            Nome = nome;
            this.email = email;
            Salario = salario;
        }
    }
}