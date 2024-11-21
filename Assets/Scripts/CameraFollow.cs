using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    private string _player = "Player";
    private float minX = -25f, maxX = 25f;

    private void Start()
    {
        player = GameObject.FindWithTag(_player)?.transform; 
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            tempPos = transform.position;
            tempPos.x = player.position.x;

            if (tempPos.x < minX)
                tempPos.x = minX;
            if (tempPos.x > maxX)
                tempPos.x = maxX;

            transform.position = tempPos;
        }
    }
}
