using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Enemy : MonoBehaviour
{
    ScoreBoard sb;
    int amountToIncrease;
    void OnParticleCollision(GameObject other)
    {
       // Debug.Log("COLIZIUNE CU INAMICUL");
        Destroy(gameObject);
       // sb.IncreaseScore(amountToIncrease);
    }
*/

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 1;
    [SerializeField] int hitPoints = 1;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    /*void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }*/

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        
        
         KillEnemy();
    
    }

    void ProcessHit()
    {
        /* GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
         hitPoints--;
         Debug.Log("I'm hit");*/
       // scorePerHit += scorePerHit;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        //scoreBoard.IncreaseScore(scorePerHit);
        //GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
       // fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}