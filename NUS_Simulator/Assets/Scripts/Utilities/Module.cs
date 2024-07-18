using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Module", menuName = "ScriptableObjects/Module", order = 2)]
public class Module : ScriptableObject
{
    public string moduleName;
    public string moduleTitle; 
    public float moduleDifficulty;
    public string moduleType;
    public string moduleDepartment; 
    public int moduleCredit;

    public Button moduleButton;

    public float moduleProgress = 0.0f;

    public bool isStudying = false;
    public bool isCompleted;

    public Module(string name, string type, float difficulty)
    {
        this.moduleName = name;
        this.moduleType = type;
        this.moduleProgress = 0.0f;
        this.moduleDifficulty = difficulty;
    }

    public string GetModuleName()
    {
        return this.moduleName;
    }

    public float GetModuleDifficulty()
    {
        return this.moduleDifficulty;
    }

    public void SetStatus(bool isStudying)
    {
        this.isStudying = isStudying;
    }

    public bool IsStudying()
    {
        return this.isStudying;
    }

    public bool IsCompleted()
    {
        return this.isCompleted;
    }

    public void SetCompleted(Boolean boolian)
    {
        this.isCompleted = boolian;
    }

    public void AddToProgress(float progress)
    {
        this.moduleProgress += progress;
        if (this.moduleProgress >= 100.0f)
        {
            this.isCompleted = true;
        }
    }

    public float GetProgress()
    {
        return this.moduleProgress;
    }

    public void SetProgress(float progress)
    {
        this.moduleProgress = progress;
    }

    public void ResetProgress()
    {
        this.moduleProgress = 0.0f;
        this.isCompleted = false;
    }
}