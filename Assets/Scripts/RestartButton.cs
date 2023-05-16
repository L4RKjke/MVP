using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _restart;

    private void OnEnable()
    {
        _restart.onClick.AddListener(OnReloadClick);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(OnReloadClick);
    }

    private void OnReloadClick()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}