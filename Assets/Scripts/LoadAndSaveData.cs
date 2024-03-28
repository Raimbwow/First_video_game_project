using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        instance = this;
    }

    void Start() 
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinCount", 0);
        Inventory.instance.UpdateTextUI(); 
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinCount", Inventory.instance.coinsCount);
    }
}
