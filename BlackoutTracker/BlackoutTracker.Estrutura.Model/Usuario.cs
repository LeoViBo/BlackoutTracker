namespace BlackoutTracker.Estrutura.Model
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Bairro { get; set; } // É irrelevante para usuraios tecnicos
        public string Tipo { get; set; } // Pode ser um usuario Morador ou um Tecnico(da prefeitura)
    }
}
