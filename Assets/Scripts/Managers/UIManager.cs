using UnityEngine;
using TMPro;

public class UIManager : GenericSingleton<UIManager>
{
    [Header("�÷��̾� ����")]
    //public TextMeshProUGUI cleanlinessText; 

    [Header("��ȭ")]
    public TextMeshProUGUI currencyText;   

    [Header("�޴�")]
    public GameObject buildMenu;
    public GameObject shopMenu;

    

    private void Start()
    {
        UpdateCleanliness(100); 
        UpdateCurrency(0);     
    }


    // û�ᵵ�� ������Ʈ
    public void UpdateCleanliness(int cleanliness)
    {
    }

    // �� ������Ʈ
    public void UpdateCurrency(int currencyAmount)
    {
        currencyText.text = $"{currencyAmount}���";
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
