using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem instance;

    public float currentHealth;
    public float maxHealth = 100f;
    public UnityEvent OnDeath;
    public UnityEvent OnTakeDamage;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
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

    public void onDamagedTest()
    {
        Debug.Log(gameObject.name + " has been damaged");

    }

    public void DeathEventTest()
    {
        Debug.Log(gameObject.name + " is destroyed");
        Destroy(gameObject);
    }









}
