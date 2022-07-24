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

    private void Awake()
    {
        pigMovement = GetComponent<PigMovement>();
        ghostPig = transform.GetChild(0).gameObject;
        if (ghostPig.name != "Ghost Pig")
            Debug.LogError("GHOST PIG IS NOT NAMED GHOST PIG DUUUUDE!");
    }
    void Start()
    {
        
    }

    public float CalculateClosestEdgeDst(Transform myTransform)
    {
        float localClosestDst = 9999999;
        foreach (GameObject go in listOfEdgeTiles)
        {
            if (Vector2.Distance(myTransform.position, go.transform.position) < localClosestDst)
            {
                localClosestDst = Vector2.Distance(myTransform.transform.position, go.transform.position);
            }
        }
        return localClosestDst;
    }

    public List<int> FindBestSequence()
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
                if (pigMovement.MoveToMoveDir(ghostPig.transform, false))
                {
                    currentSequence.Add(currentDir);

                    closestDst = CalculateClosestEdgeDst(ghostPig.transform);

                    if (closestDst < 0.5f)
                    {
                        hasFoundEnd = true;
                        Debug.Log("FOUND IT!!!");
                    }
                }
                else j--;
            }
            if (currentSequence.Count < bestSequence.Count || isFirstRun)
            {
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
                if (closestDst < bestClosestDst)
                {
                    Debug.Log("YEP");
                    bestSequence.Clear();
                    bestSequence.AddRange(currentSequence);
                    bestClosestDst = closestDst;
                }
            }
        }
        if (bestClosestDst > 0.4)
        {
            Debug.LogWarning("LOOKS LIKE YOU BLOCKED HIM OUT!");
            FindObjectOfType<MinigameManager>().HandleWin();
        }
        return bestSequence;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
