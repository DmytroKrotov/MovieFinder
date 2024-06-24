using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models
{
    public class ActorFact
    {
        [Key]
        public int Id { get; set; }
        public int ActorId { get; set; }
        public string Text { get; set; }
        public Actor Actor { get; set; }
    }
}
