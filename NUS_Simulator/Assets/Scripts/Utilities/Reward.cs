
enum RewardType
{
    Points,
    Productivity,
    Special
}

abstract public class Reward 
{
    protected string name; 
    public string GetName()
    {
        return this.name;
    }
    abstract public void RewardEffects(); 
}

public class Plant : Reward
{   
    public Plant()
    {
        this.name = "Plant";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(15, 0, 0);
    }
}

public class Chessboard : Reward
{
    public Chessboard()
    {
        this.name = "Chessboard";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(0, 0, 15);
    }
}

public class CoffeeMachine : Reward
{
    public CoffeeMachine()
    {
        this.name = "CoffeeMachine";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AdjustAllModulesProductivity(1.0f);
    }
}

public class MP3 : Reward
{
    public MP3()
    {
        this.name = "MP3";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(30, 0, 0);
    }
}

public class Milk : Reward
{
    public Milk()
    {
        this.name = "Milk";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(0, 15, 0);
    }
}

public class Bible : Reward
{
    public Bible()
    {
        this.name = "Bible";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AdjustAllModulesProductivity(1.5f);
    }
}

public class Tiramisu : Reward
{
    public Tiramisu()
    {
        this.name = "Tiramisu";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(20, 0, 0);
        PLAYER.AdjustAllModulesProductivity(0.5f);
    }
}

