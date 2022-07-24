using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;

    [SerializeField] bool isEdge;

    MinigameManager minigameManager;
    // Start is called before the first frame update
    void Awake()
    {
        minigameManager = FindObjectOfType<MinigameManager>();    
    }
    void Start()
    {
        CheckIfEdge();
        if (isEdge)
        {
            FindObjectOfType<PigAI>().listOfEdgeTiles.Add(gameObject);
        }
    }

    public void OnClick()
    {
        if (minigameManager.blocksAvailable > 0)
        {
            Instantiate(blockPrefab, transform.position, Quaternion.identity);
            minigameManager.blocksAvailable--;
            if (minigameManager.blocksAvailable <= 0)
            {
                minigameManager.isHandlingPlacing = false;
            }
        }
        else
        {
            Debug.Log("NO BLOCKS AVAILABLEEEEEE!");
        }
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
