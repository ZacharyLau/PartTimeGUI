using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class CourseArray
    {
        private ADTArray<Course> array = new ADTArray<Course>();

        public void InsertCourse(Course course)
        {
            if (InnerSearch(course) != -1)
            {
                throw new Exception("Duplicated course.");
            }

            array.Insert(course);
        }

        public int GetNumOfCourse()
        {
            return array.GetNumOfItem();
        }

		public int GetSize()
		{
			return array.GetNumOfItem();
		}

        private int InnerSearch(Course course)
        {
            for (int i = 0; i < array.GetNumOfItem(); i++)
            {
                if (array.GetItem(i).GetFullCourseCode().Equals(course.GetFullCourseCode()))
                {
                    return i;
                }
            }

            return -1;
        }


        public Course GetCourse(Course course)
        {
            int index = InnerSearch(course);

            if (index == -1)
            {
                throw new Exception("No such course exists.");
            }

            return array.GetItem(index);

        }


        public void DeleteCourse(Course course)
        {
            int index = InnerSearch(course);

            if (index == -1)
            {
                throw new Exception("No such Course exists.");
            }

            array.Delete(index);

        }

        public Course[] GetAll()
        {
            return array.GetAll();
        }

        public void print()
        {
            for(int i=0; i<array.GetNumOfItem();i++)
            {
                array.GetAll()[i].print();
    
            }
        }

      

    }
}
