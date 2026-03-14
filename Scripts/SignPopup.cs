using UnityEngine;
using UnityEngine.UI;

public class SignPopup : MonoBehaviour
{
    public GameObject popupObjectToShow;

    void Start()
    {
        if (popupObjectToShow != null)
        {
            popupObjectToShow.SetActive(false);
        }
        else
        {
            Debug.LogError("Popup Object To Show is not assigned on " + gameObject.name, this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupObjectToShow != null)
            {
                popupObjectToShow.SetActive(true);
                Debug.Log("Player entered sign trigger. Showing popup.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (popupObjectToShow != null)
            {
                popupObjectToShow.SetActive(false);
                Debug.Log("Player exited sign trigger. Hiding popup.");
            }
        }
    }
}