using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")]  [SerializeField]  float levelLoadDelay = 1f;

    [Tooltip("Fx prefab on player")] [SerializeField] private GameObject deathFX;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene",levelLoadDelay);
    }

   private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");

    }

   private void ReloadScene()
   {
       SceneManager.LoadScene(1);
   }
    
}
