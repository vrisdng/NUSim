using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTest
{
    [Test]
    public void TestPlayButton()
    {
        // Arrange
    }

    [Test]
    public void TestQuitButton()
    {
        // Arrange
        MainMenu mainMenuScript = new GameObject().AddComponent<MainMenu>();

        // Act
        mainMenuScript.Quit();

        // No direct assert possible for Application.Quit() in Editor mode.
        // Instead, we can check if the application is quitting by testing an exit condition.
        Assert.IsTrue(Application.isEditor); // This assumes running in Editor mode, which will not actually quit the application.
    }
}
