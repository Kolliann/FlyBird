using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Coins : MonoBehaviour
{
    [FormerlySerializedAs("")]
    public GameObject CoinsPrefab;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            //If the bird hits the trigger collider in between the columns then
            //tell the game control that the bird scored
            GameController.Instance.CoinsScore();
        
            CoinsPrefab.SetActive(false);
            
        }
            
    }
}
