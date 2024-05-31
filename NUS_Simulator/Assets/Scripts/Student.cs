
public class Student {
    public static Student instance;
    private string name;
    private Points points;

    public Student(string name, int mentalPoints, int physicalPoints, int socialPoints)
    {
        this.name = name;
        this.points = new Points(mentalPoints, physicalPoints, socialPoints);
    }

    public static Student Instance {
        get {
            if (instance == null) {
                instance = new Student("player", 0, 0, 0);
            }
            return instance; 
        }
    }

    public void AddPoints(DistractionEvent theEvent)
    {
        this.points.AddMentalPoints(theEvent.GetMentalPoints());
        this.points.AddPhysicalPoints(theEvent.GetPhysicalPoints());
        this.points.AddSocialPoints(theEvent.GetSocialPoints());
    }

    public int GetMentalPoints() {
        return points.mentalPoints; 
    }

    public int GetPhysicalPoints() {
        return points.physicalPoints;
    }

    public int GetSocialPoints() {
        return points.socialPoints; 
    }
}
