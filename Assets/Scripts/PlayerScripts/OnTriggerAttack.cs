using UnityEngine;

public class OnTriggerAttack : MonoBehaviour
{
    public WeaponBase attackTrigDelay;
    public GameObject MetalPipe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack()
    {

        Animator anim = MetalPipe.GetComponent<Animator>();
        anim.SetTrigger("Attack");

    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " hit " + other.gameObject.name);
        //Destroy(gameObject);
    }
}
