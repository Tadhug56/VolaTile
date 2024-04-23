using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game6Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject upgradeMenu;

    private Game6UpgradeMenu game6UpgradeMenu;

    private bool isMenuOpen = false;

    private void Start()
    {
        game6UpgradeMenu = upgradeMenu.GetComponent<Game6UpgradeMenu>();
    }

    private void Update()
    {
        if(game6UpgradeMenu.isUpgradeMenuOpen == true)
        {
            menuButton.gameObject.SetActive(false);
        }

        else
        {
            menuButton.gameObject.SetActive(true);
        }
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }

    private void OnGUI()
    {
        currencyUI.text = Game6Manager.main.currency.ToString();
    }

    public void SetSelected()
    {

    }
}
