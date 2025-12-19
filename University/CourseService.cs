using System.Collections.Generic;

namespace University;

public class CourseService
{
   private List<Courses> _courses;

   public CourseService()
   {
      _courses = new List<Courses>();
   }
    
   public void AddCourse(Courses course)
   {
      _courses.Add(course);
   }
    
   public void RemoveCourse(Courses course)
   {
      _courses.Remove(course);
   }
    
   public List<Courses> GetAllCourses()
   {
      return new List<Courses>(_courses);
   }
    
   public List<Courses> GetTeacherCourses(Teachers teacher)
   {
      var result = new List<Courses>();
      foreach (var course in _courses)
      {
         if (course.Teacher == teacher)
         {
            result.Add(course);
         }
      }
      return result;
   }
}