namespace Patrimonio.Business.Entities
{
    public class EPatrimonio
    {
        public EPatrimonio()
        {
            Marca = new EMarca();
        }

        public long PatrimonioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NumTombo { get; set; }
        public EMarca Marca { get; set; }
    }
}