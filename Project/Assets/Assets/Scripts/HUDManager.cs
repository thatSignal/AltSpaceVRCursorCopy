using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    private static GameObject _go_Instance;
    private static HUDManager _s_Instance;

    public Canvas ReticleMessage;

	public static HUDManager Instance()
    {
        if(_s_Instance == null)
        {
            if(_go_Instance == null)
            {
                _go_Instance = new GameObject("MAN_HUD");
            }

            if(_go_Instance.GetComponent<HUDManager>() == null)
            {
                _go_Instance.AddComponent<HUDManager>();
            }

            _s_Instance = _go_Instance.GetComponent<HUDManager>();
            DontDestroyOnLoad(_go_Instance);
        }

        return _s_Instance;
    }


}
