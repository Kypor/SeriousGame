using UnityEngine;

public class Altar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Piuma")
        {
            Debug.Log("Giusto");
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
