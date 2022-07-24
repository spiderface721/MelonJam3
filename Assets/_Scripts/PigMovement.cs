using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PigMovement : MonoBehaviour
{
    [SerializeField] float movementDistanceSides;

    [SerializeField] float movementDistanceTopBottomX;
    [SerializeField] float movementDistanceTopBottomY;

    [SerializeField] List<int> bestSequence = new List<int>();

    [SerializeField] Vector2 target;
    [SerializeField] bool isMovingToTarget;
    [SerializeField] float moveSpeed;
    [SerializeField] List<Vector3> targetsList = new List<Vector3>();
     
    PigAI pigAI;

    public int moveDir;    //1 - left, rest clockwise

    void Start()
    {
        pigAI = GetComponent<PigAI>();
        DoBestMoves(1);
    }

    void Update()
    {
        if (isMovingToTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetsList[0], moveSpeed * Time.deltaTime);    
            if (transform.position.x == targetsList[0].x && transform.position.y == targetsList[0].y)
            {
                targetsList.RemoveAt(0);
                if (!targetsList.Any())
                {
                    isMovingToTarget = false;
                }
            }
        }
    }
    public void DoBestMoves(int movesAmount)
    {
        bestSequence = pigAI.FindBestSequence();
        for (int i = 0; i < movesAmount; i++)
        {
            Debug.Log("MOVE bee GET OUT THE WAy");
            moveDir = bestSequence[i];
            MoveToMoveDir(transform, true);
        }
    }
    public int RandomizeDir()
    {
        moveDir = Random.Range(1, 7);
        return moveDir;
    }
    public bool MoveToMoveDir(Transform objectsTransform, bool isSlow)
    {
        switch (moveDir)
        {
            case 1:
                if (MoveInDirIfPossible(new Vector2(-movementDistanceSides, 0f), objectsTransform, isSlow))
                    return true;
                else
                    return false;
            case 2:
                if (MoveInDirIfPossible(new Vector2(-movementDistanceTopBottomX, movementDistanceTopBottomY), objectsTransform, isSlow))
                    return true;
                else
                    return false;
            case 3:
                if (MoveInDirIfPossible(new Vector2(movementDistanceTopBottomX, movementDistanceTopBottomY), objectsTransform, isSlow))
                    return true;
                else 
                    return false;
            case 4:
                if (MoveInDirIfPossible(new Vector2(movementDistanceSides, 0),objectsTransform, isSlow))
                    return true;
                else
                    return false;
            case 5:
                if (MoveInDirIfPossible(new Vector2(movementDistanceTopBottomX, -movementDistanceTopBottomY), objectsTransform, isSlow))
                    return true;
                else
                    return false;
            case 6:
                if (MoveInDirIfPossible(new Vector2(-movementDistanceTopBottomX, -movementDistanceTopBottomY),objectsTransform, isSlow))
                    return true;
                else
                    return false;
            default:
                Debug.LogError("MOVE DIRECTION NUMBER NOT IDenTIFIED");
                return false;
        }

    }

    bool MoveInDirIfPossible(Vector3 newVector, Transform objectsTransform, bool isSlow)
    {
        if (!CheckForBlocks(newVector.normalized,objectsTransform))
        {
            if (isSlow)
            {
                Debug.Log("HEY!");
                if (!targetsList.Any())
                {
                    targetsList.Add(newVector);
                }
                else
                {
                    Vector2 finalTarget;
                Debug.Log(targetsList.Count);
                    finalTarget = newVector + targetsList[targetsList.Count - 1];
                    targetsList.Add(finalTarget);         //MOVE THE REAL PIG
                }
                isMovingToTarget = true;
            }
            else
            {
                objectsTransform.position += newVector;    //TP
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckForBlocks(Vector2 raycastRotation, Transform objectsTransform)
    {
        int layer_mask = LayerMask.GetMask("Block");
        RaycastHit2D hit = Physics2D.Raycast(objectsTransform.position, objectsTransform.TransformDirection(raycastRotation), 10f, layer_mask);
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
