public class Point
{
    private float _value;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Point(float initialValue)
    {
        _value = initialValue;
    }

    public void Add(float points)
    {
        _value += points;
    }

    public void Decrement(float points)
    {
        _value -= points;
    }

}

public class MentalPoints : Point
{
    public MentalPoints(float initialValue) : base(initialValue) { }
}

public class PhysicalPoints : Point
{
    public PhysicalPoints(float initialValue) : base(initialValue) { }
}

public class SocialPoints : Point
{
    public SocialPoints(float initialValue) : base(initialValue) { }
}

