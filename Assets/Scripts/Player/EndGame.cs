using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

   
   

    IEnumerator fade()
    {
       
        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(FindObjectOfType<PlayerController>().getNumKeys() == 3)
        {
            StartCoroutine("fade");
        }
        
        
        
       
    }
}
