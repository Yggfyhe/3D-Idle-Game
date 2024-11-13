using UnityEngine;
using TMPro;

public class UIManager : GenericSingleton<UIManager>
{
    [Header("�÷��̾� ����")]
    public TextMeshProUGUI cleanlinessText; 

    [Header("��ȭ")]
    public TextMeshProUGUI currencyText;   

    [Header("�޴�")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

    

    private void Start()
    {
        UpdateCleanliness(100); 
        UpdateCurrency(0);     
    }


    // û�ᵵ�� ������Ʈ
    public void UpdateCleanliness(int cleanliness)
    {
        cleanlinessText.text = $"Cleanliness: {cleanliness}";
    }

    // �� ������Ʈ
    public void UpdateCurrency(int currencyAmount)
    {
        currencyText.text = $"Currency: {currencyAmount}";
    }

    // ���� �޴� Ȱ��ȭ/��Ȱ��ȭ
    public void ToggleMainMenu(bool isActive)
    {
        mainMenu.SetActive(isActive);
    }

    // �ɼ� �޴� Ȱ��ȭ/��Ȱ��ȭ
    public void ToggleOptionsMenu(bool isActive)
    {
        optionsMenu.SetActive(isActive);
    }

    // �˸� �Ǵ� �˾� â ������ �̰����� �߰� ����
}
