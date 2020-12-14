using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public Healthbar healthBar;
    // Update is called once per frame
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

}
