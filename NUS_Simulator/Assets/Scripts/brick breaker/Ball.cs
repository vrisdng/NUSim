using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float speed = 500f;
    private int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScene;

    private void Awake() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        myRigidBody.AddForce(force.normalized * speed);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Brick")) {
            playerScore += 1;
            scoreText.text = playerScore.ToString();
        } else if (collision.gameObject.CompareTag("Death")) {
            Destroy(this);
            gameOverScene.SetActive(true);
        }
    }
}
