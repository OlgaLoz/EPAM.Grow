using System.Collections.Generic;

namespace AspNetMVCDevControllerConception.ViewModels
{
    public class QuestionViewModel
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public int RightAnswerId { get; set; }

        public virtual ICollection<AnswerViewModel> Answers { get; set; } 
    }
}