using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    private string _player = "Player";
    private void Start()
    {
        player = GameObject.FindWithTag(_player).transform;
    }
    private void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        transform.position = tempPos;
    }

}
