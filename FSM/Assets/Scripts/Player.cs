using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region º¯¼ö
    [SerializeField] float moveSpeed;
    public float MoveSpeed => moveSpeed;

    Vector2 dir;
    public Vector2 Dir => dir;

    IState<Player> curState;

    SpriteRenderer spriteRenderer;
    public SpriteRenderer m_SpriteRenderer => spriteRenderer;
    Animator anim;
    public Animator Anim => anim;
    #endregion
    public void SetState(IState<Player> state)
    {
        curState?.OnExit();
        curState = state;
        curState?.OnEnter(this);
    }
    void InputDir()
    {
        dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        SetState(new PlayerIdleState());
    }
    private void Update()
    {
        InputDir();
        curState?.OnUpdate();
    }
}