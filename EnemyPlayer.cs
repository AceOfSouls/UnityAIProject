using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{


    public bool UpAndDown;
    public float speed;
    public int seconds;
    public int radius;
    float xpos;
    float ypos;
    bool dir = true;
    float time = 0;
    bool chase = false;
    public GameObject player;
    private Rigidbody2D rb2d;
    Vector2 ppos;
    Vector2 startP;
    float timer;
    double timer2;
    RaycastHit2D hit;
    float scaleSpeed = (float)0.1;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        xpos = this.transform.position.x;
        ypos = this.transform.position.y;
        time = Time.time + seconds;
        ppos = player.transform.position;
        startP = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            ppos = player.transform.position;
            if (Vector2.Distance(ppos, this.transform.position) > radius)
            {
                if (chase)
                {
                    if (timer <= Time.time)
                    {
                        chase = false;
                        scaleSpeed = (float)0.1;
                    }
                    if (timer2 <= Time.time)
                    {
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        this.transform.localScale = theScale;
                        timer2 = Time.time + 0.2;
                        scaleSpeed = (float)0.1;
                    }
                    time = Time.time + seconds;
                }
                else if (UpAndDown)
                {
                    if (time > Time.time)
                    {
                        if (dir == true)
                        {
                            ypos -= speed;
                            this.rb2d.MovePosition(new Vector2(xpos, ypos));
                        }
                        else
                        {
                            ypos += speed;
                            //this.transform.position = new Vector2(xpos, ypos);
                            this.rb2d.MovePosition(new Vector2(xpos, ypos));
                        }
                    }
                    else
                    {
                        if (dir == true)
                        {
                            dir = false;
                        }
                        else
                        {
                            dir = true;
                        }
                        time = Time.time + seconds;
                    }
                }
                else
                {
                    if (time > Time.time)
                    {
                        if (dir == true)
                        {
                            xpos -= speed;
                            //this.transform.position = new Vector2(xpos, ypos);
                            this.rb2d.MovePosition(new Vector2(xpos, ypos));
                        }
                        else
                        {
                            xpos += speed;
                            //this.transform.position = new Vector2(xpos, ypos);
                            this.rb2d.MovePosition(new Vector2(xpos, ypos));
                        }
                    }
                    else
                    {
                        if (dir == true)
                        {
                            dir = false;
                            Vector3 theScale = transform.localScale;
                            theScale.x *= -1;
                            this.transform.localScale = theScale;
                        }
                        else
                        {
                            dir = true;
                            Vector3 theScale = transform.localScale;
                            theScale.x *= -1;
                            this.transform.localScale = theScale;
                        }
                        time = Time.time + seconds;
                    }
                }
            }
            else
            {
                if (scaleSpeed < 3.1)
                {
                    scaleSpeed += (float)0.05;
                }
                //this.transform.position = Vector2.MoveTowards(this.transform.position, ppos, speed * 2);
                this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, ppos, speed * scaleSpeed));
                ypos = startP.y;
                xpos = startP.x;
                dir = true;
                timer = Time.time + 2;
                timer2 = Time.time + 0.2;
                chase = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            hit = Physics2D.Raycast(this.transform.position, other.transform.position);
            float wallX = hit.point.x;
            float wallY = hit.point.y;
            float eX = this.transform.position.x;
            float eY = this.transform.position.y;
            if (wallX > eX && wallY > eY) // North east
            {
                // We have the two points, we need to find out which way to go given where the wall is
                // Think of it as a rectangle:
                // in this case the direction is north east
                // we have the hypotenuse since we have the point of where the enemy is and where the wall is
                // we then have two possible walls that can occur in this games case, either _| or |¯
                // thus we need the two vectors and check using a raycast which hit a wall.

                Vector2 point1 = new Vector2(wallX, eY); // this is the east point
                Vector2 point2 = new Vector2(eX, wallY); // this is the north point
                hit = Physics2D.Raycast(this.transform.position, point1, 7);
                if (hit.collider != null)
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                }
                else
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                }
            }
            else if (wallX > eX && wallY < eY) // South east
            {
                Vector2 point1 = new Vector2(wallX, eY); // this is the east point
                Vector2 point2 = new Vector2(eX, wallY); // this is the south point
                hit = Physics2D.Raycast(this.transform.position, point1, 7);
                if (hit.collider != null)
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                }
                else
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                }
            }
            else if (wallX < eX && wallY < eY) // South west
            {
                Vector2 point1 = new Vector2(wallX, eY); // this is the west point
                Vector2 point2 = new Vector2(eX, wallY); // this is the south point
                hit = Physics2D.Raycast(this.transform.position, point1, 7);
                if (hit.collider != null)
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                }
                else
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                }
            }
            else // north west
            {
                Vector2 point1 = new Vector2(wallX, eY); // this is the west point
                Vector2 point2 = new Vector2(eX, wallY); // this is the north point
                hit = Physics2D.Raycast(this.transform.position, point1, 7);
                if (hit.collider != null)
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                }
                else
                {
                    this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                }
            }

        }
    }
}

/*
 I did all this work for nothing T.T


                float wallX = hit.point.x;
                float wallY = hit.point.y;
                float eX = this.transform.position.x;
                float eY = this.transform.position.y;
                if (wallX > eX && wallY > eY) // North east
                {
                    // We have the two points, we need to find out which way to go given where the wall is
                    // Think of it as a rectangle:
                    // in this case the direction is north east
                    // we have the hypotenuse since we have the point of where the enemy is and where the wall is
                    // we then have two possible walls that can occur in this games case, either _| or |¯
                    // thus we need the two vectors and check using a raycast which hit a wall.

                    Vector2 point1 = new Vector2(wallX, eY); // this is the east point
                    Vector2 point2 = new Vector2(eX, wallY); // this is the north point
                    hit = Physics2D.Raycast(this.transform.position, point1, 7);
                    if (hit.collider != null)
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                    }
                    else
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                    }
                }
                else if (wallX > eX && wallY < eY) // South east
                {
                    Vector2 point1 = new Vector2(wallX, eY); // this is the east point
                    Vector2 point2 = new Vector2(eX, wallY); // this is the south point
                    hit = Physics2D.Raycast(this.transform.position, point1, 7);
                    if (hit.collider != null)
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                    }
                    else
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                    }
                }
                else if (wallX < eX && wallY < eY) // South west
                {
                    Vector2 point1 = new Vector2(wallX, eY); // this is the west point
                    Vector2 point2 = new Vector2(eX, wallY); // this is the south point
                    hit = Physics2D.Raycast(this.transform.position, point1, 7);
                    if (hit.collider != null)
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                    }
                    else
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                    }
                }
                else // north west
                {
                    Vector2 point1 = new Vector2(wallX, eY); // this is the west point
                    Vector2 point2 = new Vector2(eX, wallY); // this is the north point
                    hit = Physics2D.Raycast(this.transform.position, point1, 7);
                    if (hit.collider != null)
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point2, speed * scaleSpeed));
                    }
                    else
                    {
                        this.rb2d.MovePosition(Vector2.MoveTowards(this.transform.position, point1, speed * scaleSpeed));
                    }
                }
     
 */
