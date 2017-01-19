using System.Collections.Generic;

namespace AspNetMVCDevControllerConception.ORM
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}