using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class PartTimeProfessorArray
    {
		public PartTimeProfessorArray(){}
        private ADTArray<PartTimeProfessor> array = new ADTArray<PartTimeProfessor>();

        public void InsertPerson(PartTimeProfessor person)
        {
            if (Search(person) == -1)
            {
                array.Insert(person);
                return;
            }
            throw new Exception("Duplicated person.");
        }

        public int GetNumOfProf()
        {
            return array.GetNumOfItem();
        }

        public int Search(PartTimeProfessor person)
        {
            for (int i = 0; i < array.GetNumOfItem(); i++)
            {
                if (array.GetItem(i).GetId().Equals(person.GetId()))
                {
                    return i;
                }
            }

            return -1;
        }


        public PartTimeProfessor GetProf(PartTimeProfessor person)
        {
            int index = Search(person);

            if (index == -1)
            {
                throw new Exception("No such person exists.");
            }

            return array.GetItem(index);

        }


        public void DeleteProf(PartTimeProfessor person)
        {
            int index = Search(person);

            if (index == -1)
            {
                throw new Exception("No such person exists.");
            }

            array.Delete(index);

        }

        public PartTimeProfessor[] GetAll()
        {
            return array.GetAll();
        }

        public void print()
        {
            for (int i = 0; i < array.GetNumOfItem(); i++)
            {
                array.GetAll()[i].print();

            }
        }
 

    }
}
