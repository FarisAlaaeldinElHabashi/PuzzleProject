using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public PuzzleCube[] cubes; // Assign in Inspector
    public TMP_Text messageText; // Drag your MessageText UI object here
    public AudioClip successSound; // Optional win sound
    public float resetDelay = 4f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        messageText.text = "";
    }

    public void CheckPuzzleCompletion()
    {
        foreach (var cube in cubes)
        {
            if (!cube.IsPlaced())
                return;
        }

        OnPuzzleComplete();
    }

    void OnPuzzleComplete()
    {
        messageText.text = "🎉 Puzzle Completed!";
        if (successSound != null)
            audioSource.PlayOneShot(successSound);

        Debug.Log("Puzzle Completed!");

        // Reset puzzle after delay
        Invoke(nameof(RestartPuzzle), resetDelay);
    }

    public void RestartPuzzle()
    {
        foreach (var cube in cubes)
        {
            cube.ResetCube();
        }

        messageText.text = "";
    }
}
