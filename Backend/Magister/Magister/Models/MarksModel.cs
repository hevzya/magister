namespace Magister.Models
{
    public class SubjectModel
    {
        public string Name { get; set; }

        public List<MarksModel> ExamMarks { get; set; }
        public List<MarksModel> LessonMarks { get; set; }
    }



    public class MarksModel
    {
        public int? Mark { get; set; }

        public bool? isLate { get; set; }
        public bool? isPresent { get; set; }

        public DateTime Date { get; set; }
        
    }
}
