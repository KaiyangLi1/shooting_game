using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Rigidbody rigi;
    public int speed;
    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
        speed = 100;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 100);
        if (transform.position.x < 7 && transform.position.x > -7)
        {
            if (transform.position.z > -10 && transform.position.z < 10)
            {
                rigi.velocity = new Vector3(Time.deltaTime * Random.Range(-100,100), 0, -Time.deltaTime * speed);
            }
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            GameObject.Find("SPARTA PLANE PREFAB").SendMessage("scoreAdd");
            Destroy(gameObject);
        }
       
    }
}
