using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Serializeable Fields
    [SerializeField] private float minX, maxX;
    #endregion

    #region Private Fields
    private Transform player;
    private Vector3 tempPos;
    #endregion

    #region Monobehaviour Callbacks
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX) tempPos.x = minX;
        if (tempPos.x > maxX) tempPos.x = maxX;
        transform.position = tempPos;
    }
    #endregion
}
