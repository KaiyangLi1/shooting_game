using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public GameObject StartText;
    public GameObject explosion;
    public ParticleSystem ex;
    public Transform earth;

	// Use this for initialization
	void Start () {
        StartCoroutine("Explode");
	}
	

    
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown)
        {
            StartCoroutine("FlashStartText");
        }
        earth.Rotate(0, Time.deltaTime * 10, 0, Space.World);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

    }

    IEnumerator FlashStartText()
    {
        for(int i=0; i<5; i++)
        {
            StartText.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            StartText.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("mainscene");
    }
    bool press = false;
    IEnumerator Explode()
    {
        Instantiate(explosion, transform.position + new Vector3(3.03f, 0.76f, 30.46f), transform.rotation);
        while (!press)
        {
            ex.Play();
            yield return new WaitForSeconds(1.5f);
        }
        Destroy(explosion);
       
    }
}
