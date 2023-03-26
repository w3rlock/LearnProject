using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, IMainMenuView
{

    public IMainMenuPresenter _presenter;

    [SerializeField]
    private Button startButton;

    public MainMenuView(){
        _presenter = new MainMenuPresenter(this);
    }

    void Start(){
        startButton.onClick.AddListener(_presenter.StartGame);
    }

}
