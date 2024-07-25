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
    }

    void FixedUpdate() {
        for (int i = segments.Count - 1; i > 0; i--) {
            segments[i].position =  segments[i - 1].position;
        }
        this.transform.position = new Vector3 (Mathf.Round(this.transform.position.x) + direction.x,
                                                Mathf.Round(this.transform.position.y) + direction.y,
                                                0.0f);
    }

    private void grow() {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position =  segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void gameOver(){
        Destroy(this);
        Destroy(food);
        gameOverScene.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food") {
            grow();
        } else if (other.tag == "Obstacle") {
            Destroy(this);
            gameOverScene.SetActive(true);

        }
    }
}
