using UnityEngine;

public class OnTriggerAttack : MonoBehaviour
{



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " hit " + other.gameObject.name);
        //Destroy(gameObject);
    }
}
