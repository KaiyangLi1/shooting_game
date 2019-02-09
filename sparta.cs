using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sparta : MonoBehaviour {

    public Rigidbody rigi;
    public Transform forwardBackward;
    public GameObject explosion;
    public Renderer rend;
    public Slider HPBar;
    public Text HPText;
    public Text scoreText;
    public GameObject gameoverText;
    public int score;
    GameObject receiver;


    float moveSpeed;
    float hori, verti;
    float maxAngularForwardBankward;

    public int health;
    bool dead;
    Vector3 movement;
	// Use this for initialization
	void Start () {
        health = 100;
        score = 0;
        dead = false;
        rigi = GetComponent<Rigidbody>();
        moveSpeed = 5;
        maxAngularForwardBankward = 45;
        receiver = GameObject.Find("SPARTA PLANE PREFAB");
        gameoverText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        hori = Input.GetAxis("Horizontal");
        verti = Input.GetAxis("Vertical");

        if ((hori < 0 && transform.localPosition.x > -6) || (hori > 0 && transform.localPosition.x < 6))
        {
            movement.x = hori * moveSpeed;
        }
        else movement.x = 0;

        if ((verti < 0 && transform.localPosition.z > -9) || (verti > 0 && transform.localPosition.z < 9))
        {
            movement.z = verti * moveSpeed;
        }
        else movement.z = 0;


        movement.y = 0;

        rigi.velocity = movement;
        forwardBackward.eulerAngles = new Vector3(0, 0, hori * maxAngularForwardBankward);
	}
    public void EnemyGetHit()
    {
        health--;
        StartCoroutine("Flash");
        HPBar.value = health;
        HPText.text = "HP: " + health + "/100";
        
        if (health <= 0)
        {
            GameObject.FindWithTag("Cam").SendMessage("Shake");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameoverText.SetActive(true);
        }

    }
    IEnumerator Flash()
    {
        rend.material.SetColor("_EmissionColor", Color.yellow);
        yield return new WaitForSeconds(0.1f);
        rend.material.SetColor("_EmissionColor", Color.black);
    }
    public void scoreAdd()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
