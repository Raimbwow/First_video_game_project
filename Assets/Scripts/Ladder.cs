using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool IsInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topCollider;
    public Text interactUI;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            // descendre de l'échelle
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            return;
        }

        if(IsInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            IsInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IsInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            interactUI.enabled = false;
        }
    }
}
