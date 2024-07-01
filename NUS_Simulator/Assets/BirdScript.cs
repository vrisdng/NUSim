using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("FlappyBirdLogic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive) {
            myRigidBody.velocity = Vector2.up * flapStrength;
        } 

        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        isAlive = false;
    }
}
