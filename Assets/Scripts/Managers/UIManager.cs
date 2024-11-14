using UnityEngine;
using TMPro;

public class UIManager : GenericSingleton<UIManager>
{
    [Header("플레이어 스탯")]
    //public TextMeshProUGUI cleanlinessText; 

    [Header("통화")]
    public TextMeshProUGUI currencyText;   

    [Header("메뉴")]
    public GameObject buildMenu;
    public GameObject shopMenu;

    

    private void Start()
    {
        UpdateCleanlinessUI(100);
        UpdateCurrencyUI(0);     
    }


    // 청결도를 업데이트
    public void UpdateCleanlinessUI(int cleanliness)
    {
    }

    // 돈 업데이트
    public void UpdateCurrencyUI(int currencyAmount)
    {
        currencyText.text = $"{currencyAmount}골드";
    }

    public void ToggleBuildMenu(bool isActive)
    {
        buildMenu.SetActive(isActive);
    }

    public void ToggleShopMenu(bool isActive)
    {
        shopMenu.SetActive(isActive);
    }

}
