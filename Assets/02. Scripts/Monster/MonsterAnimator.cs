using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimator : MonoBehaviour
{
    [Header("Drag&Drop")]
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Init();
    }

    public void AnimationUpdate(bool isMoved)
    {
        if (isMoved)
        {
            _animator.SetBool("IsMoved", true);
        }
        else
        {
            _animator.SetBool("IsMoved", false);
        }
    }

    private void Init()
    {
        if (_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }
    }
}
