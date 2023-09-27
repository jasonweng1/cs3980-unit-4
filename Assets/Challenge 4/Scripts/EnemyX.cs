using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private int waveCount;
    private float moreSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        playerGoal = GameObject.Find("Player Goal");

        GameObject spawnManagerObject = GameObject.Find("Spawn Manager");
        SpawnManagerX spawnManager = spawnManagerObject.GetComponent<SpawnManagerX>();
        waveCount = spawnManager.waveCount;
    }

    // Update is called once per frame
    void Update()
    {
        moreSpeed = speed * (waveCount - 1);

        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * moreSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
