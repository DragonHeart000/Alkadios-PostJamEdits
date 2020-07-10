﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    // constant attributes
    const int MAX_HP = 10;
    const int MOVE_SPEED_WALK = 3;
    const int MOVE_SPEED_RUN = 5;
    System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

    // dynamic attributes
    private int currentHP = 10;
    private int currentMovementSpeed = 0;
    private int currentFearLevel = 0;
    bool isDistracted = false;

    // setters and incrementers
    public void setCurrentHP(int hp) { currentHP = hp; }

    public void incrementCurrentHP(int delta) { currentHP += delta; }

    public void setCurrentMovementSpeed(int speed)
    {
        if (speed != MOVE_SPEED_RUN && speed != MOVE_SPEED_WALK)
        {
            Console.Write("Movement speed input unrecognized, please input walk or run");
        }
        currentMovementSpeed = speed;
    }

    // only walking or running, so no incrementation of speed
    //public void incrementCurrentMovementSpeed(int delta) {   currentMovementSpeed += delta;  }

    public void setCurrentFearLevel(int fear) {    currentFearLevel = fear;   }

    public void incrementCurrentFearLevel(int delta)  {    currentFearLevel += delta;  }

    // Function to that rolls to see if character becomes distracted by environment/object
    //   then runs the distraction anim and sets bool
    void rollDistract(System.Random r)
    {
        if (isDistracted) return;

        int roll = r.Next(0, 100);
        if (roll > 49)
        {
            isDistracted = true;
            Console.Write("Character has become distracted!");
            // distraction animation start to finish then reset bool
            isDistracted = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}