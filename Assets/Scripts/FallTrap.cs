using UnityEngine;

public class FallTrap : MonoBehaviour
{
    [SerializeField] GameObject floorTile;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            floorTile.SetActive(false);
        }
    }
}
