using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class SupervisorRegistrar : ReviewerRegistrar
    {

        protected CourseArray courseList;
        protected PartTimeProfessorArray personList;
   


        /*
         * reviewMemberInfo():String[]
            reviewCourseInfo():String{}
            report():PDF
            editionPersonInfo()
         * 
         * //this class is deem on edit person info for every one in the database
         * 
     /* private String individualId;
        private String lastName;
        private String firstName;
        private String middleInitial;
        public String workPhone;
        private String homePhone;
        private String schoolExtention;
        private String algomaUEmail;
        private String privateEmail;
        private String country;
        private String province;
        private String city;
        private String street;
        private String postcode;

        private TAPArray TAPList;
       
         */

        public SupervisorRegistrar(String userId) :base (userId){

            

            profAdapter = new PartTimeProfessorDataAdapter(user, password);
            courseAdapter = new CourseDataAdapter(user, password);
            instructorDataAdapter = new InstructorDataAdapter(user, password);
            tapAdapter = new TapRecordAdapter(user, password);
            logAdapter = new ActivityLogDataAdapter(user, password);

            //initialize!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            log = new ActivityLog(user, password);
            courseList = courseAdapter.RetrieveList();
            personList = profAdapter.RetrieveList();
            TAPArray tapList = tapAdapter.RetrieveList();
            InstructorDataArray insList = instructorDataAdapter.RetrieveList();
            log.InsertRecord("Login.");

            for (int i = 0; i < personList.GetNumOfProf(); i++)
            {
                personList.GetAll()[i].SetTAPList(tapList.GetRecordViaProf(personList.GetAll()[i].GetId()));
                personList.GetAll()[i].SetTeachingCourses(insList.GetRecordViaProf(personList.GetAll()[i].GetId()));
            }

            for (int i = 0; i < courseList.GetNumOfCourse(); i++)
            {
                courseList.GetAll()[i].SetInstructorList(insList.GetRecordViaCourse(courseList.GetAll()[i].GetFullCourseCode()));
            }
    }

        public void UpdatePersonalInfo(PartTimeProfessor targetProf, String lastName, String middleInitial, String firstName, String workPhone, String homePhone, String SchoolExtention, String algomauEmail, String PrivateEmail, String country, String province, String city, String street, String postcode)
        {
            try
            {
                if(!String.IsNullOrEmpty(lastName))
                    targetProf.SetLastName(lastName);
                if(!String.IsNullOrEmpty(middleInitial))
                    targetProf.SetMiddleInitial(middleInitial);
                 if(!String.IsNullOrEmpty(firstName))
                    targetProf.SetFirstName(firstName);
                 if(!String.IsNullOrEmpty(workPhone))
                    targetProf.SetWorkPhone(workPhone);
                 if(!String.IsNullOrEmpty(homePhone))
                    targetProf.SetHomePhone(homePhone);
                 if(!String.IsNullOrEmpty(SchoolExtention))
                    targetProf.SetSchoolExtention(SchoolExtention);
                 if(!String.IsNullOrEmpty(algomauEmail))
                    targetProf.SetAlgomauEmail(algomauEmail);
                 if(!String.IsNullOrEmpty(PrivateEmail))
                    targetProf.SetPrivateEmail(PrivateEmail);
                 if(!String.IsNullOrEmpty(country))
                    targetProf.SetCountry(country);
                 if(!String.IsNullOrEmpty(province))
                    targetProf.SetProvince(province);
                 if(!String.IsNullOrEmpty(city))
                    targetProf.SetCity(city);
                 if(!String.IsNullOrEmpty(street))
                    targetProf.SetStreet(street);
                 if(!String.IsNullOrEmpty(postcode))
                    targetProf.SetPostcode(postcode);


                 profAdapter.Update(targetProf);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
