using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyHealthData
{
    public float maxHealth;
    public Slider healthBar;
}

[System.Serializable]
public class EnemyScoreData
{
    public int scoreValue = 10;
    public ScoreController scoreCont;
}

public class EnemyHealth : MonoBehaviour {

    /*
    public float maxHealth;
    public Slider healthBar;
    */
    public EnemyHealthData enemyHealthData;
    public EnemyScoreData enemyScoreData;
    /*
    public int scoreValue = 10;
    public ScoreController scoreCont;
    */

    private float currentHealth;
    private AudioSource audioSource;


    // Define scoring

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        currentHealth = enemyHealthData.maxHealth;
	}
	
	public void Damage(float damageAmt)
    {
        currentHealth -= damageAmt;
        audioSource.Play();
        // currentHealth = currentHealh - damageAmt;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if(currentHealth <= 0)
        {
            Die();
        }

        enemyHealthData.healthBar.value = currentHealth / enemyHealthData.maxHealth;
    }

    void Die()
    {
        enemyScoreData.scoreCont.UpdateScore(enemyScoreData.scoreValue);
        Destroy(this.gameObject);
    }
}
