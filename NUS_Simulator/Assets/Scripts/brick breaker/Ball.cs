using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public int speed = 10;

    public GameObject paddle;
    public gameLogic logic;

    private void Awake() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Debug.Log(myRigidBody.velocity.magnitude);
    }

    void FixedUpdate() {
        myRigidBody.velocity = myRigidBody.velocity.normalized * speed;
    }

    private void Start() {
        transform.position = Vector2.zero;
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        myRigidBody.AddForce(force.normalized);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Brick")) {
            logic.addScore();
        } else if (collision.gameObject.CompareTag("Death")) {
            logic.gameOver();
        }
    }
}
