
namespace DeslocamentoAPI.Domain.Entities
{
    public class Condutor : BaseEntity
    {
        
        public string Nome { get; set; }
        public string Email { get; set; }

        public Condutor()
        {

        }
        public Condutor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
        public string ToString()
        {
            return $"Nome {Nome} e-mail {Email}";
        }
    }
}
