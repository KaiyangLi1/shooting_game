using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    Rigidbody rigi;
    Vector3 movement;
    public enemyBullets bullet;
    public Transform nozzle;
    public GameObject explosion;
    public Renderer rend;
    public GameObject bonus;



    bool dead;
    bool movingLeft;
    public int health;
    // Use this for initialization
    void Start()
    {
        dead = false;
        rigi = GetComponent<Rigidbody>();
        StartCoroutine("comedown");
        StartCoroutine("singleShot");
        health = 1000;
    }

    IEnumerator singleShot()
    {
        while (!dead)
        {
            Instantiate(bullet, nozzle.position, nozzle.rotation);
            Instantiate(bullet, nozzle.position + new Vector3(-1f, 0, 0), nozzle.rotation);
            Instantiate(bullet, nozzle.position + new Vector3(-2f, 0, 0), nozzle.rotation);
            Instantiate(bullet, nozzle.position + new Vector3(1f, 0, 0), nozzle.rotation);
            Instantiate(bullet, nozzle.position + new Vector3(2f, 0, 0), nozzle.rotation);
            yield return new WaitForSeconds(1f);
        }
    }


    IEnumerator comedown()
    {
        int randomNum = Random.Range(0, 7);
        while (transform.position.z > randomNum)
        {
            movement.z = -2;
            rigi.velocity = movement;
            yield return null;
        }
        movement.z = 0;
        rigi.velocity = movement;
        diceRoll();
    }

    void diceRoll()
    {
        int dice = Random.Range(0, 2);
        if (dice == 0) movingLeft = true;
        else movingLeft = false;
        StartCoroutine("moving");
    }

    IEnumerator moving()
    {
        while (!dead)
        {
            movement.x = -5;
            while (movingLeft && transform.position.x > -6.5)
            {
                rigi.velocity = movement;
                yield return null;
            }

            movement.x = 5;

            while (!movingLeft && transform.position.x < 6.5)
            {
                rigi.velocity = movement;
                yield return null;
            }
            movingLeft = !movingLeft;
            yield return null;

        }
    }

    public void EnemyGetHit()
    {
        health--;

        StartCoroutine("Flash");
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            RandomBonus();
            Destroy(gameObject);

        }

    }
    public Color col;
    IEnumerator Flash()
    {
        rend.material.SetColor("_EmissionColor", col);
        yield return new WaitForSeconds(0.04f);
        rend.material.SetColor("_EmissionColor", Color.black);
    }

    void RandomBonus()
    {
        int chance = Random.Range(0, 5);
        if (chance <= 2) Instantiate(bonus, nozzle.position, nozzle.rotation);
    }

}
