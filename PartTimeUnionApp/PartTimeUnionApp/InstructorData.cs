using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class InstructorData
    {
        private String prof;
        private String course;
        private int seniority;
        private DateTime date;

        public InstructorData() { }

        public InstructorData(String prof, String course, int seniority, DateTime date)
        {
            this.prof = prof;
            this.course = course;
            this.seniority = seniority;
            this.date = date;
        }

        public String GetProf()
        {
            return this.prof;
        }

        public int GetSeniority()
        {
            return this.seniority;
        }

        public String GetCourse()
        {
            return this.course;
        }

        public DateTime GetDate()
        {
            return date;
        }

        public void SetProf(String prof)
        {
            this.prof = prof;
        }

        public void SetSeniority(int sen)
        {
            this.seniority = sen;
        }

        public void SetCourse(String course)
        {
            this.course = course;
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
        }
    }
}
