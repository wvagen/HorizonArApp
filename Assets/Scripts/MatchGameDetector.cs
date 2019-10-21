
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchGameDetector : MonoBehaviour
{
    public MeshRenderer detectableObject;

    void LateUpdate()
    {
        if (detectableObject.enabled) SceneManager.LoadScene("QuizGameMatching");
    }
}
