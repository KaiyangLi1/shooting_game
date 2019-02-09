using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingGun : MonoBehaviour {

    public GameObject bullet;
    public Transform plane;
    public Transform nozzle;
    public sparta a;

	
	// Update is called once per frame
	void Update () {
        
        if(a.score < 20 )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating("singleShot", 0.01f, 0.2f);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke("singleShot");
            }
        }
        else if(a.score <50)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating("tripleShot", 0.01f, 0.2f);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke("tripleShot");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating("quintupleShot", 0.01f, 0.2f);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke("quintupleShot");
                CancelInvoke("tripleShot");
            }
            
        }
        
    }

    void singleShot()
    {
        Instantiate(bullet, nozzle.position, Quaternion.identity);
    }

    void tripleShot()
    {
        Instantiate(bullet, nozzle.position, Quaternion.identity);
        Instantiate(bullet, nozzle.position + new Vector3(-1f, 0, 0), Quaternion.identity);
        Instantiate(bullet, nozzle.position + new Vector3(1f, 0, 0), Quaternion.identity);
    }


    void quintupleShot()
    {
        Instantiate(bullet, nozzle.position, Quaternion.identity);
        Instantiate(bullet, nozzle.position + new Vector3(-1f, 0, 0), Quaternion.identity);
        Instantiate(bullet, nozzle.position + new Vector3(-2f, 0, 0), Quaternion.identity);
        Instantiate(bullet, nozzle.position + new Vector3(1f, 0, 0), Quaternion.identity);
        Instantiate(bullet, nozzle.position + new Vector3(2f, 0, 0), Quaternion.identity);
    }

    
}
