using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private UnityEvent windowScore;
    [SerializeField] private float windowCoolDown;
    [SerializeField] private GameObject bonk;
    
    private Vector2 moveDirection;

    private Animator anim;
    private bool hitWindow;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Window")
        {
            Instantiate(bonk, transform.position, Quaternion.identity);
            speed = 3.5f;
            StartCoroutine(speedTime());
            if(collision.collider.tag == "Window" && hitWindow == false)
            {
                StartCoroutine(windowCd());
                windowScore.Invoke();
            }
        }
    }

    IEnumerator speedTime ()
    {
        yield return new WaitForSeconds(2);
        speed = 7;
    }
    IEnumerator windowCd()
    {
        hitWindow = true;
        yield return new WaitForSeconds(windowCoolDown);
        hitWindow = false;
    }
}