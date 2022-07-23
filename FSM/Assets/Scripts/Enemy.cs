using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoFSM<Enemy>
{
    #region  º¯¼ö
    [SerializeField] float moveSpeed = 1;
    public float MoveSpeed => moveSpeed;
    [SerializeField] float detectionDist = 3;
    public float DetectionDist => detectionDist;
    [HideInInspector] public Player target;
    #endregion
    private void Awake()
    {
        SetState(new EnemyIdleState());
    }
}
