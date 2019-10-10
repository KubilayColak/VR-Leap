using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceMechanim : MonoBehaviour
{

    public static string[] Sequence = { "BOX", "IOU", "ALONE", "FIRE", "B4" };
    public static string PlayerSequence = "";
    public static string PuzzleSequence = "";
    public static string Validation = "";
    FloatingLetters FL;
    public static bool doOnce;
    float Timer = 3f;
    float timerReset;
    float delay;
    bool haha = false;
    public bool puzz1 = false;
    public bool testrun = false;
    CandleBreak Fire;

    void Start()
    {
        FL = FindObjectOfType<FloatingLetters>();
        Fire = FindObjectOfType<CandleBreak>();
    }

    public void UpdateSequence(string puzz)
    {
        PuzzleSequence = puzz;
    }

    public void SetPlayerNum(string num)
    {
        PlayerSequence = num;
    }

    void Update()
    {
        //checks matched sequences in list
        foreach (var item in Sequence)
        {
            if (string.Equals(item, PuzzleSequence))
            {
                Validation = "Correct";
                timerReset += Time.deltaTime;
                if (timerReset >= 2f)
                {
                    PuzzleSequence = "";
                    Validation = "";
                    timerReset = 0;
                    haha = true;
                }
                if (haha)
                {
                    break;
                }
                if (PuzzleSequence.Contains("A" + "6"))
                {
                    puzz1 = true; 
                }
                if (PuzzleSequence.Contains("FIRE"))
                {
                    //lights fire on candle
                    Fire.flame.Play();
                }
            }
            //stops sequence exceeding max letters
            else if(PuzzleSequence.Length >= 5)
            {
                Validation = "Try Again, Look for clues";
                timerReset += Time.deltaTime;
                if(timerReset >= 4)
                {
                    PuzzleSequence = "";
                    Validation = "";
                    timerReset = 0;
                }
            }
        }
        
        Timer += Time.deltaTime;
        if (!doOnce)
        {
            CurrentSequence();
            doOnce = true;
        }
    }
    //shorts delay between each letter sequence - prevent dobule letters
    void CurrentSequence()
        {
            if (Timer >= 2)
            {
                PuzzleSequence = PuzzleSequence + PlayerSequence;
                FL.AddLetter(PlayerSequence);
                Timer = 0;
            }
        }

    //    public void DeleteWord()
    //    {
    //        if (PuzzleSequence.Length > 1)
    //        {
    //            PuzzleSequence = PuzzleSequence.Remove(1, PuzzleSequence.Length - 1);
    //            delay = 0;
    //        }
    //    if (PuzzleSequence.Length == 1)
    //    {
    //        delay += Time.deltaTime;
    //        if (delay >= 3)
    //        {
    //            PuzzleSequence = "";
    //            delay = 0;
    //        }
    //    }
    //}
    }
