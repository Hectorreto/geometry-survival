using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] healthSprites;

    public void UpdateHealthUI(int currentHealth)
    {
        print("si entro aqui");
        for (int i = 0; i < healthSprites.Length; i++)
        {
            if (i < currentHealth)
            {
                healthSprites[i].enabled = true;
                Debug.Log("Enabling sprite " + i);
            }
            else
            {
                healthSprites[i].enabled = false;
                Debug.Log("Disabling sprite " + i);
            }
        }
    }
}
