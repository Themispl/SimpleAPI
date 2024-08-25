using System.ComponentModel.DataAnnotations;

namespace WebApplicationTest.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
    }
}
