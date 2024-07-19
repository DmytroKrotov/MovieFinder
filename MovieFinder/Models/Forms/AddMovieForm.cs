using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Forms
{
    public class AddMovieForm
    {
        public AddMovieForm()
        {
                
        }
        public AddMovieForm(Movie movie)
        {
            this.Id= movie.Id;
            this.Name = movie.Name;
            this.Premiere= movie.Premiere;
            this.Country = movie.Country;
            this.Studio = movie.Studio;
            this.Producer= movie.Producer;
            this.FullDescription= movie.FullDescription;
            this.ShortDescription= movie.ShortDescription;
            this.Money= movie.Money;
            this.Likes= movie.Likes;
            this.Dislikes= movie.Dislikes;
            this.MovieFacts= movie.MovieFacts;
            this.Comments= movie.Comments;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 200 символів")]
        public string Name { get; set; }
        public DateTime Premiere { get; set; }=DateTime.Now;
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 200 символів")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 200 символів")]
        public string Studio { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 200 символів")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        public string FullDescription { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        [StringLength(100, ErrorMessage = "Довжина поля має бути до 1000 символів")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Поле є обов'язковим")]
        public float Money { get; set; }
        public IFormFile Image { get; set; }
        public List<int> Actors { get; set; }
        public List<int> WorldRatingNames { get; set; }
        public List<int> GenreNames { get; set; }
        public List<Like> Likes { get; set; }
        public List<Dislike> Dislikes { get; set; }
        public List<Viewing> Viewings { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<MovieFact> MovieFacts { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
