using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]  GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    
    [SerializeField] int hits = 10;



    ScoreBoard scoreBoard ;

    void Start()
    {
        AddBoxColider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

     void AddBoxColider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


     void OnParticleCollision(GameObject others)
     {
         scoreBoard.ScoreHit(scorePerHit);
         hits = hits - 1;
         if (hits <= 1)
         {
             KillEnemy();
         }
     }

     private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
