using UnityEngine;
using TMPro;

public class UIManager : GenericSingleton<UIManager>
{
    [Header("플레이어 스탯")]
    public TextMeshProUGUI cleanlinessText; 

    [Header("통화")]
    public TextMeshProUGUI currencyText;   

    [Header("메뉴")]
    public GameObject mainMenu;
    public GameObject optionsMenu;

    

    private void Start()
    {
        UpdateCleanliness(100); 
        UpdateCurrency(0);     
    }


    // 청결도를 업데이트
    public void UpdateCleanliness(int cleanliness)
    {
        cleanlinessText.text = $"Cleanliness: {cleanliness}";
    }

    // 돈 업데이트
    public void UpdateCurrency(int currencyAmount)
    {
        currencyText.text = $"Currency: {currencyAmount}";
    }

    // 메인 메뉴 활성화/비활성화
    public void ToggleMainMenu(bool isActive)
    {
        mainMenu.SetActive(isActive);
    }

    // 옵션 메뉴 활성화/비활성화
    public void ToggleOptionsMenu(bool isActive)
    {
        optionsMenu.SetActive(isActive);
    }

    // 알림 또는 팝업 창 관리도 이곳에서 추가 가능
}
