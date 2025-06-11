using UnityEngine;

public class CubePlaceholder : MonoBehaviour
{
    public CubeColor color; // assign this in Inspector
    public Transform snapTarget; // assign this to a child transform that marks the snap position
    public AudioClip errorSound; // drag a "buzz" sound here in Inspector

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PuzzleCube cube = other.GetComponent<PuzzleCube>();
        if (cube != null && !cube.IsPlaced())
        {
            if (cube.color == this.color)
            {
                cube.LockPlacementAt(snapTarget); // snap to the correct location
            }
            else
            {
                Debug.Log("Puzzle Failed");
                PlayErrorSound();
                cube.ReturnToOriginal(); // go back to start
            }
        }
    }

    void PlayErrorSound()
    {
        if (audioSource != null && errorSound != null)
        {
            audioSource.PlayOneShot(errorSound);
        }
    }
}
