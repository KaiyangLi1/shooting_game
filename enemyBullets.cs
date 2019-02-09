using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullets : MonoBehaviour
{
    Rigidbody rigi;

    // Use this for initialization
    public void Start()
    {
        rigi = GetComponent<Rigidbody>();
        flyingBullet();
        Invoke("destroyBullet", 5);
    }


    void flyingBullet()
    {
        rigi.velocity = transform.forward * 20;
    }
    void destroyBullet()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {   
        if(collider.tag == "Player")
        {
            collider.gameObject.SendMessage("EnemyGetHit");
            Destroy(this.gameObject);
        }
        else if(collider.tag =="bullet")
        {
            Destroy(gameObject);
        }
      
    }
}
