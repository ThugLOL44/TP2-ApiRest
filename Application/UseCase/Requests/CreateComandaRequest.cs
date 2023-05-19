namespace Application.UseCase.Requests
{
    public class CreateComandaRequest
    {
        public CreateComandaRequest(int formaEntregaId, int mercaderiaId)
        {
            this.formaEntregaId = formaEntregaId;
            this.mercaderiaId = mercaderiaId;
        }
        public Guid comandaId { get; set; }
        public int formaEntregaId { get; set; }
        public int precioTotal { get; set; }
        public DateTime fecha { get; set; }
        public int mercaderiaId { get; set; }
    }
}
