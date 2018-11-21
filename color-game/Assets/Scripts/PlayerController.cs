using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rb; 
    SpriteRenderer sr;
    public Color currentColor;
    public float r, g, b;

    public float speed;

    public float moveHorizontal, moveVertical;

    // Use this for initialization
    void Awake()
    {
        r = currentColor.r; g = currentColor.g; b = currentColor.b;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent <SpriteRenderer>();
        currentColor = new Color(Random.Range(0.0f, 255.0f), Random.Range(0.0f, 255.0f), Random.Range(0.0f, 255.0f), 1.0f);
    }

    //Where most physics code will go 
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        //Movement
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = new Vector2(movement.x, movement.y);
        UpdateColor();
    }

	// Update is called once per frame
	void Update ()
    {
        
    }

    void UpdateColor()
    {
        //Moving horizontally will update the R element of the color
        if (moveHorizontal > 0)
        {
            if (currentColor.r == 1.0f)
                currentColor = new Color(0.0f, currentColor.g, currentColor.b, currentColor.a);
            else
                currentColor = new Color(currentColor.r + 0.01f, currentColor.g, currentColor.b, currentColor.a);
        }
        else if (moveHorizontal < 0)
        {
            if (currentColor.r == 0.0f)
                currentColor = new Color(1.0f, currentColor.g, currentColor.b, currentColor.a);
            else
                currentColor = new Color(currentColor.r - 0.01f, currentColor.g, currentColor.b, currentColor.a);
        }
        //currentColor = sr.color;
        //Moving vertically will update the G 
        if (moveVertical > 0)
        {
            if (currentColor.g == 1.0f)
                currentColor = new Color(currentColor.r, 0.0f, currentColor.b, currentColor.a);
            else
                currentColor = new Color(currentColor.r, currentColor.g + 0.01f, currentColor.b, currentColor.a);
        }
        else if (moveVertical < 0)
        {
            if (currentColor.g == 0.0f)
                currentColor = new Color(currentColor.r, 1.0f, currentColor.b, currentColor.a);
            else
                currentColor = new Color(currentColor.r, currentColor.g - 0.01f, currentColor.b, currentColor.a);
        }
        //sr.color = currentColor;
        r = currentColor.r; g = currentColor.g; b = currentColor.b;
    }
}
