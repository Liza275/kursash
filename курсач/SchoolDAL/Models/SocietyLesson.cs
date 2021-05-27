namespace SchoolDAL.Models
{
    public class SocietyLesson
    {
        public int Id { get; set; }

        public int SocietyId { get; set; }

        public int LessonId { get; set; }

        public virtual Society Society { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
