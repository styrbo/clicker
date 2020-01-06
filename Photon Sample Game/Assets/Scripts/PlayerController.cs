using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float RotateMultiply;

    [SerializeField] private Transform _cameraAnchor;

    private CharacterController _controller;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        Debug.Log(_anim.GetIKPosition(AvatarIKGoal.LeftFoot));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("coolide!");
    }


    private void Move()
    {
        float power = .5f;

        if (Input.GetKeyDown(KeyCode.O))
        {
            _anim.Play("Grenade", 1);
        }

        if (Input.GetKey(KeyCode.LeftShift))
            power = 1;

        if (Input.GetKey(KeyCode.W))
            _anim.SetFloat("Vertical", power);
        if (Input.GetKey(KeyCode.D))
            _anim.SetFloat("Horizontal", power);
        if (Input.GetKey(KeyCode.S))
            _anim.SetFloat("Vertical", -power);
        if (Input.GetKey(KeyCode.A))
            _anim.SetFloat("Horizontal", -power);

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            _anim.SetFloat("Vertical", 0);
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            _anim.SetFloat("Horizontal", 0);

    }
    private void Rotate()
    {
        var curEuler = transform.eulerAngles;
        var camEuler = _cameraAnchor.localEulerAngles;
        var vertical = Input.GetAxis("Mouse X");
        var horizontal = Input.GetAxis("Mouse Y");

        curEuler.y += vertical * RotateMultiply;
        camEuler.x -= horizontal * RotateMultiply;

        transform.eulerAngles = curEuler;
        _cameraAnchor.localEulerAngles = camEuler;
    }
}
