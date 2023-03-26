using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuPresenter : IMainMenuPresenter
{

    public IMainMenuView _mainMenuView;

    public MainMenuPresenter(IMainMenuView view){
        _mainMenuView = view;
    }

    public void StartGame(){
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
