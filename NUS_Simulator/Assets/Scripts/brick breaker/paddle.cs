using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Vector2 direction;
    public float speed = 300f;
    public float maxBounceAngle = 75f;
    
    void Awake() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            direction = Vector2.right;
        } else {
            direction = Vector2.zero;
        }

        
    }

    void FixedUpdate() {
        if (direction != Vector2.zero){
            myRigidBody.AddForce(direction * speed);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")){
            
            Rigidbody2D ball = collision.rigidbody;
            Collider2D paddle = collision.otherCollider;

            Vector2 ballDirection = ball.velocity.normalized;
            Vector2 contactDistance = paddle.bounds.center - ball.transform.position;

            float bounceAngle = (contactDistance.x / paddle.bounds.size.x) * maxBounceAngle;
            ballDirection = Quaternion.AngleAxis(bounceAngle, Vector3.forward) * ballDirection;

            ball.velocity = ballDirection.normalized * ball.velocity.magnitude;

            

        }
        
    }
}
