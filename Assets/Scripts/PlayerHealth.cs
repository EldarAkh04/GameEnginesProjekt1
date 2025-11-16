using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public static int currentHealth;
    public HealthBar healthBar;
    public float cooldown;
    [SerializeField] AudioSource musicSource;
    public AudioClip MSound;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        cooldown += Time.deltaTime;
    }

    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var EnemyCharacter = collision.gameObject.name;
        //Debug.Log("hallo");

        
        if(EnemyCharacter == "Enemy(Clone)" && cooldown >= 2){
            musicSource.clip = MSound;
            musicSource.Play();
            TakeDamage(20);
            cooldown = 0;
        }
    }
}
