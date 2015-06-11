using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class CourseRegisterRecord
    {
        private String instructorId;
        private String fullCourseCode;
        private DateTime offerDate;
        private int accepted;

        public CourseRegisterRecord() { }

        public CourseRegisterRecord(String id, String code)
        {
            offerDate = DateTime.Now;
            instructorId = id;
            fullCourseCode = code;
            accepted = 0;
        }

        public void SetInstructorId(String id)
        {
            this.instructorId = id;
        }

        public String GetInstructorId()
        {
            return instructorId;
        }

        public void SetFullCourseCode(String code)
        {
            this.fullCourseCode = code;
        }

        public String GetFullCourseCode()
        {
            return this.instructorId;
        }

        public void SetAccepted(int acc)
        {
            if (acc != 0)
            {
                if (acc != 1)
                    throw new Exception("Invalid accetped data.");
            }

            this.accepted = acc;
        }

        public int GetAccepted()
        {
            return accepted;
        }

        public DateTime GetOfferDate()
        {
            return offerDate;
        }

        public void SetOfferDate(DateTime date)
        {
            this.offerDate = date;
        }

    }
}
