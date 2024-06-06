using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ModuleProgressValue", menuName = "ScriptableObjects/ModuleProgressValue", order = 2)]
public class ModuleProgressValue : ScriptableObject {
    [NonSerialized] private float progress;
    [NonSerialized] private float maxTime; 

    void OnEnable() {
        Initialize(25.0f);
    }
    public void Initialize(float maxTime) {
        this.maxTime = maxTime;
        progress = 0.0f;
        Debug.Log("Initialized progress: " + progress + "/" + maxTime);
    }

    public void SetProgress(float value) {
        progress = value;
    }

    public float GetProgress() {
        return progress;
    }

    public void SetMaxTime(float value) {
        maxTime = value;
    }

    public float GetMaxTime() {
        return maxTime;
    }

    public void ResetProgress() {
        progress = 0.0f;
    }
}
