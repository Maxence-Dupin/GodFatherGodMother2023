using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minigame : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Slider sliderBalance;
    [SerializeField] TMP_Text meter;
    [SerializeField] GameObject ui;

    public DeplacementBrasDroit droit;
    public DeplacementBrasGauche gauche;

    [SerializeField] AudioClip Win;
    [SerializeField] AudioClip Loose;


    private bool playerLeft, countdownStart, up, left, right, down = false;

    private float countdown = 10.0f;

    void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
        sliderBalance.maxValue = 80;
        sliderBalance.value = 40;
    }

    void Update()
    {
        //reset timer
        if (!countdownStart && countdown != 10.0f)
        {
            countdown = 10.0f;
        }

        //update
        if (countdownStart)
        {
            sliderBalance.value += Time.deltaTime * Random.Range(-150, 150);
            countdown -= Time.deltaTime;
            meter.text = countdown.ToString("F1");
            droit.GetComponent<DeplacementBrasDroit>().enabled = false;
            gauche.GetComponent<DeplacementBrasGauche>().enabled = false;
        }

        #region Player Left
        if (playerLeft)
        {
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

            if (Input.GetKeyDown(KeyCode.Keypad4) && countdownStart) 
            {
                sliderBalance.value -= 5;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) && countdownStart)
            {
                sliderBalance.value += 5;
            }
        }
        #endregion

        #region Player Right
        if (!playerLeft)
        {
            if (Input.GetKeyDown(KeyCode.Keypad8) && countdown > 0)
            {
                if (!up && !down)
                {
                    Up();
                    SetCharge();
                }
            }
            if (Input.GetKeyDown(KeyCode.Keypad4) && countdown > 0)
            {
                if (!left && !right)
                {
                    Left();
                    SetCharge();
                }
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) && countdown > 0)
            {
                if (!left && !right)
                {
                    Right();
                    SetCharge();
                }
            }
            if (Input.GetKeyDown(KeyCode.Keypad5) && countdown > 0)
            {
                if (!up && !down)
                {
                    Down();
                    SetCharge();
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && countdownStart)
            {
                sliderBalance.value -= 5;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && countdownStart)
            {
                sliderBalance.value += 5;
            }
        }
        #endregion

        //win
        if (slider.value >= 100)
        {
            AudioManager.Instance.ChangerAudio(Win);
            countdownStart = false;
            droit.GetComponent<DeplacementBrasDroit>().enabled = true;
            gauche.GetComponent<DeplacementBrasGauche>().enabled = true;
            ui.SetActive(false);

        }

        //fail
        if ((countdown <= 0 || sliderBalance.value <= 0 || sliderBalance.value >= 100) && countdownStart)
        {
            AudioManager.Instance.ChangerAudio(Loose);
            countdownStart = false;
            droit.GetComponent<DeplacementBrasDroit>().enabled = true;
            gauche.GetComponent<DeplacementBrasGauche>().enabled = true;
            ui.SetActive(false);
        }

    }

    //Start
    public void StartMix(bool isLeft)
    {
        if (isLeft)
            playerLeft = true;
        else
            playerLeft = false;

        ui.SetActive(true);
        countdownStart = true;
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