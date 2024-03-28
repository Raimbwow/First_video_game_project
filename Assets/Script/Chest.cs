using UnityEngine.UI;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
    public AudioClip soundToPlay;

    void Awake()
    {
        // Met texte pour intéragir dans la variable
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        //appel la fonction pour ouvrir le coffre si le joueur appui sur E et si il est dans la zone du coffre
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        // Permet d'activer l'animation du coffre
        animator.SetTrigger("OpenChest");
        // Ajoute les pièces dans l'inventaire
        Inventory.instance.AddCoins(coinsToAdd);
        //Joue le son 
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        // Désactive le BoxCollider afin que l'on puisse pas "ouvrir" le coffre plrs fois
        GetComponent<BoxCollider2D>().enabled = false;
        // Enlève le texte d'intéraction
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On verifie que c'est bien le joueur qui est dans le box collider
        if(collision.CompareTag("Player"))
        {
            // On affiche le msg d'intéraction
            interactUI.enabled = true;
            // on sauvergarde le faite que le joueur est dans le box collider
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // On enlève le  msg
            interactUI.enabled = false;
            // Le joueur n'est plus dans collider
            isInRange = false;
        }
    }
}   

