//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PartTimeFacultyTeachingRecordSystem
//{
//    public class SuperAdminRegistrar : SupervisorRegistrar
//    {
//        /*
//         * UpdateCourse()
//AddCourse()
//CacelCourse()
//IssueContract()
//RetractContract()
//reviewMemberInfo():String[]
//reviewCourseInfo():String{}
//report():PDF
//editionPersonInfo()
//         * 
//         */
//        //make a course in GUI level, and pass it to here
//        public void AddCourse(Course course)
//        {
//            try
//            {
//                courseList.InsertCourse(course);
//                courseAdapter.Insert(course);
//            }
//            catch (Exception ex)
//            {
//            }

//        }


//        /*String parameters:
//         * 
//        *   cmd.Parameters.AddWithValue("@course_id", course_id);
//               cmd.Parameters.AddWithValue("@instructor_id", instructor_id);
//               cmd.Parameters.AddWithValue("@course_name", course_name);
//               cmd.Parameters.AddWithValue("@term", term);
//         * cmd.Parameters.AddWithValue("@course_description", course_description);
//        */




//        //should it be here?
//        public void UpdateCourseID(Course course, String value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetCourseCode(value);
//                courseAdapter.Update(course, "course_id", course.GetCourseCode());

//            }
//            catch (Exception ex)
//            {
//            }
//        }


//        public void UpdateCourseName(Course course, String value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetCourseName(value);
//                courseAdapter.Update(course, "course_name", value);
//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public void UpdateCourseTerm(Course course, String value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetTerm(value);
//                courseAdapter.Update(course, "term", value);
//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public void UpdateCourseDescription(Course course, String value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetCourseDescription(value);
//                courseAdapter.Update(course, "course_description", value);
//            }
//            catch (Exception ex)
//            {
//            }
//        }


//        /*boolean parameters:
//       * 
//       * cmd.Parameters.AddWithValue("@tap_offer", int.Parse(tap_offer));
//            cmd.Parameters.AddWithValue("@course_cancelled", int.Parse(course_cancelled));
//            cmd.Parameters.AddWithValue("@multi_term", int.Parse(multi_term));
//            cmd.Parameters.AddWithValue("@evaluation_performed", int.Parse(evaluation_performed));
//     * 
//     */


//        public void UpdateCourseCancellation(Course course, int value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetCourseCancelled(value);
//                courseAdapter.Update(course, "course_cancelled", course.GetCourseCancelled());

//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public void UpdateTapOffer(Course course, int value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetTapOffer(value);
//                courseAdapter.Update(course, "tap_offer", value);
//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public void UpdateMultiTerm(Course course, int value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetCredit(value);
//                courseAdapter.Update(course, "multi_term", value);
//            }
//            catch (Exception ex)
//            {
//            }
//        }

//        public void UpdateEvaluationPerformed(Course course, int value)
//        {
//            try
//            {
//                courseList.GetCourse(course).SetEvaluationPerformed(value);
//                courseAdapter.Update(course, "evaluation_performed", value);
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        /**
//         Tap list by course
//         -  List all courses in order that have an active tap involved and the name of the person who has an active tap and when it was taught
//         -  Name of course, name of person, the last time that the course was taught
//         -
//         - =====================================================================================================================
//         -  Course, Instructor, Last time taught 
//         -  Names of people teaching courses that do not have tap because they need to be reviewed
//         -  
//         -  
//         -  */


//    }
//}
