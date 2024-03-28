using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Animator fadeSysteme;

    private void Awake()
    {
        fadeSysteme = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();// Récupère L'animation de fondu
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//verifie que l'object qui touche le box collider soit le joueur
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSysteme.SetTrigger("FadeIn");//Permet d'activer la condition pour activer le fondu
        yield return new WaitForSeconds(1f);//attente d'une sec pour que l'écran soit noir lorsque le joueurest remplacé
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;//relmplace la position du joueur par celle du spawn
    }
}
