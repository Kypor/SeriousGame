using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject playerTP;
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
        collision.gameObject.transform.position = new Vector3(playerTP.transform.position.x, playerTP.transform.position.y, playerTP.transform.position.z);
    }
}
