namespace DeslocamentoAPI.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
        public string ToString()
        {
            return $"Nome {Nome} CPF {Cpf}";
        }

    }
}
