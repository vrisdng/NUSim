using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

public class TestCharacterCreation 
{
    private CreateCharacterScript createCharacterScript;
    private TMP_InputField inputField;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Load the scene containing your game components
        SceneManager.LoadScene("CreateCharacterScene");

        // Wait for the scene to load
        yield return null;

        // Find and set references to CreateCharacterScript
        createCharacterScript = GameObject.FindObjectOfType<CreateCharacterScript>();
        Assert.IsNotNull(createCharacterScript, "CreateCharacterScript not found in the scene.");

        // Find and set references to other necessary GameObjects and components
        inputField = createCharacterScript.inputField;
        Assert.IsNotNull(inputField, "InputField not assigned in CreateCharacterScript.");
    }

    [UnityTest]
    public IEnumerator TestCharacterCreationFlow()
    {
        // Simulate starting the quiz
        createCharacterScript.OnStartQuiz();

        // Simulate entering a name
        string playerName = "Test Player";
        inputField.text = playerName;
        createCharacterScript.OnNameSubmit();
        // Additional assertions can be added as needed

        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up
        Object.Destroy(createCharacterScript.gameObject);
        // Optionally, you may need to destroy other references as well
    }
}
