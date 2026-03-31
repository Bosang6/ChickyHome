using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 initPos = Vector3.zero;

    private Vector3[] path = null;

    private int index = 0;

    private bool moveForward = true;

    private void Start()
    {
        initPos = this.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            GameManager.Instance.ShowExitMessage();
        
        if (path == null) return;

        if(!GameManager.Instance.GameIsOver)
            Move();
    }

    public void StartMove(Vector3[] pathPoints)
    {
        if (pathPoints == null || pathPoints.Length == 0)
            return;

        moveForward = true;
        path = pathPoints;
        index = 0;
    }

    private void Move()
    {
        if (index == path.Length && moveForward)
        {
            moveForward = false;
            GameManager.Instance.lineRenderer.SetLineColor(Color.yellow);
        }

        if (!moveForward)
        {
            index--;
        }
        
        // Change the player's position to a point on the line.
        Vector3 targetPoint = new Vector3(path[index].x, transform.position.y, path[index].z);
        this.transform.position = targetPoint;
        
        if(moveForward)
            index++;

        if (index == 0)
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        moveForward = true;
        path = null;
        this.transform.position = initPos;
        GameManager.Instance.lineRenderer.ResetLineRenderer();
    }
}
