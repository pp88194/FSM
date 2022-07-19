using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState<Enemy>
{
    public Enemy Instance { get; set; }

    public void OnEnter(Enemy instance)
    {
        Instance = instance;
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {

    }
}

public class EnemyMoveState : IState<Enemy>
{
    public Enemy Instance { get; set; }

    public void OnEnter(Enemy instance)
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }
}