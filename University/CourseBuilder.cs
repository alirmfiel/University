namespace University;

public class CourseBuilder
{
    private string _name;
    private Teachers _teacher;

    public CourseBuilder(string name)
    {
        _name = name;
    }

    public CourseBuilder SetTeacher(Teachers teacher)
    {
        _teacher = teacher;
        return this;
    }

    public Courses Build()
    {
        var course = new Courses(_name);
        if (_teacher != null) 
        {
            course.Teacher = _teacher;
        }
        return course;
    }
    
    public OnlineCourses BuildOnline(string platform)
    {
        var course = new OnlineCourses(_name, platform);
        course.Teacher = _teacher;
        return course;
    }
    
    public OfflineCourses BuildOffline(string room)
    {
        var course = new OfflineCourses(_name, room);
        course.Teacher = _teacher;
        return course;
    }
}