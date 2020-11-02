using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]  GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;

    void Start()
    {
        AddBoxColider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxColider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


    void OnParticleCollision(GameObject others)
    {

        // added Score Card
        // added Score Card 1

        scoreBoard.ScoreHit(scorePerHit);
      GameObject fx =  Instantiate(deathFX, transform.position, Quaternion.identity);
      fx.transform.parent = parent;
         Destroy(gameObject);
    }
}
