using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody[] _rbs;

    [SerializeField] private bool _SetRagdoll;

    private void Awake()
    {
        SetRagdoll = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SetRagdoll = true;

        SetRagdoll = _SetRagdoll;

    }

    public bool SetRagdoll
    {
        set
        {
            var toConstrains = value ? RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;

            animator.enabled = !value;

            foreach (var item in _rbs)
            {
                item.constraints = toConstrains;
            }
        }
    }
}