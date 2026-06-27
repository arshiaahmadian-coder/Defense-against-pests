using UnityEngine;

public class SelectOutline : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private GameObject outlineObject;
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundMask))
        {
            Player.instance.selectedTile = hit.transform.gameObject.GetComponent<BaseTile>();
            outlineObject.transform.position = hit.transform.position;
        }
    }
}
