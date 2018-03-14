using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float maxHealth;
    public Slider healthBar;

    private float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	public void Damage(float damageAmt)
    {
        currentHealth -= damageAmt;
        // Update health bar slider
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if(currentHealth <= 0)
        {
            // Play death animation here....then call Die()
            Die();
        }

        healthBar.value = currentHealth / maxHealth;
    }

    void Die()
    {
        // Play my death animation here.
        Destroy(this.gameObject);
    }
}
