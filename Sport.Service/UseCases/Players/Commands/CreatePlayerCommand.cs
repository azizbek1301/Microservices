using MediatR;

namespace Sport.DataApplication.UseCases.Players.Commands
{
    public class CreatePlayerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
    }
}
