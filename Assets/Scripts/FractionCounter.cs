using UnityEngine;
using System.Collections;
using TMPro;

public class FractionCounter : MonoBehaviour
{
    private EyePickupLogic eyePickupLogic;
    [SerializeField] Animator doorAnimator;
    [SerializeField] TextMeshProUGUI eyeCounterText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eyePickupLogic = FindAnyObjectByType<EyePickupLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        eyeCounterText.text = eyePickupLogic.eyeCounter.ToString() + "/ 64";
        if (eyePickupLogic.eyeCounter == 63)
        {
            doorAnimator.SetTrigger("open");
            if (isAnimationStatePlaying(doorAnimator, 0, "OpenDoor") == false)
            {
                StartCoroutine(destroyDoor());
            }
        }
    }

    IEnumerator destroyDoor()
    {
        yield return new WaitForSeconds(2);
        doorAnimator.gameObject.SetActive(false);
    }

    bool isAnimationStatePlaying(Animator anim, int animLayer, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) && anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
