# Gamedev-07-q2
Contains the second question (adding dramatic components): gamedev-5780

Created by:

**Yotam dafna**

**Tomer hazan**

# Game description: 
A car game, where the player's goal is to evade the cars coming towards him over time.

As time goes on, the speed of the cars coming in his direction increases.

If the player takes a shield he will be protected for 10 seconds.

![Game](https://user-images.githubusercontent.com/45067010/81974899-e4d44500-962e-11ea-8571-9170156c2b96.png)

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
Borders - if the player falls off the edge of the road the game is over.

![fall](https://user-images.githubusercontent.com/45067010/81975735-2a454200-9630-11ea-9179-b0a6bbff7987.png)

Here is the Code:
```
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
```

# Player Collision
There are 4 cases here:

* If the player hit another car without a shield (Game Over).

![explode](https://user-images.githubusercontent.com/45067010/81975839-4ba62e00-9630-11ea-90c7-96afce2cb383.png)

* If the player hit another car with a shield (the shield will protect the player).

* If the player hit the shield and didn't already have a shield (he will activate a shield).

![shield](https://user-images.githubusercontent.com/45067010/81975637-03870b80-9630-11ea-94fd-1b60f98664db.png)

* If the player hit the shield and he already had a shield (nothing will happend).

Here is the code:
```
        [SerializeField] CircleShieldController prefabToSpawn;
        private bool HaveShild = false;
        
        private void OnCollisionEnter(Collision collision)
        {
                if (collision.collider.tag == "Enemy" && !HaveShild)
                {
                        Debug.Log("Hit!!");
                        FindObjectOfType<GameManager>().EndGame();
                }else if (collision.collider.tag == "Enemy" && HaveShild)
                {
                        HaveShild = false;
                        Debug.Log("We have shild!!");
                }else if (collision.collider.tag == "Shield" && !HaveShild)
                {
                HaveShild = true;
                ActivateShild();
            
                }else if(collision.collider.tag == "Shield" && HaveShild)
                {
                         Debug.Log("We allready have shild");
                }
        }
        private void ActivateShild()
    {
        Debug.Log("We got a shild");
        Vector3 positionOfPlayerObject = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfPlayerObject, Quaternion.Euler(0,0,0));
    }
        
```

# The enemy (other cars)

There are three types of enemies(red, yellow, blue).

The first car of any kind will start arriving at another time.

After the first car, the rest of the cars will randomly come beetwin minimum to maximum seconds.

As time goes on, cars will be faster.

Here is the code:
```
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y + 1,
                transform.position.z);
            if (Time.timeSinceLevelLoad > startSpawn)
            {
                GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.Euler(0, -180, 0));
            }
            if (prefabToSpawn.forwardForce < 250)
            {
                prefabToSpawn.forwardForce += prefabToSpawn.forwardForce * Time.deltaTime;
            }
            if (gm.gameHasEnded == true)
            {
                prefabToSpawn.forwardForce = 50f;
            }
        }
    }
```

# Animation

When the player collides with the enemy and has no shield, there is an explosion.

![WhatsApp Image 2020-05-14 at 22 27 21](https://user-images.githubusercontent.com/45067010/82049528-244a7200-96bf-11ea-9b36-9937e8caf7c8.jpeg)


# Audio

The game has one background music:

# Link to ITCH.IO

[Racing Game](https://yotamd.itch.io/tetrisracing)
