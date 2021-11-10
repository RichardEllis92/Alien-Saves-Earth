using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;

    public Animator anim;

    public int health = 150;

    public GameObject[] deathSplatters;

    public GameObject hitEffect;

    public bool shouldShoot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;

    public float shootRange;

    public SpriteRenderer theBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //test
    void Update()
    {
        EnemyMove();

        EnemyShoot();
    }


    void EnemyMove()
    {
        if (theBody.isVisible)
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

        /*if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }*/
    }

    void EnemyShoot()
    {
        if (theBody.isVisible)
        {
            if (shouldShoot && Vector3.Distance(transform.position, PlayerController.instance.transform.position) < shootRange)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        Instantiate(hitEffect, transform.position, transform.rotation);

        if (health <= 0)
        {
            Destroy(gameObject);

            int selectedSplatter = Random.Range(0, deathSplatters.Length);

            int rotation = Random.Range(0, 4) * 90;

            Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0f, 0f, rotation));
        }
    }
}
