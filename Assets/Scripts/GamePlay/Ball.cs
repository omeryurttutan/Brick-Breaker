
using System;
using UnityEngine;



public class Ball : MonoBehaviour
{
   
    private Brick brick;
    private float between;
    public float platformMiddle;
    private float x;
    private float angleA;
    public float ratio;
    public float ınıtSpeedBall;
    public float BallSpeed;


    private void Start()
    {
        ınıtSpeedBall = BallSpeed;
    }

    private void Update()
    {
        var nextDir = transform.forward * (BallSpeed * Time.deltaTime);
        var ray = new Ray(transform.position, nextDir.normalized);
        
        if (Physics.SphereCast(ray,0.1f,out RaycastHit hit,nextDir.magnitude))
        {
            transform.position = hit.point+(hit.normal * (transform.localScale.x * 0.5f));
            
            if (hit.collider.TryGetComponent(out Brick brick))
            {
                Reflect(hit.normal);
                BrickManager.instance.bricksList.Remove(brick);
                
                if (brick.powerUpType != PowerUpType.None)
                {
                    PowerUpManager.instance.ResumePowerUp();
                    PowerUpManager.instance.SpawnPowerUp(brick.powerUpType,hit.collider.transform.position);
                }
                Destroy(brick.gameObject);
                BrickManager.instance.CheckLevelEnd();
            }
            else if (hit.collider.TryGetComponent(out Platform platform))
            {
                platformMiddle=platform.transform.position.x;
                between=platformMiddle - hit.point.x;
                ratio = between / 0.5f;
                
                Debug.Log("between "+between);
                Debug.Log("ratio "+ratio);
                
                var angle=Mathf.Lerp(0, 60, Mathf.InverseLerp(0, 2, Mathf.Abs(between)));
                if (between>0)
                {
                   
                    
                    var directionRotX = ratio*150f;
                    transform.rotation = Quaternion.Euler(angle, 90, 0);
                    Debug.Log("x1 "+directionRotX);
                }
                if (between<0)
                {
                    var directionRotX = ratio*30f;
                    transform.rotation = Quaternion.Euler(angle*-1, 90, 0);
                    Debug.Log("x2 "+directionRotX);
                }
            }
            else if (hit.collider.TryGetComponent(out Ground ground))
            {
                BallManager.instance.ballList.Remove(this);
                Destroy(gameObject);
                GameManager.instance.CheckBallList();
            }
            else if (hit.collider.TryGetComponent(out Wall wall))
            {
                Reflect(hit.normal);
            }
            else if (hit.collider.TryGetComponent(out UnbreakableBrick unbreakableBrick))
            {
                Reflect(hit.normal);
            }
        }
        else
        {
            transform.position += nextDir;
        }
    }
    
    private void Reflect(Vector3 normal)
    {
        var NewPos = Vector3.Reflect(transform.forward, normal);
        transform.forward = NewPos;
    }
}
