using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class TAPRecord
    {
        private String instructorId;
        private DateTime date;
        private String course;
        private int active;
        private DateTime cancelDate;
        private DateTime expireDate;
        private DateTime initialDate;
        private DateTime previous;

        public TAPRecord(String instructorId, String course, DateTime date)
        { 
            this.instructorId = instructorId;
            this.course = course;
            this.date = date;
            this.initialDate = date;
            active = 1;
            cancelDate = Convert.ToDateTime("1900-01-01");
            expireDate = date.AddYears(3);
        }

        public TAPRecord() { }

        public DateTime GetPrevious(){
            return previous;
        }

        public void SetPrevious(DateTime date)
        {
            previous = date;
        }

        public DateTime GetExpireDate()
        {
            return expireDate;
        }

        public void SetExpireDate(DateTime date)
        {
            this.expireDate = date;
        }
       
        public DateTime GetCancelDate()
        {
            return cancelDate;
        }

        public void SetCancelDate(DateTime date)
        {
            this.cancelDate = date;
        }

        public DateTime GetInitialDate()
        {
            return initialDate;
        }

        public void SetInitialDate(DateTime date)
        {
            this.initialDate = date;
        }

        public DateTime GetTAPDate()
        {
            return date;
        }

        public String GetCourseInfo()
        {
            return course;
        }

        public String GetFacultyInfo()
        {
            return instructorId;
        }

        public int IsActive()
        {
            return active;
        }

        public void UpdateTAPDate(DateTime date)
        {
            this.date = date;
        }

        public void UpdateProfessor(String id)
        {
            this.instructorId = id;
        }

        public void UpdateIsActive()
        {
            if (expireDate.Subtract(DateTime.Now).Days < 0)
            {
                active = 1;
            }
            else if (!cancelDate.Equals("1900-01-01") && cancelDate.Subtract(DateTime.Now).Days < 0)
            {
                active = 1;
            }
            
        }

        public void SetCourseCode(String course)
        {
            this.course = course;
        }

        public void UpdateIsActive(int active)
        {
            this.active = active;
        }



    }
}
