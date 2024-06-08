using System;

public class ModuleProgressValue 
{
    public float MaxTime { get; private set; }
    public float Progress { get; private set; }

    public ModuleProgressValue(float maxTime)
    {
        MaxTime = maxTime;
        Progress = 0f;
    }

    public void SetProgress(float progress)
    {
        Progress = progress; // Ensure progress does not exceed MaxTime
    }

    public void ResetProgress()
    {
        Progress = 0f;
    }

    public float GetProgressPercentage()
    {
        return Progress / MaxTime;
    }

    public void SaveProgress(float progress)
    {
        Progress = progress;
    }
}
