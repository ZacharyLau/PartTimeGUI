using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * setCourseCode(String courseCode)
 * SetInstructorId(String instructorId)
 * SetCourseName(String courseName)
 * SetTerm(String term)
 * SetTapOffer(bool tapOffer)
 * SetTapremoved(bool tapRemoved)
 * SetCourseCancelled(bool courseCancelled)
 * SetCourseDescription(String description)
 * SetMultiTerm(bool multiTerm)
 * SetEvaluationPerformed(bool evaluationPerformed)
 */
namespace PartTimeUnionApp
{
    public class Course
    {
        private String courseCode;
        private String term;
        private String courseName;
        private String year;
        private String sessionId;
        private String location;
        private String fullCourseCode;
        private int tapOffer;
        private int courseCancelled;
        private int credit;
        private int evaluationPerformed;
        private int numberOfInstructor;
        private String description;
        private InstructorDataArray instructors;

        public Course() { }

        public Course(String courseID)
        {
            SetCourseCode(courseID);
        }
        public Course(String courseCode, String session, String name, string term, int tapOffer, int cancel, int credit, int evaluate, int numberOfinstructor, string description, String year, String location)
        {
            SetCourseCode(courseCode);
            SetSessionId(session);
            SetCourseName(name);
            SetTerm(term);
            SetTapOffer(tapOffer);
            SetCourseCancelled(cancel);
            SetCredit(credit);
            SetEvaluationPerformed(evaluate);
            SetCourseDescription(description);
            SetYear(year);
            AutoSetFullCourseCode();
            SetNumberOfInstructor(numberOfinstructor);
            SetLocation(location);
        }
        public Course Clone()
        {
            Course backup = new Course(courseCode, sessionId, courseName, term, tapOffer, courseCancelled, credit, evaluationPerformed, numberOfInstructor, description, year, location);
            backup.SetInstructorList(this.instructors);
            return backup;

        }
        //mutator

        public void SetFullCourseCode(String code)
        {
            this.fullCourseCode = code;
        }
        public void AutoSetFullCourseCode()
        {
            this.fullCourseCode = courseCode + sessionId + year.ElementAt(2) + year.ElementAt(3) + term;
        }
        //getter and setter of courseCode
        public String GetCourseCode()
        {
            return courseCode;
        }
        public void SetCourseCode(String courseCode)
        {
            this.courseCode = courseCode;
        }
        //getter and setter of instructorId
        public String GetTerm()
        {
            return term;
        }
        public void SetTerm(String term)
        {
            if (term.Equals("F") || term.Equals("SP") || term.Equals("SF") || term.Equals("SS") || term.Equals("W"))
                this.term = term;
            else
                throw new Exception("Invalid input of term.");
        }
        //getter and setter of courseName
        public String GetCourseName()
        {
            return courseName;
        }
        public void SetCourseName(String courseName)
        {
            this.courseName = courseName;
        }
        //getter and setter of term   // tapOffer  courseCancelled  multiTerm  evaluationPerformed
        public String GetYear()
        {
            return year;
        }
        public void SetYear(String year)
        {
            if (year.Length != 4)
                throw new Exception("Invalid input of year.");
            for (int i = 0; i < 4; i++)
            {
                if (year[i] < '0' || year[i] > '9')
                    throw new Exception("Invalid input of year.");
            }
            this.year = year;
        }
        //getter and setter of tapOffer
        public int GetTapOffer()
        {
            return tapOffer;
        }
        public void SetTapOffer(int tapOffer)
        {
            this.tapOffer = tapOffer;
        }
        //getter and setter of tapRemoved
        /* public bool GetTapRemoved()
         {
             return tapRemoved;
         }
         public void SetTapremoved(bool tapRemoved)
         {
             this.tapRemoved = tapRemoved;
         }
         * */
        //getter and setter of courseCancelled // multiTerm  evaluationPerformed
        public int GetCourseCancelled()
        {
            return courseCancelled;
        }
        public void SetCourseCancelled(int courseCancelled)
        {
            this.courseCancelled = courseCancelled;
        }
        public void SetCourseDescription(String description)
        {
            this.description = description;
        }
        public String GetCourseDescription()
        {
            return description;
        }
        //getter and setter of multiTerm 
        public int GetCredit()
        {
            return credit;
        }
        public void SetCredit(int credit)
        {
            this.credit = credit;
        }
        //getter and setter of evaluationPerformed
        public int GetEvaluationPerformed()
        {
            return evaluationPerformed;
        }
        public void SetEvaluationPerformed(int evaluationPerformed)
        {
            this.evaluationPerformed = evaluationPerformed;
        }
        public void SetSessionId(String id)
        {
            if (id.Length > 2)
                throw new Exception("Invalid session ID.");
            this.sessionId = id;
        }
        public String GetSessionId()
        {
            return sessionId;
        }
        public void SetLocation(String location)
        {
            this.location = location;
        }
        public String GetLocation()
        {
            return location;
        }

        public String GetFullCourseCode()
        {
            return fullCourseCode;
        }
        public void SetNumberOfInstructor(int num)
        {
            this.numberOfInstructor = num;
        }
        public int GetNumberOfInstructor()
        {
            return numberOfInstructor;
        }
        public void SetInstructorList(InstructorDataArray list)
        {
            this.instructors = list;
        }
        public InstructorDataArray GetInstructorList()
        {
            return instructors;
        }
        public void print()
        {
            /* private String courseCode;
        private String term;
        private String courseName;
        private String year;
        private String sessionId;
        private String location;
        private String fullCourseCode;
        private int tapOffer;
        private int courseCancelled;
        private int credit;
        private int evaluationPerformed;
        private int numberOfInstructor;
        private String description;
        private PartTimeProfessorArray instructors;
             * 
             */
            String s = "Course code:" + courseCode + " Course name:" + courseName + " Term:" + term + " Year:" + year + "\n"
            + "Session ID:" + sessionId + " Location:" + location + " Full course code:" + fullCourseCode + " Tap offer:" + tapOffer + "\n"
            + "Course cancelled:" + courseCancelled + " Credit:" + credit + " Evaluation performed:" + evaluationPerformed + " Number of instructor:" + numberOfInstructor + "\n"
            + "Description: " + description + "\n"
            + "Instructors:" + "\n";
            Console.WriteLine(s);
            for (int i = 0; i < instructors.GetNumOfRecord(); i++)
            {
                Console.WriteLine("ID:" + instructors.GetAll()[i].GetProf() + "\n");
            }
            Console.WriteLine("\n");

        }
    }
}