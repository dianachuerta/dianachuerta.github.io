using System.ComponentModel.DataAnnotations;

namespace c
{
    public class Student
    {
        [Key]
        public string ID { get; set; } = "";

        public string Name { get; set; } = "";

        public double Grade { get; set; } = -1;
        public int GradeLevel { get; set; } = -1;
        public Student ()
        {
        }
        public int GetGradeLevel()
        {
            int level = -1;
            if (this.Grade>=80)
            {
                level = 1;
            }
            else if (this.Grade>=65)
            {
                level = 2;
            }
            else
            {
                level = 3;
            }
            return level;
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.ID}), Grade: {this.Grade:F2} (Level {this.GradeLevel})";
        }

    }
}