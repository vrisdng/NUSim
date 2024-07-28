using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ModuleManagerTests : MonoBehaviour
{
    private ModuleManager moduleManager;

    [SetUp]
    public void Setup()
    {
        GameObject moduleManagerObject = new GameObject("ModuleManager");
        moduleManager = moduleManagerObject.AddComponent<ModuleManager>();

        moduleManager.moduleButton = new GameObject().AddComponent<Button>();
        moduleManager.nextButton = new GameObject().AddComponent<Button>();
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

        MockAssetDatabase();
    }

    private void MockAssetDatabase()
    {
        for (int i = 0; i < 15; i++)
        {
            var module = ScriptableObject.CreateInstance<Module>();
            module.moduleName = "Module" + i;
            module.moduleTitle = "Title" + i;
            module.moduleType = "Computing";
            module.moduleDifficulty = i * 2;
            module.moduleCredit = 4;
            module.isCompleted = (i % 2 == 0);
            module.moduleProgress = 0.0f;

            AssetDatabase.CreateAsset(module, $"Assets/ScriptableObjects/Modules/Module{i}.asset");
            AssetDatabase.SaveAssets();
        }
    }

    [Test]
    public void SetTexts_ModuleName()
    {
        if (moduleManager.availableModules.Count == 0)
        {
            moduleManager.LoadAvailableModules("Computing");
        }
        var module = moduleManager.availableModules[0];

        moduleManager.SetTexts(module);

        Assert.AreEqual(module.moduleName, moduleManager.moduleName.text);
    }

    [Test]
    public void SetTexts_ModuleTitle()
    {
        if (moduleManager.availableModules.Count == 0)
        {
            moduleManager.LoadAvailableModules("Computing");
        }
        var module = moduleManager.availableModules[0];

        moduleManager.SetTexts(module);

        Assert.AreEqual("Module's Name:  " + module.moduleTitle, moduleManager.moduleTitle.text);
    }

    [Test]
    public void SetTexts_ModuleType()
    {
        if (moduleManager.availableModules.Count == 0)
        {
            moduleManager.LoadAvailableModules("Computing");
        }
        var module = moduleManager.availableModules[0];

        moduleManager.SetTexts(module);

        Assert.AreEqual("Module's Type:  " + module.moduleType, moduleManager.moduleType.text);
    }

    [Test]
    public void SetTexts_ModuleDifficulty()
    {
        if (moduleManager.availableModules.Count == 0)
        {
            moduleManager.LoadAvailableModules("Computing");
        }
        var module = moduleManager.availableModules[0];

        moduleManager.SetTexts(module);

        Assert.AreEqual("Module's Difficulty:  " + (module.moduleDifficulty / 10).ToString(), moduleManager.moduleDifficulty.text);
    }
}
