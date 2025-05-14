using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [System.Serializable]
    public class UIEntry
    {
        public UIType type;
        public BaseUI ui;
    }

    [SerializeField] private List<UIEntry> uiEntries;

    private Dictionary<UIType, BaseUI> uiDict;
    private UIType currentUI = UIType.None;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        uiDict = new Dictionary<UIType, BaseUI>();
        foreach (var entry in uiEntries)
        {
            if (entry.ui == null)
            {
                Debug.LogError($"UIManager: {entry.type} UI가 할당되지 않았습니다.");
                continue;
            }

            uiDict[entry.type] = entry.ui;
            entry.ui.Hide();
        }
    }

    public void OpenUI(UIType type)
    {
        Debug.Log($"Opening UI: {type}");
        if (currentUI != UIType.None)
            uiDict[currentUI].Hide();

        if (uiDict.TryGetValue(type, out var uI))
        {
            uI.Show();
            currentUI = type;
        }
    }

    public void CloseCurrentUI()
    {
        if (currentUI != UIType.None)
        {
            uiDict[currentUI].Hide();
            currentUI = UIType.None;
        }
    }
}
