using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovementScript : MonoBehaviour
{
    [SerializeField] private Camera _attachedCamera; //Camera, linked with character

    private CharacterController _characterController;
    private Vector3 _targetPosition;
    public Vector3 _movementVector;
    public Vector3 _input = Vector3.zero;
    private Vector3 _oldPosition;
    public float _movementSpeed = 2.0f;
    private float _characterRotationSpeed = 2.0f;
    private float _gravityFalling = -9.8f;
    //private float _gravityFalling = 0;
    private const float c_minStep = 0.00001f;
    private float _extaTime = 0;

    private Queue<Vector3> _queuedPositions;

    private bool _isStanding;

    public float Speed
    {
        set
        {
            _movementSpeed = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _queuedPositions = new Queue<Vector3>();
        _isStanding = true;
    }

    private bool _TargetReached() //returns true, if target is reached
    {
        return (transform.position.x == _targetPosition.x) && (transform.position.z == _targetPosition.z);
    }

    private bool _InTargetRange() //returns true, if target is closer, then minimal step distance
    {
        float x = transform.position.x - _targetPosition.x;
        float z = transform.position.z - _targetPosition.z;

        return (Math.Sqrt(x * x + z * z) < _characterController.minMoveDistance);
    }

    private bool _Overjumps() //returns true, if next step is too long
    {
        float x = transform.position.x - _targetPosition.x;
        float z = transform.position.z - _targetPosition.z;

        return Math.Sqrt(x * x + z * z) < _movementVector.magnitude;
    }

    private void _CheckClick() //Adds next waypoint
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = _attachedCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                    _queuedPositions.Enqueue(hit.point);
            }
        }
    }

    private void _SetInput() //Builds vector, describing movement direction
    {
        if (_isStanding)
            try
            {
                _targetPosition = _queuedPositions.Dequeue();
                _isStanding = false;
            }
            catch (InvalidOperationException)
            {
                _input = new Vector3(0, _input.y, 0);
                return;
            }

        _input = _targetPosition - transform.position;
        _input.y = 0;

        _input.Normalize();
    }

    private void _Move() //Calculates movement and does it, prevents from flying and falling
    {
        _movementVector = Vector3.zero;

        if (_input.magnitude != 0)
        {
            _FollowTheMouse();

            _ControlOrientation();
        }

        if (!_characterController.isGrounded)
            _characterController.Move(new Vector3(0, _gravityFalling * Time.deltaTime, 0));
    }

    private void _FollowTheMouse() //calculates movement and does it
    {
        _movementVector = _input * _movementSpeed;
        _movementVector = Vector3.ClampMagnitude(_movementVector, _movementSpeed);
        _movementVector *= (Time.deltaTime + _extaTime);

        Quaternion direction = Quaternion.LookRotation(new Vector3(_movementVector.x, _movementVector.y, _movementVector.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, direction, _characterRotationSpeed * Time.deltaTime);

        if (_movementVector.magnitude > _characterController.minMoveDistance) 
        {
            if (!_Overjumps())
            {
                _characterController.Move(_movementVector);
                _extaTime = 0;
            }
            else
            {
                transform.position = new Vector3(_targetPosition.x, transform.position.y, _targetPosition.z);
                _extaTime = 0;
            }
        }
        else
        {
            if(_InTargetRange())
            {
                transform.position = new Vector3(_targetPosition.x, transform.position.y, _targetPosition.z);
                _extaTime = 0;
            }
            else
                _extaTime += Time.deltaTime;
        }

        if (_TargetReached())
            _isStanding = true;
    }

    private void _ControlOrientation() //controls falling
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _CheckClick();
        _SetInput();

        _Move();
    }
}
