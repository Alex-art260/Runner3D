using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountHealth : MonoBehaviour
{
    [SerializeField] private Text _textHealth;

    [SerializeField] private GameObject _countHealth;
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private GameObject _gameOver;

    public static int countHealth = 5;

    private void Update()
    {
        _textHealth.text = " " + countHealth;

        GameOver();
    }

    private void GameOver()
    {
        if(countHealth == 0)
        {
           _countHealth.SetActive(false);
           _slider.SetActive(false);
           _player.SetActive(false);
           _gameManager.SetActive(false);
           _gameOver.SetActive(true);
        }
    }
}
