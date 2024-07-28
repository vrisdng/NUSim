using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistractionScript : MonoBehaviour 
{
    private Student STUDENT = Student.Instance;
    public PlayerInfoDisplay playerInfoDisplay;
    public PointsController pointsController;
    void Awake()
    {
        playerInfoDisplay.DisplayPlayerInfo();
        pointsController.Initialize(STUDENT); 
        pointsController.StartDecrementPoints();
    }
    void Update()
    {
       // 
    }
}