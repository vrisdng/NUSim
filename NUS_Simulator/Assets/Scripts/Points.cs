public class Points
{
    public int mentalPoints;
    public int physicalPoints;
    public int socialPoints;
    public Points(int mentalPoints, int physicalPoints, int socialPoints)
    {
        this.mentalPoints = mentalPoints;
        this.physicalPoints = physicalPoints;
        this.socialPoints = socialPoints;
    }

    public void AddMentalPoints(int points)
    {
        mentalPoints += points;
    }
    public void AddPhysicalPoints(int points)
    {
        physicalPoints += points;
    }

    public void AddSocialPoints(int points)
    {
        socialPoints += points;
    }
}
