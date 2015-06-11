using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTimeUnionApp
{
    public class ReviewerRegistrar
    {
        
        protected PartTimeProfessorDataAdapter profAdapter;
        protected CourseDataAdapter courseAdapter;
        protected InstructorDataAdapter instructorDataAdapter;
        protected TapRecordAdapter tapAdapter;
        protected ActivityLogDataAdapter logAdapter;


      //  ========================================================================================================
        protected PartTimeProfessor yourself;
        protected CourseArray teaching = new CourseArray();
        protected ActivityLog log;
        protected int seniority = 0;
        protected String user = "kaliu";
        protected String password = "EVIAH23aji";

        public ReviewerRegistrar(String userId)
        {
            profAdapter= new PartTimeProfessorDataAdapter(user, password);
            courseAdapter = new CourseDataAdapter(user, password);
            instructorDataAdapter = new InstructorDataAdapter(user, password);
            tapAdapter = new TapRecordAdapter(user, password);
            logAdapter = new ActivityLogDataAdapter(user, password);
            log = new ActivityLog(user, password);
            //initialize!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Retrive data part should be change when login function is ready////////////////////////////////////////////////////////////////////////////////////////
            yourself = profAdapter.RetrieveData(userId);
            yourself.SetTAPList(tapAdapter.RetrieveViaProf(userId));
            InstructorDataArray insList = instructorDataAdapter.RetrieveViaProf(userId);
            log.InsertRecord("Login.");
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < insList.GetNumOfRecord(); i++)
            {
                if(courseAdapter.RetrieveACourse(insList.GetAll()[i].GetCourse()).GetEvaluationPerformed() != 1)
                    teaching.InsertCourse(courseAdapter.RetrieveACourse(insList.GetAll()[i].GetCourse()));//This array shows the courses that this guy is teaching now.

                seniority += insList.GetAll()[i].GetSeniority();
                yourself.SetSeniority(seniority);
            }

            
        }
//===================================================================================================================



        public void ReportYourself()
        {
            yourself.print();
            teaching.print();
           
        }
  

       // public void Reprot();//needs to be override

        //personal information editor

        /* 
        0:  id
        1:  private String lastName;
        2:  private String firstName;
        3:  private String middleInitial;
        4:  private String homeAddress;
        5:  private String homePhone;
        6:  private String schoolExtention;
        7:  private String algomaUEmail;
        8:  private String privateEmail;
         */

        //public String[] ReviewPersonInfo()
        //{
        //    String[] info = new String[8];

        //    info[0] = person.GetId();
        //    info[1] = person.GetFirstName() + " " + person.GetMiddleInitial() + " " + person.GetLastName();
        //    info[2] = person.GetStreet();
        //    info[3] = person.GetHomePhone();
        //    info[4] = person.GetSchoolExtention();
        //    info[5] = person.GetAlgomauEmail();
        //    info[6] = person.GetPrivateEmail();

        //    return info;
        //}

        //=====================================================
        //edit peronal infomation of uesr himself
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //not finish yet, needs another DBadapter!!

       

  

     

    }
  

        //it can retrive everything from these two lists, so I'll consider to add new features when combine the GUI

    
}
