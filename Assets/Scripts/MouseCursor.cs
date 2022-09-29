using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursor : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite leftCursor;
    public Sprite normalCursor;

    public GameObject clickEffect;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Cursor.visible = false;

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;
            if (Input.GetMouseButtonDown(0))
            {
                {
                    rend.sprite = leftCursor;
                    Instantiate(clickEffect, transform.position, Quaternion.identity);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                rend.sprite = normalCursor;
            }
        }

        if (SceneManager.GetActiveScene().name == "GameLevel" && PauseMenu.isPaused)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;

            if (Input.GetMouseButtonDown(0))
            {
                {
                    rend.sprite = leftCursor;
                    Instantiate(clickEffect, transform.position, Quaternion.identity);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                rend.sprite = normalCursor;
            }
        }
    }
}