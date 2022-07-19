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
        RaycastHit2D hit = Physics2D.CircleCast(Instance.transform.position, 5, Vector2.zero, 5, LayerMask.GetMask("Player"));
        if(hit)
        {
            Instance.target = hit.collider.GetComponent<Player>();
            Instance.SetState(new EnemyMoveState());
        }
    }
}

public class EnemyMoveState : IState<Enemy>
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
        float dist = Vector2.Distance(Instance.transform.position, Instance.target.transform.position);
        if (!Instance.target || dist > 5)
            Instance.SetState(new EnemyIdleState());
        if(dist < 0.5f)
            Instance.SetState(new EnemyAttackState());
        Vector3 dir = (Instance.target.transform.position - Instance.transform.position).normalized;
        Instance.transform.position += dir * Instance.MoveSpeed * Time.deltaTime;
    }
}

public class EnemyAttackState : IState<Enemy>
{
    public Enemy Instance { get; set; }

    IEnumerator C_Attack()
    {
        Instance.target?.SetState(new PlayerHitState());
        yield return new WaitForSeconds(1);
        Instance.SetState(new EnemyIdleState());
    }
    public void OnEnter(Enemy instance)
    {
        Instance = instance;
        Instance.StartCoroutine(C_Attack());
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }
}