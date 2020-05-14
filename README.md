# Gamedev-07-q2
Contains the second question (adding dramatic components): gamedev-5780

Created by:

Yotam dafna

Tomer hazan

# Game description: 
A car game, where the player's goal is to evade the cars coming towards him over time.

As time goes on, the speed of the cars coming in his direction increases.

If the player takes a shield he will be protected for 10 seconds.

# picture of the game 

# The player

The player movement is Left or Right (using the arrows keys).

* Left key – the player will move left. 

* Right key – the player will move right.

This code is for player movement:
```
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
```
