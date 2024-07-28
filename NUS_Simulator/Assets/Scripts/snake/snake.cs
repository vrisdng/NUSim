using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class snake : MonoBehaviour
{
    private Vector2 direction = Vector2.left;
    private List<Transform> segments;
    public Transform segmentPrefab;
    public GameObject gameOverScene;
    public GameObject food;
    public float moveTimer = 1f;
    public float moveTimerMax = 1f;
    public bool isEaten = false;

    void Start() {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            direction = Vector2.down;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
        }

        moveTimer += Time.deltaTime;
        if (moveTimer >= moveTimerMax) {
            if (isEaten) {
                grow();
                isEaten = false;
            }
                for (int i = segments.Count - 1; i > 0; i--) {
                    segments[i].position =  segments[i - 1].position;
                }
                this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + direction.x,
                                                        Mathf.Round(this.transform.position.y) + direction.y,
                                                        0.0f);
                moveTimer -= moveTimerMax;
        }
    }

    /*void FixedUpdate() {
        for (int i = segments.Count - 1; i > 0; i--) {
            segments[i].position =  segments[i - 1].position;
        }
        this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + direction.x,
                                                Mathf.Round(this.transform.position.y) + direction.y,
                                                0.0f);
    }*/

    private void grow() {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position =  segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void gameOver(){
        MinigameManager minigameManager = FindObjectOfType<MinigameManager>();
        minigameManager.AttachScore(segments.Count);
        Debug.Log(segments.Count); 
        Destroy(this);
        Destroy(food);
        gameOverScene.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food") {
            isEaten = true;         
            
        } else if (other.tag == "Obstacle") {
            Destroy(this);
            gameOverScene.SetActive(true);

        }
    }
}
