using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageChange : MonoBehaviour
{
    [SerializeField] List<Sprite> images = new List<Sprite>();
    private int currImage = 0;
    
    public void nextImage() {
        currImage++;
        GetComponent<SpriteRenderer>().sprite = images[currImage];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
