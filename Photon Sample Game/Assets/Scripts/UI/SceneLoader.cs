using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private Slider _loadProgress;

    private static SceneLoader _loader;

    private AsyncOperation _loadSceneOperation;

    private void OnStartLoad()
    {
        //...
    }

    private void OnComplitedLoad(AsyncOperation operation)
    {
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        _loadProgress.value = _loadSceneOperation.progress;
    }

    private void Awake()
    {
        _loader = this;
        DontDestroyOnLoad(this);
    }

    public static void LoadScene(int index)
    {
        if (_loader == null)
            Instantiate(Resources.Load("other/LoadingScreen"));

        _loader._loadSceneOperation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        _loader.OnStartLoad();
        _loader._loadSceneOperation.completed += _loader.OnComplitedLoad;
    }
}
