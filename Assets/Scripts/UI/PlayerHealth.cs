using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image[] healthSprites;

    public void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < healthSprites.Length; i++)
        {
            if (i < currentHealth)
            {
                healthSprites[i].enabled = true;

            }
            else
            {
                healthSprites[i].enabled = false;

            }
        }
    }
}
