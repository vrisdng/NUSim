using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private int activeModuleIndex = -1;
    private ModuleData moduleData;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        // Initialize moduleData here or assign it through inspector
    }

    void Update() {
        if (activeModuleIndex != -1) {
            Module activeModule = moduleData.GetModule(activeModuleIndex);
            float progressSpeed = activeModule.GetModuleDifficulty(); // Assuming difficulty represents speed
            ProgressBar progressBar = FindObjectOfType<ProgressBar>();
            progressBar?.UpdateModuleProgress(progressSpeed);
        }
    }

    public void SetActiveModuleIndex(int index) {
        activeModuleIndex = index;
    }

    public void SetModuleData(ModuleData data) {
        moduleData = data;
    }
}
