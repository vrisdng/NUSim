public class Points
{
    public float mentalPoints;
    public float physicalPoints;
    public float socialPoints;
    public Points(float mentalPoints, float physicalPoints, float socialPoints)
    {
        this.mentalPoints = mentalPoints;
        this.physicalPoints = physicalPoints;
        this.socialPoints = socialPoints;
    }

    public void AddMentalPoints(float points)
    {
        mentalPoints += points;
    }
    public void AddPhysicalPoints(float points)
    {
        physicalPoints += points;
    }

    public void AddSocialPoints(float points)
    {
        socialPoints += points;
    }

    public void DecrementMentalPoints(float points)
    {
        mentalPoints -= points;
    }

    public void DecrementPhysicalPoints(float points)
    {
        physicalPoints -= points;
    }

    public void DecrementSocialPoints(float points)
    {
        socialPoints -= points;
    }

}
