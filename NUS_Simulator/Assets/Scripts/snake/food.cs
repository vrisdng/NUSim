using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class food : MonoBehaviour
{
    public Text scoreText;
    public BoxCollider2D gameArea;
    private int playerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomized();
    }

    private void randomized() {
        Bounds bounds = this.gameArea.bounds;

        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        this.transform.position = new Vector3(x, y, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Snake") {
            playerScore += 1;
            scoreText.text = playerScore.ToString();
            randomized();
        }
    }
}
