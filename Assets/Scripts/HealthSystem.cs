using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class HealthSystem : MonoBehaviour
{
    public Actor Owner; 
    public float currentHealth;
    public float maxHealth = 100f;
    public UnityEvent OnDeath;
    public UnityEvent OnTakeDamage;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
        if (currentHealth < 0)
        {
            OnDeath?.Invoke();
            return; 
        }    

        OnTakeDamage?.Invoke(); 
    }

    public void TakeDamage(Actor Instigator, float damageValue)
    {
        if (Instigator == Owner)
        {
            Debug.LogWarning(Instigator.name + " is hitting themselves with their own attack"); 
            // We don't damage out self with our own attacks
            return; 
        }

        currentHealth -= damageValue;
        
        if (currentHealth < 0)
        {
            OnDeath?.Invoke();
            return;
        }

        OnTakeDamage?.Invoke();
    }

    public void onDamagedTest()
    {
        Debug.Log(gameObject.name + " has been damaged");
    }

    public void DeathEventTest()
    {
        Debug.Log(gameObject.name + " is destroyed");        
    }

    public void KillObject()
    {
        Destroy(gameObject);
    }

    public void RetryLevel()
    {
      
    }
}
