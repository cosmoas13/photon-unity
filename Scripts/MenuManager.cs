using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[CreateAssetMenu(fileName = "MenuManager", menuName = "Managers/MenuManager")]
public class MenuManager : ScriptableObject
{
    public static bool isWalking = true;
    #region Public Methods
    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
        isWalking = true;
    }

    public void OpenMenuForChat(GameObject menu)
    {
        menu.SetActive(true);
        isWalking = false;
    }
    #endregion
}
