using System.ComponentModel.DataAnnotations;

namespace server.Model
{
    public class AnimalModel
    {
        public int Id { get; set; }
        // TODO FluentValidation might be better
        [Required]
        public required string Name { get; set; }
    }
}