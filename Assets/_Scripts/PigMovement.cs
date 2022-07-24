using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    [SerializeField] float movementDistanceSides;

    [SerializeField] float movementDistanceTopBottomX;
    [SerializeField] float movementDistanceTopBottomY;

    [SerializeField] List<int> bestSequence = new List<int>();

    PigAI pigAI;

    public int moveDir;    //1 - left, rest clockwise

    void Start()
    {
        pigAI = GetComponent<PigAI>();
        DoBestMoves(3);
    }
    public void DoBestMoves(int movesAmount)
    {
        bestSequence = pigAI.FindBestSequence();
        for (int i = 0; i < movesAmount; i++)
        {
            Debug.Log("MOVE bih GET OUT THE WAy");
            moveDir = bestSequence[i];
            MoveToMoveDir(transform);
        }
    }
    public int RandomizeDir()
    {
        moveDir = Random.Range(1, 7);
        return moveDir;
    }
    public bool MoveToMoveDir(Transform objectsTransform)
    {
        switch (moveDir)
        {
            case 1:
                if (MoveInDirIfPossible(new Vector2(-movementDistanceSides, 0f), objectsTransform))
                    return true;
                else
                    return false;
            case 2:
                if (MoveInDirIfPossible(new Vector2(-movementDistanceTopBottomX, movementDistanceTopBottomY), objectsTransform))
                    return true;
                else
                    return false;
            case 3:
                if (MoveInDirIfPossible(new Vector2(movementDistanceTopBottomX, movementDistanceTopBottomY), objectsTransform))
                    return true;
                else 
                    return false;
            case 4:
                if (MoveInDirIfPossible(new Vector2(movementDistanceSides, 0),objectsTransform))
                    return true;
                else
                    return false;
            case 5:
                if (MoveInDirIfPossible(new Vector2(movementDistanceTopBottomX, -movementDistanceTopBottomY), objectsTransform))
                    return true;
                else
                    return false;
            case 6:
                if (MoveInDirIfPossible(new Vector2(-movementDistanceTopBottomX, -movementDistanceTopBottomY),objectsTransform))
                    return true;
                else
                    return false;
            default:
                Debug.LogError("MOVE DIRECTION NUMBER NOT IDenTIFIED");
                return false;
        }

    }

    bool MoveInDirIfPossible(Vector3 newVector, Transform objectsTransform)
    {
        if (!CheckForBlocks(newVector.normalized,objectsTransform))
        {
            objectsTransform.position += newVector;    //MOVE
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
