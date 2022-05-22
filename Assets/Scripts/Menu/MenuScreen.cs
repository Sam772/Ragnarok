using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour {
    protected Menu Menu { get; private set; }
        
    public void Setup(Menu menu) {
        Menu = menu;
    }
        
    public void Show() {
        gameObject.SetActive(true);
        OnShow();
    }

    public void Hide() {
        gameObject.SetActive(false);
        OnHide();
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}