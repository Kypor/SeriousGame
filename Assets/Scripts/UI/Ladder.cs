using UnityEngine;

public class Ladder : Interactable
{
    PlayerUI playerUI;
    PlayerMovement playerMovement;
    LadderManager ladderManager;
    private bool interaction;


    [SerializeField] float lerpSpeed = 10f;
    [SerializeField] float distance = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        ladderManager = FindAnyObjectByType<LadderManager>();
        interaction = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (interaction)
        {
            Vector3 newPosition = Vector3.Lerp(playerMovement.rb.position, transform.position, Time.deltaTime * lerpSpeed);
            playerMovement.rb.MovePosition(newPosition);
            if(Vector3.Distance(playerMovement.transform.position, transform.position) < distance)
            {
                interaction = false;
                ladderManager.onLadder = true;
            }
        }

    }

    protected override void Interact()
    {
        playerUI.UpdateText(string.Empty);
        interaction = true;

    }
}
