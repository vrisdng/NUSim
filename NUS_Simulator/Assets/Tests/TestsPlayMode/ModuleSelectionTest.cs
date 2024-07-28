using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

public class ModuleManagerTests
{
    private ModuleManager moduleManager;

    [SetUp]
    public void SetUp()
    {
        GameObject moduleManagerObject = new GameObject("ModuleManager");
        moduleManager = moduleManagerObject.AddComponent<ModuleManager>();

        moduleManager.moduleButton = new GameObject().AddComponent<Button>();
        moduleManager.nextButton = new GameObject().AddComponent<Button>();
        moduleManager.nusModsAPI = new GameObject().AddComponent<NUSModsAPI>();
        moduleManager.moduleName = new GameObject().AddComponent<TextMeshProUGUI>();
        moduleManager.moduleTitle = new GameObject().AddComponent<TextMeshProUGUI>();
        moduleManager.moduleType = new GameObject().AddComponent<TextMeshProUGUI>();
        moduleManager.moduleDifficulty = new GameObject().AddComponent<TextMeshProUGUI>();
        moduleManager.moduleInfoPanel = new GameObject();
        moduleManager.takeModuleButton = new GameObject().AddComponent<Button>();
        moduleManager.goBackButton = new GameObject().AddComponent<Button>();

        moduleManager.moduleSlots = new Transform[10];
        for (int i = 0; i < 10; i++)
        {
            moduleManager.moduleSlots[i] = new GameObject().transform;
        }

        Student.Instance.SetFaculty("Computing");
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(moduleManager.gameObject);
    }

    [UnityTest]
    public IEnumerator TestLoadAvailableModules()
    {
        // Mock AssetDatabase and load modules
        moduleManager.LoadAvailableModules("ModuleType");
        
        yield return null;

        // Test that availableModules is populated correctly
        Assert.IsNotNull(moduleManager.availableModules);
        Assert.IsNotEmpty(moduleManager.availableModules);
        Assert.LessOrEqual(moduleManager.availableModules.Count, 10);
    }

    [UnityTest]
    public IEnumerator TestCreateModuleButtons()
    {
        // Add mock modules to availableModules
        for (int i = 0; i < 10; i++)
        {
            Module module = ScriptableObject.CreateInstance<Module>();
            module.moduleName = "Module " + i;
            moduleManager.availableModules.Add(module);
        }

        moduleManager.CreateModuleButtons();
        
        yield return null;

        // Check that buttons are created and attached to module slots
        foreach (var slot in moduleManager.moduleSlots)
        {
            var button = slot.GetComponentInChildren<Button>();
            Assert.IsNotNull(button);
        }
    }

    [UnityTest]
    public IEnumerator TestOnModuleButtonClick()
    {
        // Add a mock module
        Module module = ScriptableObject.CreateInstance<Module>();
        module.moduleName = "Test Module";
        module.moduleTitle = "Test Title";
        module.moduleType = "Test Type";
        module.moduleDifficulty = 5;

        Button button = Object.Instantiate(moduleManager.moduleButton);
        
        moduleManager.OnModuleButtonClick(module, button);
        
        yield return null;

        // Check that the correct information is displayed
        Assert.AreEqual(module.moduleName, moduleManager.moduleName.text);
        Assert.IsTrue(moduleManager.moduleInfoPanel.activeSelf);
    }

    [UnityTest]
    public IEnumerator TestOnTakeModuleButtonClick()
    {
        // Add a mock module
        Module module = ScriptableObject.CreateInstance<Module>();
        module.moduleName = "Test Module";

        Button button = Object.Instantiate(moduleManager.moduleButton);
        
        moduleManager.OnModuleButtonClick(module, button);
        moduleManager.OnTakeModuleButtonClick(module, button);
        
        yield return null;

        // Check that the module is added to selectedModules and button is disabled
        Assert.Contains(module, moduleManager.selectedModules);
        Assert.IsFalse(button.interactable);
    }

}
