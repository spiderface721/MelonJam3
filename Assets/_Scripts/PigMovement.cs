using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    [SerializeField] float movementDistanceSides;

    [SerializeField] float movementDistanceTopBottomX;
    [SerializeField] float movementDistanceTopBottomY;

    [SerializeField] int moveDir;    //1 - left, rest clockwise

    void RandomizeDir()
    {
        moveDir = Random.Range(1, 7);      
    }
    void MoveToMoveDir()
    {
        Debug.Log(moveDir);
        switch (moveDir)
        {
            case 1:
                MoveInDirIfPossible(new Vector2(-movementDistanceSides, 0f));
                break;
            case 2:
                MoveInDirIfPossible(new Vector2(-movementDistanceTopBottomX, movementDistanceTopBottomY));
                break;
            case 3:
                MoveInDirIfPossible(new Vector2(movementDistanceTopBottomX, movementDistanceTopBottomY));
                break;
            case 4:
                MoveInDirIfPossible(new Vector2(movementDistanceSides, 0));
                break;
            case 5:
                MoveInDirIfPossible(new Vector2(movementDistanceTopBottomX, -movementDistanceTopBottomY));
                break;
            case 6:
                MoveInDirIfPossible(new Vector2(-movementDistanceTopBottomX, -movementDistanceTopBottomY));
                break;
            default:
                Debug.LogError("MOVE DIRECTION NUMBER NOT IDenTIFIED");
                break;
        }

    }

    bool MoveInDirIfPossible(Vector3 newVector)
    {
        if (!CheckForBlocks(newVector.normalized))
        {
            transform.position += newVector;    //MOVE
            return true;
        }
        else
        {
            Debug.Log("HIT A WALL CANT MOVE LOL");
            return false;
        }
    }

    bool CheckForBlocks(Vector2 raycastRotation)
    {
        int layer_mask = LayerMask.GetMask("Block");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(raycastRotation), 10f, layer_mask);
        if (hit)
        {
            return true;
        }
        else
        {
            Debug.Log("NO HIT");
            return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //CheckForBlocks(Vector2.right);
        //moveDir = 6;
        MoveToMoveDir();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
