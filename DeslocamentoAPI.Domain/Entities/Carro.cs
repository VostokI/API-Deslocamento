namespace DeslocamentoAPI.Domain.Entities
{
    public class Carro : BaseEntity
    {

     

        public string Placa { get; private set; }

        public string Descricao { get; private set; }

        public Carro()
        {

        }

        public Carro(string placa, string descricao)
        {
            Placa = placa;
            Descricao = descricao;

        }

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();
        public string ToString()
        {
            return $"Placa {Placa} Descricao {Descricao}";
        }


    }
}
