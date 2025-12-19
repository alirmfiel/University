namespace University;

public class OnlineCourses : Courses
{
    public string Platform { get; set; }

    public OnlineCourses(string name, string platform) :  base(name)
        {
        Platform = platform;
        }

    public override string GetInfo()
    {
        return base.GetInfo() + $",  Platform: {Platform}";
    }
}