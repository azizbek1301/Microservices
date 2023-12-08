using MediatR;

namespace Sport.DataApplication.UseCases.Players.Commands
{
    public class UpdatePlayerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
    }
}
