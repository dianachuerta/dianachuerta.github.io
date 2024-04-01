namespace c
{
    public class Student
    {
        public string ID { get; set; } = "";

        public string name { get; set; } = "";

        public double grade { get; set; } = -1;

        public int gradeLevel { get; set; } = -1;

        public Student()
        { }

        public int GetGradeLevel()
        {
            int level = -1;

            if (this.grade >= 80)
            {
                level = 1;
            }
            else if (this.grade>=65)
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
            return $"{this.name} ({this.ID}), Grade: {this.grade:F2} (Level {this.gradeLevel})";
        }




    }
}


