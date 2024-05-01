using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Multiplayer
{
    public class MenuManager : MonoBehaviour {
        public static MenuManager instance;
        public List<Menu> menus;
        private void Start() {
            instance = this;
        }
        public void ToggleMenu(string menuName) {
            foreach (Menu menu in menus)
            {
                if(menu.MenuName == menuName) {
                    menu.OpenMenu();
                }     
                else {
                    menu.CloseMenu();
                }
            }
        }
    }
}