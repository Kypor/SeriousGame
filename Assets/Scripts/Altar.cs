using UnityEngine;

public class Altar : MonoBehaviour
{
    public GameObject timeline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Piuma")
        {
            timeline.SetActive(true);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
        }
        else
        {
            Debug.Log("Sbagliato");
        }
    }
}
