using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        Instantiate(blockPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
