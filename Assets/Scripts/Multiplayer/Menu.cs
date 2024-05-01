using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Multiplayer
{
    public class Menu : MonoBehaviour {
        public string MenuName;
        public void OpenMenu() {
            gameObject.SetActive(true);
        }
        public void CloseMenu() {
            gameObject.SetActive(false);
        }
    }
}