using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;

    [SerializeField] bool isEdge;
    // Start is called before the first frame update
    void Start()
    {
        CheckIfEdge();
    }

    public void OnClick()
    {
        Instantiate(blockPrefab, transform.position, Quaternion.identity);
    }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

    void CheckIfEdge()
    {
        for (int i = 0; i < 360; i += 50)
        {
            Debug.Log(i);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(DegreeToVector2(i)), 10f);
            if (!(hit && hit == gameObject))
            {
                isEdge = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
