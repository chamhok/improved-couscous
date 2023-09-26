using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isLeft;
    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);
    Quaternion rightRot = Quaternion.Euler(0, 0, 10);
    Quaternion rightRotReverse = Quaternion.Euler(0, 0, -10);
    Quaternion leftRot = Quaternion.Euler(0, 0, -25);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -155);

    private void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];

    }
    void LateUpdate()
    {
        bool isReverse = player.flipX;
        if (isLeft)
        {
            transform.localRotation = isReverse ? leftRotReverse : leftRot;
            spriter.flipY = isReverse;
            spriter.sortingOrder = isReverse ? 4 : 6;
        }
        else
        {
            transform.localPosition = isReverse ? rightPosReverse : rightPos;
            transform.localRotation = isReverse ? rightRotReverse : rightRot;
            spriter.flipX = isReverse;
            spriter.sortingOrder = isReverse ? 6 : 4;
        }
    }
}
