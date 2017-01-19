using System.Collections.Generic;

namespace AspNetMVCDevControllerConception.ORM
{
    public class Question
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public int RightAnswerId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } 
    }
}