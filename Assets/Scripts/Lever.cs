using System.Collections;
using UnityEngine;

public class Lever : Interactable
{
    bool interacted = false;
    bool doorOpened = false;
    bool audioPlayed = false;
    Animator animator;
    Collider boxCollider;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioClip sfxDoor;
    [SerializeField] Animator doorAnimator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<Collider>();
        interacted = false;
        doorOpened = false;
        audioPlayed = false;
    }
    private void Update()
    {
        if (interacted == true)
        {
            StartCoroutine(waitForLever());
            if (doorOpened == true)
            {
                StartCoroutine(destroyDoor());
            }
        }

    }
    protected override void Interact()
    {
        animator.Play("LeverDown");
        Destroy(boxCollider);
        interacted = true;
    }

    bool isAnimationStatePlaying(Animator anim, int animLayer, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) && anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    IEnumerator waitForLever()
    {
        yield return new WaitForSeconds(1);
        //doorAnimator.Play("OpenDoor");
        doorAnimator.SetTrigger("open");
        if (audioPlayed == false)
        {
            sfxSource.PlayOneShot(sfxDoor);
            audioPlayed = true;
        }
        if (isAnimationStatePlaying(doorAnimator, 0, "OpenDoor") == false)
        {
            doorOpened = true;
        }

    }

    IEnumerator destroyDoor()
    {
        yield return new WaitForSeconds(2);
        //doorAnimator.enabled = false;
        doorAnimator.gameObject.SetActive(false);
    }

}
