using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minigame : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text meter;

    private bool countdownStart, up, left, right, down = false;

    private float countdown = 10.0f;

    void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    void Update()
    {
        if (!countdownStart && countdown != 10.0f)
        {
            countdown = 10.0f;
        }

        if (countdownStart)
        {
            countdown -= Time.deltaTime;
            meter.text = countdown.ToString();
        }

        #region Player Left
        if (Input.GetKeyDown(KeyCode.UpArrow) && countdown > 0)
        {
            if (!up && !down)
            {
                Up();
                SetCharge();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && countdown > 0)
        {
            if (!left && !right)
            {
                Left();
                SetCharge();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && countdown > 0)
        {
            if (!left && !right)
            {
                Right();
                SetCharge();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && countdown > 0)
        {
            if (!up && !down)
            {
                Down();
                SetCharge();
            }
        }
        #endregion

        #region Player Right
        if (Input.GetKeyDown(KeyCode.UpArrow) && countdown > 0)
        {
            if (!up && !down)
            {
                Up();
                SetCharge();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && countdown > 0)
        {
            if (!left && !right)
            {
                Left();
                SetCharge();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && countdown > 0)
        {
            if (!left && !right)
            {
                Right();
                SetCharge();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && countdown > 0)
        {
            if (!up && !down)
            {
                Down();
                SetCharge();
            }
        }
        #endregion

        if (countdown <= 0 && countdownStart)
        {
            countdownStart = false;
            Debug.Log("fail");
        }

    }

    public void StartMix(bool isLeft)
    {

    }

    void SetCharge()
    {
        slider.value += 5;
    }

    #region Directions
    void Up()
    {
        up = true;
        left = false;
        right = false;
        down = false;
    }

    void Left()
    {
        up = false;
        left = true;
        right = false;
        down = false;
    }

    void Right()
    {
        up = false;
        left = false;
        right = true;
        down = false;
    }

    void Down()
    {
        up = false;
        left = false;
        right = false;
        down = true;
    }
    #endregion
}