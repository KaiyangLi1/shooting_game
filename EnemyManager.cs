using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject Boss1;
    public GameObject Boss2;
    public sparta a;
    public GameObject Instruction;


    private void Start()
    {
        StartCoroutine("spawnEnemy");
    }
    // Use this for initialization
    

    bool spawningEnemy;
    bool spawningBoss1 = false;
    bool spawningBoss2 = false;
    IEnumerator spawnEnemy()
    {
        spawningEnemy = true;
        
        
        while(spawningEnemy)
        {
            if (a.score > 50 && a.score <60)
            {
                if(!spawningBoss1)
                {
                    Instantiate(Boss1, transform.position, transform.rotation);
                    spawningBoss1 = true;
                }
            }
            if(a.score >100 && a.score<110)
            {
                if(!spawningBoss2)
                {
                    Instantiate(Boss2, transform.position, transform.rotation);
                    spawningBoss2= true;
                }
            }
            GameObject enemy;
            int randomNum = Random.Range(1, 5);
            if (randomNum == 1)
            {
                enemy = enemy1;
            }
            else if (randomNum == 2)
            {
                enemy = enemy2;
            }
            else if (randomNum == 3)
            {
                enemy = enemy3;
            }
            else
            {
                enemy = enemy4;
            }
            Vector3 randomPosition = new Vector3(Random.Range(-7f, 7f), 0, 0);

            GameObject randomEnemy = Instantiate(enemy, transform.position + randomPosition, transform.rotation);
            randomEnemy.GetComponent<Rigidbody>().velocity = enemy.transform.forward * Random.Range(1f, 4f);
            randomEnemy.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            float randomTime = Random.Range(0.5f, 2.0f);

            yield return new WaitForSeconds(randomTime);

        }
            

    }
}
