﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 1;
    public float speed;

    public GameObject effect;
    public GameObject explostionSound;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explostionSound, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            // player takes damage !
            other.GetComponent<Player>().health -= damage;
            //Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
        else
        {

            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            health -= damageDealer.GetDamage();
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            if (health <= 0)
            {
                Instantiate(effect, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
            Destroy(other.gameObject);
          
        }


    }
}
