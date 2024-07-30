using System.Collections.Generic;
using UnityEngine;

public static class Grade
{
    public static string RandomGradeGenerator(float progress)
    {
        var gradeProbabilities = GetGradeProbabilities(progress);
        float randomValue = Random.value;
        float cumulativeProbability = 0f;

        foreach (var gradeProbability in gradeProbabilities)
        {
            cumulativeProbability += gradeProbability.Value;
            if (randomValue <= cumulativeProbability)
            {
                return gradeProbability.Key;
            }
        }

        return "F";
    }

    public static float GradeToScore(string grade)
    {
        switch (grade)
        {
            case "A": return 5.0f;
            case "B": return 3.5f;
            case "C": return 2.0f;
            case "D": return 1.0f;
            case "F": return 0.0f;
            default: return 0.0f;
        }
    }

    public static float CalculateAverageGrade(List<string> grades)
    {
        float totalScore = 0f;
        foreach (string grade in grades)
        {
            totalScore += GradeToScore(grade);
        }
        return totalScore / grades.Count;
    }

    private static Dictionary<string, float> GetGradeProbabilities(float progress)
    {
        if (progress >= 0 && progress <= 20)
        {
            return new Dictionary<string, float>
            {
                { "D", 0.10f },
                { "F", 0.90f }
            };
        }
        else if (progress >= 20 && progress < 45)
        {
            return new Dictionary<string, float>
            {
                { "C", 0.50f },
                { "D", 0.50f }
            };
        }
        else if (progress >= 45 && progress < 75)
        {
            return new Dictionary<string, float>
            {
                { "A", 0.10f },
                { "B", 0.90f },
                { "C", 0.10f }
            };
        }
        else if (progress >= 75)
        {
            return new Dictionary<string, float>
            {
                { "A", 0.95f },
                { "B", 0.05f }
            };
        }

        return new Dictionary<string, float>();
    }
}
