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

    private Vector3 aimOffset;
    bool aimCd;
    bool swatCd;
    bool swat = false;


    private Color startcolor;
    //Todo:
    /*
     * Swat (sendmessage)
     */

    private void Start()
    {
        startcolor = paddle.GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        if (!swat)
        {
            transform.position = Vector2.Lerp(transform.position, (player.position + aimOffset) - new Vector3(0, 3), moveSpeed * Time.deltaTime);

            Vector3 direction = transform.position - player.position;
            Quaternion rotTarget = Quaternion.LookRotation(Vector3.forward, -direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, lookSpeed * Time.deltaTime);
            if(Vector2.Distance(paddle.transform.position, player.position) < 1)
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
        paddle.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(swatCooldown);
        paddle.GetComponent<SpriteRenderer>().color = startcolor;
        swatCd = false;
        yield return new WaitForSeconds(0.1f);
        swat = false;
    }
}
