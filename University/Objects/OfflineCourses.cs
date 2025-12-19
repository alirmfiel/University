namespace University;

public class OfflineCourses : Courses
{
    public string Room { get; set; }
    
    public OfflineCourses(string name, string room) :  base(name)
        {
        Room = room;
        }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Аудитория: {Room}";
    }
}