using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("MagicBoxScene");
    }
}
