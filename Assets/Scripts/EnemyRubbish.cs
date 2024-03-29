using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRubbish : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public int health = 150;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //test
    void Update()
    {
        EnemyMove();
    }


    void EnemyMove()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;
            }
            else
            {
                moveDirection = Vector3.zero;
            }

            moveDirection.Normalize();

        theRB.velocity = moveDirection * moveSpeed;

    }

    public void DamageEnemy(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
        }
    }
}
