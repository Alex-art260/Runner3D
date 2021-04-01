using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _charController;
    [SerializeField] private Slider _slider;
    private Vector3 _direction;
    public float forwardSpeed;
    public float sideSpeed;
    public float jumpForce;
    public float gravity = -20;

    public bool checkCol = false;

    private void Start()
    {
        StartCoroutine(Health());
    }

    void Update()
    {
        _direction.z = forwardSpeed * _slider.value;
        _direction.y += gravity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _charController.Move(_direction * Time.fixedDeltaTime);

        MoveLeftAndRight();

        if(_charController.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void MoveLeftAndRight()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _direction.x = - sideSpeed;
            _charController.Move(_direction * Time.fixedDeltaTime);
        }
        else
        {
            _direction.x = 0;
            _charController.Move(_direction * Time.fixedDeltaTime);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _direction.x = sideSpeed;
            _charController.Move(_direction * Time.fixedDeltaTime);
        }
        else
        {
            _direction.x = 0;
            _charController.Move(_direction * Time.fixedDeltaTime);
        }
    }

    private void Jump()
    {
        _direction.y = jumpForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            checkCol = true;
            Invoke("CheckCollision", 1f);
        }

    }

    IEnumerator Health()
    {
        while (true)
        {
            if (checkCol == true)
           {
                CountHealth.countHealth -= 1;
           }
                yield return new WaitForSeconds(1f);
        }
    }

    private void CheckCollision()
    {
        checkCol = false;
    }
}
