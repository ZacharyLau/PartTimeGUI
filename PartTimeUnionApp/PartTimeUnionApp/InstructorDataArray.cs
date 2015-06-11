using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class InstructorDataArray
    {
        private ADTArray<InstructorData> instructorDataList = new ADTArray<InstructorData>();

        public void InsertRecord(InstructorData instructor)
        {
            if (InnerSearch(instructor) == -1)
            {
                instructorDataList.Insert(instructor);
            }
            else
            {
                throw new Exception("Duplicated instructor record.");
            }

        }

        private int InnerSearch(InstructorData instructor)
        {
            for (int i = 0; i < instructorDataList.GetNumOfItem(); i++)
            {
                if (instructor.GetCourse().Equals(instructorDataList.GetItem(i).GetCourse()) && instructor.GetProf().Equals(instructorDataList.GetItem(i).GetProf()))
                {
                    return i;
                }
            }

            return -1;
        }

        public void DeleteRecord(InstructorData record)
        {
            int index = InnerSearch(record);
            if (index == -1)
            {
                throw new Exception("Record does not exist.");
            }

            instructorDataList.Delete(index);
        }

        public InstructorDataArray GetRecordViaCourse(String Code)
        {
            InstructorDataArray list = new InstructorDataArray();
            for (int i = 0; i < instructorDataList.GetNumOfItem(); i++)
            {
                if (instructorDataList.GetItem(i).GetCourse().Equals(Code))
                {
                    list.InsertRecord(instructorDataList.GetItem(i));
                }
            }
            return list;
        }

        public InstructorDataArray GetRecordViaProf(String id)
        {
            InstructorDataArray list = new InstructorDataArray();
            for (int i = 0; i < instructorDataList.GetNumOfItem(); i++)
            {
                if (instructorDataList.GetItem(i).GetProf().Equals(id))
                {
                    list.InsertRecord(instructorDataList.GetItem(i));
                }
            }
            return list;
        }

        public InstructorData[] GetAll()
        {
            return instructorDataList.GetAll();
        }

        public int GetNumOfRecord()
        {
            return instructorDataList.GetNumOfItem();
        }

    }
}
