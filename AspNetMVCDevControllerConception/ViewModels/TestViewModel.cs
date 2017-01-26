using System.Collections.Generic;

namespace AspNetMVCDevControllerConception.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<QuestionViewModel> Questions { get; set; }
    }
}