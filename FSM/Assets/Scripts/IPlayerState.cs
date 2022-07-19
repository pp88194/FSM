using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState<Player>
{
    public Player Instance { get; set; }

    public void OnEnter(Player player)
    {
        Instance = player;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        if(Instance.Dir != Vector2.zero)
        {
            Instance.SetState(new PlayerMoveState());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Instance.SetState(new PlayerRollState());
    }
}

public class PlayerMoveState : IState<Player>
{
    public Player Instance { get; set; }

    public void OnEnter(Player player)
    {
        Instance = player;
        Instance.Anim.SetBool("isMove", true);
    }

    public void OnExit()
    {
        Instance.Anim.SetBool("isMove", false);
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Instance.SetState(new PlayerRollState());
        if (Instance.Dir == Vector2.zero)
            Instance.SetState(new PlayerIdleState());
        Instance.transform.position += (Vector3)Instance.Dir * Instance.MoveSpeed * Time.deltaTime;
        if(Instance.Dir.x != 0)
            Instance.m_SpriteRenderer.flipX = Instance.Dir.x < 0;
    }
}

public class PlayerRollState : IState<Player>
{
    public Player Instance { get; set; }

    IEnumerator C_Roll()
    {
        Instance.Anim.SetBool("isRoll", true);
        Vector2 begin = Instance.transform.position;
        Vector2 target = begin + Instance.Dir * 2;
        for(float t = 0; t < 0.5f; t += Time.deltaTime)
        {
            Instance.transform.position = Vector2.Lerp(begin, target, t * 2);
            yield return null;
        }
        Instance.Anim.SetBool("isRoll", false);
        Instance.SetState(new PlayerIdleState());
    }
    public void OnEnter(Player player)
    {
        Instance = player;
        Instance.StartCoroutine(C_Roll());
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
}
public class PlayerAttackState : IState<Player>
{
    public Player Instance { get; set; }

    public void OnEnter(Player player)
    {
        Instance = player;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
}