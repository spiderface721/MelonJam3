using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPotion : MonoBehaviour
{


    [SerializeField] GameObject VFX;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(VFX, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
