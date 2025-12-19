using Xunit;

namespace University.Tests;

public class UniversityTest
{
    [Fact]
    public void TestCreateMathCourse()
    {
        var teacher = new Teachers("Екатерина Станиславовна");
        var course = new CourseBuilder("Математика")
            .SetTeacher(teacher)
            .BuildOffline("Аудитория 2304");
        
        Assert.Equal("Математика", course.Name);
        Assert.Equal("Екатерина Станиславовна", course.Teacher?.Name);
        Assert.IsType<OfflineCourses>(course);
    }
    
    [Fact]
    public void TestCreateOOPCourse()
    {
        var teacher = new Teachers("Николай Викторович");
        var course = new CourseBuilder("Объектно-ориентированное программирование")
            .SetTeacher(teacher)
            .BuildOnline("Zoom");
        
        Assert.IsType<OnlineCourses>(course);
        Assert.Equal("Zoom", ((OnlineCourses)course).Platform);
        Assert.Equal("Николай Викторович", course.Teacher?.Name);
    }
    
    [Fact]
    public void TestAddStudentToCourse()
    {
        var course = new Courses("Математика");
        var student = new Student("Ремнева Алиса");
        
        course.AddStudent(student);
        
        Assert.Single(course.Students);
        Assert.Equal("Ремнева Алиса", course.Students[0].Name);
    }
    
    [Fact]
    public void TestCourseServiceSingleton()
    {
        var service1 = new CourseService();
        var service2 = new CourseService();
        
        Assert.NotSame(service1, service2);
    }
    
    [Fact]
    public void TestGetCoursesByTeacher()
    {
        var service = new CourseService();
        
        var teacher1 = new Teachers("Екатерина Станиславовна");
        var teacher2 = new Teachers("Николай Викторович");
        
        var mathCourse = new Courses("Математика") { Teacher = teacher1 };
        var physicsCourse = new Courses("Физика") { Teacher = teacher2 };
        var algebraCourse = new Courses("Алгебра") { Teacher = teacher1 };
        
        service.AddCourse(mathCourse);
        service.AddCourse(physicsCourse);
        service.AddCourse(algebraCourse);
        
        var teacher1Courses = service.GetTeacherCourses(teacher1);
        
        Assert.Equal(2, teacher1Courses.Count);
        Assert.Contains(mathCourse, teacher1Courses);
        Assert.Contains(algebraCourse, teacher1Courses);
    }
    
    [Fact]
    public void TestRemoveCourse()
    {
        var service = new CourseService();
        
        var teacher = new Teachers("Екатерина Станиславовна");
        var courseToAdd = new Courses("Математика") { Teacher = teacher };
        
        service.AddCourse(courseToAdd);
        Assert.Single(service.GetAllCourses());
        
        service.RemoveCourse(courseToAdd);
        Assert.Empty(service.GetAllCourses());
    }
}