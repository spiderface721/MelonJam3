using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAI : MonoBehaviour
{
    [SerializeField] int samples;
    [SerializeField] int movesPerSample;

    [SerializeField] List<int> bestSequence = new List<int>();

    [SerializeField] float bestClosestDst = 9999999f;
    [SerializeField] float closestDst = 9999999f;

    [SerializeField] List<int> currentSequence = new List<int>();
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
            closestDst = 9999999f;
            hasFoundEnd = false;
            for (int j = 0; j < movesPerSample && !hasFoundEnd; j++)
            {
                int currentDir;
                currentDir = pigMovement.RandomizeDir();
                if (pigMovement.MoveToMoveDir(ghostPig.transform))
                {
                    currentSequence.Add(currentDir);

                    foreach (GameObject go in listOfEdgeTiles)
                    {
                        Debug.Log(Vector2.Distance(ghostPig.transform.position, go.transform.position) < closestDst);
                        if (Vector2.Distance(ghostPig.transform.position, go.transform.position) < closestDst)
                        {
                            closestDst = Vector2.Distance(ghostPig.transform.position, go.transform.position);
                        }
                    }
                    if (closestDst < 0.5f)
                    {
                        hasFoundEnd = true;
                        Debug.Log("FOUND IT!!!");
                    }
                }
                else j--;
            }
            //Debug.Break();
                //Debug.Log(currentSequence.Count);
                //Debug.Log(bestSequence.Count);
            if (currentSequence.Count < bestSequence.Count || isFirstRun)
            {
                Debug.Log("I CANT SEE A DAMN THING IF IT AINT GUAP");
                bestSequence.Clear();
                bestSequence.AddRange(currentSequence);
                bestClosestDst = closestDst;
                if (isFirstRun)
                {
                    isFirstRun = false;
                }
            }
            else if (currentSequence.Count == bestSequence.Count)
            {
                Debug.Log(closestDst);
                Debug.Log(bestClosestDst);
                if (closestDst < bestClosestDst)
                {
                    Debug.Log("YEP");
                    bestSequence.Clear();
                    bestSequence.AddRange(currentSequence);
                    bestClosestDst = closestDst;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
