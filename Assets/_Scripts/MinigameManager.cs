using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] int firstRunBlocks;
    [SerializeField] int normalBlocksAmount;

    public bool isHandlingPlacing;

    public int blocksAvailable;

    [SerializeField] int rounds;


    PigMovement pigMovement;
    // Start is called before the first frame update
    void Awake()
    {
        pigMovement = FindObjectOfType<PigMovement>();    
    }
    void Start()
    {
        StartCoroutine(HandleRounds(rounds));
    }

    IEnumerator HandleRounds(int rounds)
    {
        bool isFirstRun = true;
        for (int i = 0; i < rounds; i++)
        {
            isHandlingPlacing = true;
            if (!isFirstRun)
            {
                blocksAvailable += normalBlocksAmount;
            }
            else
            {
                blocksAvailable += firstRunBlocks;
                isFirstRun = false;
            }
            yield return new WaitUntil(() => isHandlingPlacing == false);
            pigMovement.DoBestMoves(1, true);
            yield return new WaitUntil(() => pigMovement.isMovingToTarget == false);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
