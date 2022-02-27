using DG.Tweening;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] SphereCollider sphereColl;
    [SerializeField] ParticleSystem particle;
    [SerializeField] TrailRenderer trail;

    private bool isSideMoving;

    Vector3[] jumpPosition;
    Touch touch;

    private void Awake()
    {
        EventManager.OnTapScreen.AddListener(Jump);
    }

    private void Start()
    {
        jumpPosition = new Vector3[2];
    }

    public void Jump()
    {
        jumpPosition[0] = transform.position + new Vector3(0, 1, 0);
        jumpPosition[1] = jumpPosition[0] + new Vector3(0, 0, 1);

        transform.DOPath(jumpPosition, .2f, PathType.CatmullRom).OnComplete(CompleteJump);
    }

    void CompleteJump()
    {
        StaticScript.isJumping = false;
    }

    public void SideMove(float sidePosition)
    {
        if (StaticScript.isSideMoving && !isSideMoving&& !StaticScript.endGame)
        {
            isSideMoving = true;
            jumpPosition[0] = transform.position + new Vector3(0, .7f, 0);
            jumpPosition[1] = jumpPosition[0] + new Vector3(sidePosition, -.7f, 0);

            transform.DOPath(jumpPosition, .2f, PathType.CatmullRom).OnComplete(CompleteSideMove);
        }
    }

    void CompleteSideMove()
    {
        StaticScript.isSideMoving = false;
        isSideMoving = false;
        if (transform.position.x > 5.5f || transform.position.x < -5.5f)
            HitPlayer();
    }

    public void HitPlayer()
    {
        EventManager.SendPlayerDied();
        trail.enabled = false;
        meshRenderer.enabled = false;
        sphereColl.enabled = false;
        particle.Play();
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if (!StaticScript.isSideMoving)
                    StaticScript.isSideMoving = true;
                if (touch.deltaPosition.x > 3)
                {
                    SideMove(1);
                }

                if (touch.deltaPosition.x < -3)
                {
                    SideMove(-1);
                }
            }
        }
    }
}