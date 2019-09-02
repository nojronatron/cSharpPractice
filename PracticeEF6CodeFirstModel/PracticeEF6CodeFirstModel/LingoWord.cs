using System.ComponentModel.DataAnnotations;

namespace PracticeEF6CodeFirstModel
{
    public class LingoWord
    {
        // object representing database table
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(45, ErrorMessage = "The longest English word according to Grammerly.com is 45 letters.")]
        public string Word { get; set; }
        [Required]
        public string Category { get; set; }
        //// https://www.grammarly.com/blog/14-of-the-longest-words-in-english/
    }
}
