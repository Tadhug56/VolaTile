using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game6UpgradeMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI upgradeCostBpsUI;
    [SerializeField] TextMeshProUGUI upgradeCostTargetingRangeUI;
    [SerializeField] TextMeshProUGUI upgradeCostDamageUI;
    [SerializeField] Animator anim;
    [SerializeField] private Button upgradeMenuButon;
    [SerializeField] private GameObject menu;

    private Game6Menu game6Menu;
    public static Game6UpgradeMenu main;

    public bool isUpgradeMenuOpen = false;
    private int upgradeCostBps;
    private int upgradeCostTargetingRange;
    private int upgradeCostDamage;

    private void Awake()
    {
        main = this;
    }

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

        upgradeCostBpsUI.text = "FireRate " + upgradeCostBps.ToString();
        upgradeCostTargetingRangeUI.text = "Range " + upgradeCostTargetingRange.ToString();
        upgradeCostDamageUI.text = "Damage " + upgradeCostDamage.ToString();
    }

    public void UpdateCosts(int[] _upgradeCosts)
    {
        upgradeCostBps = _upgradeCosts[0];
        upgradeCostTargetingRange = _upgradeCosts[1];
        upgradeCostDamage = _upgradeCosts[2];
    }

    public void SetSelected()
    {

    }
}
