using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAI : MonoBehaviour
{
    [SerializeField] int samples;
    [SerializeField] int movesPerSample;

    [SerializeField] List<int> bestSequence = new List<int>();
    [SerializeField] List<int> currentSequence = new List<int>();

    [SerializeField] float bestClosestDst = 9999999f;
    [SerializeField] float closestDst = 9999999f;

    [SerializeField] bool hasFoundEnd = false;

    [SerializeField] GameObject ghostPig;

    public List<GameObject> listOfEdgeTiles = new List<GameObject>();

    PigMovement pigMovement;
    // Start is called before the first frame update
    void Start()
    {
        pigMovement = GetComponent<PigMovement>();
        ghostPig = transform.GetChild(0).gameObject;
        if (ghostPig.name != "Ghost Pig")
            Debug.LogError("GHOST PIG IS NOT NAMED GHOST PIG DUUUUDE!");
        FindBestSequence();
    }

    void FindBestSequence()
    {
        bool isFirstRun = true;
        for (int i = 0; i < samples; i++)
        {
            currentSequence.Clear();
            ghostPig.transform.position = transform.position;
            for (int j = 0; j < movesPerSample && !hasFoundEnd; j++)
            {
                Debug.Log("J");
                int currentDir;
                currentDir = pigMovement.RandomizeDir();
                if (pigMovement.MoveToMoveDir(ghostPig.transform))
                {
                    currentSequence.Add(currentDir);

                    foreach (GameObject go in listOfEdgeTiles)
                    {
                        if (Vector2.Distance(ghostPig.transform.position, go.transform.position) < closestDst)
                        {
                            closestDst = Vector2.Distance(ghostPig.transform.position, go.transform.position);
                        }
                    }
                    if (closestDst < 0.5f)
                    {
                        hasFoundEnd = true;
                    }
                }
            }
                Debug.Log(currentSequence.Count);
                Debug.Log(bestSequence.Count);
            if (currentSequence.Count < bestSequence.Count || isFirstRun)
            {
                bestClosestDst = closestDst;
                bestSequence = currentSequence;
                if (isFirstRun)
                {
                    isFirstRun = false;
                }
            }
            else if (currentSequence.Count == bestSequence.Count)
            {
                Debug.Log("YEP");
                if (closestDst < bestClosestDst)
                {
                    bestClosestDst = closestDst;
                    bestSequence = currentSequence;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
