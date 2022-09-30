using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swatter : MonoBehaviour
{
    public GameObject paddle;

    public Transform player;
    public float lookSpeed;
    public float moveSpeed;
    public float inaccuracy;
    public float swatCooldown;
    public UnityEvent damagePlayer;

    public GameObject wham;
    public GameObject bang;
    public GameObject splat;

    private Vector3 aimOffset;
    private Animator anim;
    private float distToPlayer;
    bool aimCd;
    bool swatCd;
    bool swat = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(delay());
    }
    void Update()
    {
        distToPlayer = Vector2.Distance(paddle.transform.position, player.position);
        if (!swat)
        {
            FindObjectOfType<AudioManager>().Play("Swat");

            transform.position = Vector2.Lerp(transform.position, (player.position + aimOffset) - new Vector3(0, 4), moveSpeed * Time.deltaTime);

            Vector3 direction = transform.position - player.position;
            Quaternion rotTarget = Quaternion.LookRotation(Vector3.forward, -direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, lookSpeed * Time.deltaTime);

            if (distToPlayer < 1.6f)
            {
                StartCoroutine(attack());
            }
            if (!aimCd)
            {
                StartCoroutine(AimError());
            }
        }
    }

    IEnumerator AimError()
    {
        aimCd = true;
        aimOffset = new Vector3(Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy));
        yield return new WaitForSeconds(Random.Range(0.2f, 3));
        aimCd = false;
    }

    IEnumerator attack()
    {
        swatCd = true;
        swat = true;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.18f);
        //Replace this with a trigger enter
        if (distToPlayer < 1.4f)
        {
            //damagePlayer.Invoke();
            Debug.Log("Hit!");
            PauseMenu.strikes += 1;
            if(PauseMenu.strikes < 3)
                Instantiate(bang, paddle.transform.position, Quaternion.identity);
            else
                Instantiate(splat, player.position, Quaternion.identity);
        }
        else
        {
            Instantiate(wham, paddle.transform.position, Quaternion.identity);
            Debug.Log("Miss!");
        }
        swatCd = false;
        yield return new WaitForSeconds(swatCooldown);
        swat = false;
    }
    IEnumerator delay()
    {
        swat = true;
        yield return new WaitForSeconds(2);
        swat = false;
    }
}
