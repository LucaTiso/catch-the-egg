using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CestinoController : MonoBehaviour
{
    
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Rigidbody2D rb;

    private float xTarget=0f;

    void Update()
    {

        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        xTarget = mousePositionWorld.x > gameManager.RightBound ? gameManager.RightBound : mousePositionWorld.x < gameManager.LeftBound ? gameManager.LeftBound: mousePositionWorld.x;
    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(new Vector2(xTarget,transform.position.y));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        this.gameManager.AddScore();
    }


}
