
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
        PLAYER.AdjustAllModulesProductivity(0.2f);
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
        PLAYER.AdjustAllModulesProductivity(0.5f);
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

public class Pills : Reward
{
    public Pills()
    {
        this.name = "Pills";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(0, 15, 0);
        PLAYER.AdjustAllModulesProductivity(0.5f);
    }
}

public class Calculator : Reward
{
    public Calculator()
    {
        this.name = "Calculator";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AdjustAllModulesProductivity(0.2f);
    }
}

public class Dumbbell : Reward
{
    public Dumbbell()
    {
        this.name = "Dumbbell";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(0, 0, 30);
    }
}

public class Notes : Reward
{
    public Notes()
    {
        this.name = "Notes";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AddPoints(0, 0, 30);
    }
}

public class PYP : Reward
{
    public PYP()
    {
        this.name = "PYP";
    }
    public override void RewardEffects()
    {
        Student PLAYER = Student.Instance;
        PLAYER.AdjustAllModulesProductivity(0.2f);
    }
}

