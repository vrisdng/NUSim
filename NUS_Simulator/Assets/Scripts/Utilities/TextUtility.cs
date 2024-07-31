using UnityEngine;
using TMPro;

public static class TextUtility
{
    public static void AddAchievement(ref string text, bool condition, string achievement)
    {
        if (condition)
        {
            text += achievement + "\n";
        }
    }

    public static void DisplayAchievements(TextMeshProUGUI achievementText, float gpa, float mentalPoints, float physicalPoints, float socialPoints)
    {
        string text = "";
        AddAchievement(ref text, gpa >= 5.0f, "Dean's List");
        AddAchievement(ref text, mentalPoints >= 100, "Zen Mode");
        AddAchievement(ref text, physicalPoints >= 100, "Fitness Freak");
        AddAchievement(ref text, socialPoints >= 100, "Social Butterfly");

        if (text == "") 
        {
            Utils.SetText(achievementText, "No Achievements Unlocked \n"); 
        }

        Utils.SetText(achievementText, text); 
    }
}
