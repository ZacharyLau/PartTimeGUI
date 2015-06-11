using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PartTimeUnionApp
{
    public class PartTimeProfessor
    {
        private String individualId;
        private String lastName;
        private String firstName;
        private String middleInitial;
        private String workPhone;
        private String homePhone;
        private String schoolExtention;
        private String algomaUEmail;
        private String privateEmail;
        private String country;
        private String province;
        private String city;
        private String street;
        private String postcode;
        private int seniority = 0;
        private TAPArray TAPList;
        private InstructorDataArray teachingCourses;
        public PartTimeProfessor() { }
        public PartTimeProfessor(String ID)
        {
            SetId(ID);
        }
        public PartTimeProfessor(string individual_id, string last_name, string middle_initial,
            string first_name, string street, string country, string province,
            string city, string postcode, string home_phone, string work_phone, string school_extension,
            string algomau_email, string private_email)
        {
            SetId(individual_id);
            SetLastName(last_name);
            SetMiddleInitial(middle_initial);
            SetFirstName(first_name);
            SetCountry(country);
            SetProvince(province);
            SetCity(city);
            SetStreet(street);
            SetPostcode(postcode);
            SetHomePhone(home_phone);
            workPhone = work_phone;
            SetSchoolExtention(school_extension);
            SetAlgomauEmail(algomau_email);
            SetPrivateEmail(private_email);

        }

        public String GetName()
        {
            return individualId + "   " + lastName + " " + firstName;
        }



        //mutator 
        public void SetTAPList(TAPArray list)
        {
            this.TAPList = list;
        }
        public TAPArray GetTAPList()
        {
            return TAPList;
        }

        //geter and seter of individualID
        public String GetId()
        {
            return individualId;
        }
        public void SetId(String id)
        {
            this.individualId = id;
        }
        //geter and seter of lastName
        public String GetLastName()
        {
            return lastName;
        }
        public void SetLastName(String lastName)
        {
            this.lastName = lastName;
        }
        //geter and seter of firstName
        public String GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        //geter and seter of middleInitial
        public String GetMiddleInitial()
        {
            return middleInitial;
        }
        public void SetMiddleInitial(String middleInitial)
        {
            this.middleInitial = middleInitial;
        }
        //geter and seter of loginName
        public String GetCountry()
        {
            return country;
        }
        public void SetCountry(String country)
        {
            this.country = country;
        }
        //geter and seter of userType
        public String GetProvince()
        {
            return province;
        }
        public void SetProvince(String province)
        {
            this.province = province;
        }
        //geter and seter of password
        public String GetCity()
        {
            return city;
        }
        public void SetCity(String city)
        {
            this.city = city;
        }


        //geter and seter of individualID
        public String GetStreet()
        {
            return street;
        }
        public void SetStreet(String street)
        {
            this.street = street;
        }
        public void SetPostcode(String postcode)
        {
            this.postcode = postcode;
        }
        public String GetPostcode()
        {
            return postcode;
        }
        public String GetHomePhone()
        {
            return homePhone;
        }
        public void SetHomePhone(String homePhone)
        {
            this.homePhone = homePhone;
        }
        public String GetWorkPhone()
        {
            return workPhone;
        }
        public void SetWorkPhone(String workPhone)
        {
            this.workPhone = workPhone;
        }
        //geter and seter of schoolExtention
        public String GetSchoolExtention()
        {
            return schoolExtention;
        }
        public void SetSchoolExtention(String schoolExtention)
        {
            this.schoolExtention = schoolExtention;
        }
        //geter and seter of algomaUEmail
        public String GetAlgomauEmail()
        {
            return algomaUEmail;
        }
        public void SetAlgomauEmail(String algomaUEmail)
        {
            this.algomaUEmail = algomaUEmail;
        }
        //geter and seter of privateEmail
        public String GetPrivateEmail()
        {
            return privateEmail;
        }
        public void SetPrivateEmail(String privateEmail)
        {
            this.privateEmail = privateEmail;
        }
        
        public InstructorDataArray GetTeachingCourses()
        {
            return teachingCourses;
        }
        public void SetTeachingCourses(InstructorDataArray list)
        {
            this.teachingCourses = list;
        }
        public int GetSeniority()
        {
            return seniority;
        }
        public void SetSeniority(int sen)
        {
            this.seniority = sen;
        }
        public PartTimeProfessor Clone()
        {
            PartTimeProfessor prof = new PartTimeProfessor(individualId, lastName, middleInitial,
            firstName, street, country, province,
            city, postcode, homePhone, workPhone, schoolExtention,
            algomaUEmail, privateEmail);
            prof.SetSeniority(seniority);
            prof.SetTAPList(this.TAPList);
            prof.SetTeachingCourses(this.teachingCourses);
            return prof;
        }
        public void print()
        {
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
             * 
             * 
             * 
             */
            String s = "ID:" + individualId + " Name:" + firstName + " " + middleInitial + " " + lastName + "\n"
                + "Work phone:" + workPhone + "School extention:" + schoolExtention + " Home phone:" + homePhone + "\n"
                + "Country:" + country + " Province:" + province + " City:" + city + " Street:" + street + " Postcode:" + postcode + "\n"
                + "AlgomaU email:" + algomaUEmail + " Private email:" + privateEmail + " Seniority:" + seniority + "\n"
                + "TAP list:" + "\n";
            Console.WriteLine(s);
            for (int i = 0; i < TAPList.GetNumOfTap(); i++)
            {
                Console.WriteLine("TAP's course:" + TAPList.GetAll()[i].GetCourseInfo() + " Date:" + TAPList.GetAll()[i].GetTAPDate().ToString() + "\n");
            }
            for (int i = 0; i < teachingCourses.GetNumOfRecord(); i++)
            {
                Console.WriteLine("Course:" + teachingCourses.GetAll()[i].GetCourse() + "\n");
            }
            Console.WriteLine("\n");


        }


    }
}