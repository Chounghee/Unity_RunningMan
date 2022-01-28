using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explore : MonoBehaviour
{
    public Transform explosion_effect;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(explosion_effect, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
