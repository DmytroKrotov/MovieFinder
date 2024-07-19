using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Forms
{
    public class AddActorForm
    {

        public AddActorForm()
        {
                
        }
        public AddActorForm(Actor actor)
        {
            this.Id = actor.Id;

                this.Name = actor.Name;
            this.LastName = actor.LastName;
            this.Birthday = actor.Birthday;
            this.Country = actor.Country;
            this.Biography = actor.Biography;
           
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 200 символів")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 200 символів")]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }=DateTime.Now;
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 200 символів")]
        public string Country { get; set; }
       
        [Required(ErrorMessage = "Поле є обов'язковим")]
        public string Biography { get; set; }
       
        public IFormFile Image { get; set; }
        public List<int> Movies { get; set; }
        public List<int> ActorFacts { get; set; }
        

    }
}
