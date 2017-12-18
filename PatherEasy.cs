using UnityEngine;
using System.Collections;

public class PatherEasy
{
    Vector2 enemyPos, playerPos;
    float espeed;
    float stepsTaken = 0;

    public PatherEasy(Vector2 playerP, Vector2 enemyP, float enemySpeed)
	{
        playerPos = playerP;
        enemyPos = enemyP;
        espeed = enemySpeed;
    }

    //Find out if the player is still in chaseing distance
    public bool inDist()
    {
        if (Vector2.Distance(enemyPos, playerPos) <= 10)
        {
            return true;
        }
        else return false;
    }

    //Get possible future position of enemy
    public Vector2 futurePos(Vector2 Dir)
    {
        Vector2 futureEnemyPos = new Vector2((enemyPos.x + (espeed * Dir.x) * Time.fixedDeltaTime), (enemyPos.y + (espeed * Dir.y) * Time.fixedDeltaTime));
        return futureEnemyPos;
    }

    //Check if future positions will collide with a wall and make a list of the only possible moves.
    public Vector2[] checkCollision(Vector2[] pos)
    {
        Vector2[] a = new Vector2[4];
        int e = 0;
        for(int i = 0; i < pos.Length; i++)
        {
            bool x = true;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(pos[i], 1);
            foreach (Collider2D col in colliders)
            {
                if (col.tag == "wall")
                {
                    x = false;
                }
            }
            if(x)
            {
                a[e] = pos[i];
                e++;
            }
        }
        return a;
    }

    //Get the cardinal direction in which the enemy will go towards 
    public Vector2 findPathDirection()
    {
        Vector2 direction, goRight, goLeft, goDown, goUp;
        float stepsPlus, hueristic;
        int bestChoice = -1;
        float currentMin = 0;
        if (inDist())
        {
            goRight = futurePos(Vector2.right);
            goLeft = futurePos(Vector2.left);
            goDown = futurePos(Vector2.down);
            goUp = futurePos(Vector2.up);

            Vector2[] poses = new Vector2[] {goRight, goLeft, goDown, goUp};
            Vector2[] allowedPos = checkCollision(poses);

            if(allowedPos.Length == 0)
            {
                direction = Vector2.zero; // no place to go stop
                return direction;
            }
            for(int x = 0;x < allowedPos.Length; x++)
            {
                stepsPlus = Vector2.Distance(allowedPos[x], enemyPos);
                hueristic = Vector2.Distance(allowedPos[x], playerPos);
                if (bestChoice == -1)
                {
                    bestChoice = x;
                    currentMin = stepsPlus + hueristic + stepsTaken;
                }
                else
                {
                    if(currentMin < (stepsPlus + hueristic + stepsTaken))
                    {
                        bestChoice = x;
                        currentMin = stepsPlus + hueristic + stepsTaken;
                    }
                }
            }
            direction = allowedPos[bestChoice];
            stepsTaken += Vector2.Distance(allowedPos[bestChoice], enemyPos);
            return (direction);
        }
        else
        {
            direction = Vector2.zero; //Stop player is too far
            return (direction);
        }
    }
}
        

