using UnityEngine;

public class EyePickupLogic : MonoBehaviour
{

    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioClip audioClip;
    public int eyeCounter = 0;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Eye")
        {
            sfxSource.PlayOneShot(audioClip);
            if (hit.gameObject.name == "1/8")
            {
                hit.gameObject.SetActive(false);
                eyeCounter += 8;
            }
            if (hit.gameObject.name == "1/32")
            {
                hit.gameObject.SetActive(false);
                eyeCounter += 2;
            }
            if (hit.gameObject.name == "1/16")
            {
                hit.gameObject.SetActive(false);
                eyeCounter += 4;
            }
            if (hit.gameObject.name == "1/4")
            {
                hit.gameObject.SetActive(false);
                eyeCounter += 16;
            }
            if (hit.gameObject.name == "1/64")
            {
                hit.gameObject.SetActive(false);
                eyeCounter += 1;
            }
            if (hit.gameObject.name == "1/2")
            {
                hit.gameObject.SetActive(false);
                eyeCounter += 32;
            }

        }
    }
}
