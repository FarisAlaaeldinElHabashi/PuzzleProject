using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleCube : MonoBehaviour
{
    public CubeColor color;
    public Transform originalPosition;

    private XRGrabInteractable grab;
    private bool placed = false;

    private PuzzleManager manager;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        originalPosition = new GameObject($"{name}_OriginalPos").transform;
        originalPosition.position = transform.position;
        originalPosition.rotation = transform.rotation;
        manager = FindObjectOfType<PuzzleManager>();


    }

    public void ReturnToOriginal()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // disable physics before moving
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;

        rb.isKinematic = false; // re-enable physics
    }

    public void ResetCube()
    {
        placed = false;
        grab.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        ReturnToOriginal();
    }
    public void LockPlacementAt(Transform target)
    {
        placed = true;
        grab.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Snap to exact target position and rotation
        transform.position = target.position;
        transform.rotation = target.rotation;

        if (manager != null)
        {
            manager.CheckPuzzleCompletion();
        }
    }



    public bool IsPlaced() => placed;


}

