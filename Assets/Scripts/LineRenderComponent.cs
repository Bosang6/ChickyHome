using UnityEngine;

public class LineRenderComponent : MonoBehaviour
{
    private LineRenderer lineRenderer = null;
    
    private RaycastHit hitInfo;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.loop = false;

        ResetLineRenderer();
    }
    
    private Vector3 worldPosition;
    private void Update()
    {
        // Check whether the line segment starts from the player's initial position.
        if (!GameManager.Instance.DrawingIsStarted && Input.GetMouseButton(0))
        {
            GameManager.Instance.DrawingIsStarted = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000,
                1 << LayerMask.NameToLayer("Player"));
        }
        
        // line-drawing logic
        // If the line has not been drawn yet
        if(!GameManager.Instance.LineIsDrew)
        {
            // When the left mouse button is pressed, start from the player's initial position.
            if (Input.GetMouseButton(0) && GameManager.Instance.DrawingIsStarted)
            {
                // Use raycasting to check whether the line is on the wall.
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000,
                        1 << LayerMask.NameToLayer("Wall")))
                {
                    SetLineColor(Color.red);
                }
                
                // Raycast against the y = 0 plane.
                Plane plane = new Plane(Vector3.up, new Vector3(0, 0, 0));
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (plane.Raycast(ray, out float enter))
                {
                    // Draw line
                    Vector3 worldPoint = ray.GetPoint(enter);
                    
                    lineRenderer.positionCount++;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPoint);
                }
            }
        }

        // The line segment is complete.
        if (Input.GetMouseButtonUp(0) && GameManager.Instance.DrawingIsStarted)
        {
            GameManager.Instance.LineIsDrew = true;
            GameManager.Instance.DrawingIsStarted = false;
            // Check the validity of the line
            if (lineRenderer.startColor == Color.red)
            {
                ResetLineRenderer();
            }
            else
            {
                // If the line segment is valid, change its color to green.
                SetLineColor(Color.chartreuse);
                
                // Send the line segment data to the player component.
                SendPathToPlayer();
            }
        }
    }

    private void SendPathToPlayer()
    {
        // Get path information
        Vector3[] pathPoints = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(pathPoints);
                
        // Send the line segment data to the player component.
        GameManager.Instance.player.StartMove(pathPoints);
    }

    public void ResetLineRenderer()
    {
        lineRenderer.positionCount = 0;
        SetLineColor(Color.white);
        GameManager.Instance.LineIsDrew = false;
    }

    public void SetLineColor(Color color)
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }
}
