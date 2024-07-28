using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Collections;


public class PointsControllerTest : MonoBehaviour
{
    private GameObject playerObject;
    private Student player;
    private PointsController pointsController;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("WorkingScene"); 
        playerObject = new GameObject();
        player = Student.Instance;
        pointsController = playerObject.AddComponent<PointsController>();
        player.SetMentalPoints(10);
        player.SetPhysicalPoints(10);
        player.SetSocialPoints(10);

        pointsController.Initialize(player);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(playerObject);
    }

    [UnityTest]
    public IEnumerator TestPointsDecrement()
    {

        //pointsController.StartDecrementPoints();

        yield return new WaitForSeconds(3f);

        Assert.AreEqual(4, player.GetMentalPoints());
        Assert.AreEqual(4, player.GetPhysicalPoints());
        Assert.AreEqual(4, player.GetSocialPoints());
    }

    [UnityTest]
    public IEnumerator TestGameOverSceneLoad()
    {
        player.SetMentalPoints(3);
        player.SetPhysicalPoints(3);
        player.SetSocialPoints(3);
        bool sceneLoaded = false;
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (scene.name == "GameOverScene")
            {
                sceneLoaded = true;
            }
        };

        // pointsController.StartDecrementPoints();

        yield return new WaitForSeconds(3f);

        Assert.IsTrue(sceneLoaded);
    }

    [UnityTest]
    public IEnumerator TestPointsArePositive()
    {
        player.SetMentalPoints(2);
        player.SetPhysicalPoints(2);
        player.SetSocialPoints(2);

        // pointsController.StartDecrementPoints();

        yield return new WaitForSeconds(2f);

        Assert.AreEqual(0, player.GetMentalPoints());
        Assert.AreEqual(0, player.GetPhysicalPoints());
        Assert.AreEqual(0, player.GetSocialPoints());
    }
}
