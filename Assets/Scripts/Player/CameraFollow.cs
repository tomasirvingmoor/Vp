using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _cameraSpeed;


    void Update()
    {
      transform.position = (Vector3.Lerp(transform.position, new Vector3 (_player.position.x, _player.position.y, -10), _cameraSpeed));
    }
}
