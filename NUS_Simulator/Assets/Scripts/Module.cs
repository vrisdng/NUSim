using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module 
{
    private string _moduleName;
    private float _moduleTime;
    private float _moduleDifficulty;

    public bool isStudying = false;

    public Module(string name, float time, float difficulty) {
        _moduleName = name;
        _moduleTime = time;
        _moduleDifficulty = difficulty;
    }

    public string GetModuleName() {
        return _moduleName;
    }   

    public float GetModuleTime() {
        return _moduleTime;
    }

    public float GetModuleDifficulty() {
        return _moduleDifficulty;
    }
}