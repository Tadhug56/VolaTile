using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game6UpgradeMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;
    [SerializeField] private Button upgradeMenuButon;
    [SerializeField] private GameObject menu;

    private Game6Menu game6Menu;

    public bool isUpgradeMenuOpen = false;

    private void Start()
    {
        game6Menu = menu.GetComponent<Game6Menu>();
        upgradeMenuButon.gameObject.SetActive(false);
    }

    public void ToggleMenu()
    {
        isUpgradeMenuOpen = !isUpgradeMenuOpen;
        anim.SetBool("upgradeMenuOpen", isUpgradeMenuOpen);

        if(isUpgradeMenuOpen == false)
        {
            upgradeMenuButon.gameObject.SetActive(false);
            game6Menu.ToggleMenu();
        }

        else
        {
            upgradeMenuButon.gameObject.SetActive(true);
        }
    }

    private void OnGUI()
    {
        currencyUI.text = Game6Manager.main.currency.ToString();
    }

    public void SetSelected()
    {

    }
}
