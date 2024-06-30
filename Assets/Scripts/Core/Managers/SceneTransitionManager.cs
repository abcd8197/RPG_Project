using System.Collections;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public enum ESceneType { BeforeInitialize = -1, Title, Main, Empty}


    #region ## Fields ##
    private ESceneType m_CurrentScene = ESceneType.BeforeInitialize;
    private Coroutine m_LoadSceneCoroutine = null;
    #endregion

    #region Properties
    public ESceneType CurrentScene { get => m_CurrentScene; }

    #endregion

    public void LoadScene(ESceneType nextScene)
    {
         m_LoadSceneCoroutine = StartCoroutine(LoadSceneCoroutine(nextScene));
    }

    private IEnumerator LoadSceneCoroutine(ESceneType nextScene)
    {
        AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)ESceneType.Empty);
        async.allowSceneActivation = true;

        while(async.progress < 0.9f)
        {
            yield return null;
        }



        yield return null;
        m_LoadSceneCoroutine = null;
    }
}
