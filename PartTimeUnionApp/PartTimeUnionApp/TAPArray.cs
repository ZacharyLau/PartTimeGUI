using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class TAPArray
    {
        private ADTArray<TAPRecord> TAPList = new ADTArray<TAPRecord>();

        public TAPRecord GetRecord(TAPRecord record)
        {
            for(int i = 0; i < TAPList.GetNumOfItem();i++)
            {
                if(TAPList.GetItem(i).GetCourseInfo().Equals(record.GetCourseInfo()))
                {
                    return TAPList.GetItem(i);
                }
            }

            throw new Exception("No such record for this person");
        }

        public TAPArray GetRecordViaCourse(String Code)
        {
            TAPArray list = new TAPArray();
            for (int i = 0; i < TAPList.GetNumOfItem(); i++)
            {
                if (TAPList.GetItem(i).GetCourseInfo().Equals(Code))
                {
                    list.UpdateRecord(TAPList.GetItem(i));
                }
            }
            return list;
        }

        public TAPArray GetRecordViaProf(String id)
        {
            TAPArray list = new TAPArray();
            for (int i = 0; i < TAPList.GetNumOfItem(); i++)
            {
                if (TAPList.GetItem(i).GetFacultyInfo().Equals(id))
                {
                    list.UpdateRecord(TAPList.GetItem(i));
                }
            }
            return list;
        }

        /*  this method update the date for current TAP record
         *  if the record does not exsit in array, add new record
         */
        public void UpdateRecord(TAPRecord record)
        {
            for (int i = 0; i < TAPList.GetNumOfItem(); i++)
            {
                if (TAPList.GetItem(i).GetCourseInfo().Equals(record.GetCourseInfo()))
                {
                    TAPList.GetItem(i).UpdateTAPDate(DateTime.Now);
                    return;
                }
            }

            TAPList.Insert(record);
        }



        public void UpdateRecordRemoved(TAPRecord record, int isRemoved)
        {
            for (int i = 0; i < TAPList.GetNumOfItem(); i++)
            {
                if (TAPList.GetItem(i).GetCourseInfo().Equals(record.GetCourseInfo()))
                {
                    TAPList.GetItem(i).UpdateIsActive(isRemoved);
                    return;
                }
            }

            throw new Exception("Record does not exist");
        }

        public int GetNumOfTap()
        {
            return TAPList.GetNumOfItem();
        }

        public TAPRecord[] GetAll()
        {
           return TAPList.GetAll();
        }

    }
}
