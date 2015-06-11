using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class CourseRegisterRecordArray
    {
        ADTArray<CourseRegisterRecord> registerList  = new ADTArray<CourseRegisterRecord>();

        public void InsertRecord(CourseRegisterRecord record)
        {
            if (InnerSearch(record) == -1)
            {
                registerList.Insert(record);
            }
            else
            {
                throw new Exception("Duplicated register record.");
            }

        }

        private int InnerSearch(CourseRegisterRecord record)
        {
            for (int i = 0; i < registerList.GetNumOfItem(); i++)
            {
                if (record.GetFullCourseCode().Equals(registerList.GetItem(i).GetFullCourseCode()) && record.GetInstructorId().Equals(registerList.GetItem(i).GetInstructorId()))
                {
                    return i;
                }
            }

            return -1;
        }

        public void DeleteRecord(CourseRegisterRecord record)
        {
            int index = InnerSearch(record);
            if (index == -1)
            {
                throw new Exception("Record does not exist.");
            }

            registerList.Delete(index);
        }

        public CourseRegisterRecordArray GetRecordViaCourse(String Code)
        {
            CourseRegisterRecordArray list = new CourseRegisterRecordArray();
            for (int i = 0; i < registerList.GetNumOfItem(); i++)
            {
                if (registerList.GetItem(i).GetFullCourseCode().Equals(Code))
                {
                    list.InsertRecord(registerList.GetItem(i));
                }
            }
            return list;
        }

        public CourseRegisterRecordArray GetRecordViaProf(String id)
        {
            CourseRegisterRecordArray list = new CourseRegisterRecordArray();
            for (int i = 0; i < registerList.GetNumOfItem(); i++)
            {
                if (registerList.GetItem(i).GetInstructorId().Equals(id))
                {
                    list.InsertRecord(registerList.GetItem(i));
                }
            }
            return list;
        }

        public CourseRegisterRecord[] GetAll()
        {
            return registerList.GetAll();
        }

        public int GetNumOfRecord()
        {
            return registerList.GetNumOfItem();
        }


    }
}
