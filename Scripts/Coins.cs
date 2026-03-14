using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue = 1; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched the coin."); 
            if (CoinManager.instance != null) 
            {
                CoinManager.instance.AddCoin(coinValue); 
                Destroy(gameObject); 
            }
            else
            {
                 Debug.LogError("GameManager instance not found! Did you forget to set it up?"); 
            }
        }
    }
}