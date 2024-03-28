using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    private Animator fadeSysteme;

    private void Awake()
    {
        fadeSysteme = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        PlayerMovement.instance.enabled = false;
        //attendre que le joueur arrive au milieu de la porte ava,t d'actionner les animations et le changement de scene
        yield return new WaitForSeconds(0.25f);
        // bloquer les mouvements du personnage
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        // animation joueur pour la porte
        PlayerMovement.instance.animator.SetBool("Door",true);
        // Sauvegarde des données
        LoadAndSaveData.instance.SaveData();
        // fondu noir
        fadeSysteme.SetTrigger("FadeIn");
        // attente entre le changement de scene
        yield return new WaitForSeconds(1f);
        // met fin à lanimation porte
        PlayerMovement.instance.animator.SetBool("Door",false);
        // permet au joueur de bouger le personnage
        PlayerMovement.instance.enabled = true;
        // chargement de la prochaine scene
        SceneManager.LoadScene(sceneName);
    }
}
