using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CestinoController : MonoBehaviour
{
    
    [SerializeField]
    private GameManager gameManager;

    void Update()
    {

        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float xTarget = mousePositionWorld.x > gameManager.RightBound ? gameManager.RightBound : mousePositionWorld.x < gameManager.LeftBound ? gameManager.LeftBound: mousePositionWorld.x;

        transform.position = new Vector3(xTarget, transform.position.y, transform.position.z);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        this.gameManager.AddScore();
    }


}
