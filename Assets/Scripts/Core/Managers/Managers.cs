using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers sInstance = null;
    public static Managers Instance
    {
        get
        {
            if (IsApplicationQuitting)
                return null;

            return sInstance;
        }
    }

    #region Static Fields
    private static bool IsApplicationQuitting = false;
    #endregion

    #region Managers
    private AddressableManager _addressable;
    private ResourceManager _resource;
    private SceneTransitionManager _scene;

    public static AddressableManager Addressable { get => Instance._addressable; }
    public static ResourceManager Resource { get => Instance._resource; }
    public static SceneTransitionManager Scene { get => Instance._scene; }
    #endregion


    #region Behaviours
    private void OnDestroy()
    {
        IsApplicationQuitting = true;
    }
    #endregion

    #region Static Methods

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (sInstance != null)
            return;

        sInstance = new GameObject("_Managers").AddComponent<Managers>();
        DontDestroyOnLoad(sInstance.gameObject);
    }
    #endregion
}
