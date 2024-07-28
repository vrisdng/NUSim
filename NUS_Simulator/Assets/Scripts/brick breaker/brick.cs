using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brick : MonoBehaviour
{
    public SpriteRenderer spriteRen;
    public Sprite[] states;
    public int health;

    void Awake() {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        health = this.states.Length;
        spriteRen.sprite = this.states[this.health - 1];
    }

    void hit() {
        this.health --;
        if (this.health <= 0) {
            this.gameObject.SetActive(false);
        } else {
            spriteRen.sprite = this.states[this.health - 1];
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            hit();
        }
    }
}
