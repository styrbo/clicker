using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rbs;

    private void Awake()
    {
        SetRagdoll = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SetRagdoll = true;
    }

    public bool SetRagdoll
    {
        set
        {
            var toConstrains = value ? RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;

            foreach (var item in _rbs)
            {
                item.constraints = toConstrains;
            }
        }
    }

}
