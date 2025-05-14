using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class StageselectUI : BaseUI
{
    [Header("Buttons")]
    [SerializeField] private Button backBtn;
    [SerializeField] private List<Button> stageButtons;

    private void Awake()
    {

        backBtn.onClick.AddListener(GameManager.Instance.ReturnToStartMenu);

        for (int i = 0; i < stageButtons.Count; i++)
        {
            int selectedStage = i;
            stageButtons[i].onClick.AddListener(() => GameManager.Instance.StartGame(selectedStage));
            stageButtons[i].interactable = (i <= GameManager.Instance.ClearedStage + 1);

            int savedStars = 0;
            if (SaveSystem.LoadGame() != null)
            {
                var starData = SaveSystem.LoadGame().stageStars.Find(s => s.stageIndex == i);
                if (starData != null)
                {
                    savedStars = Mathf.Clamp(starData.stars, 0, 5);
                }
            }

            Transform starUI = stageButtons[i].transform.Find("StarUI");

            for (int j = 0; j <= 5; j++)
            {
                Transform starGroup = starUI.Find($"Star{j}");
                if (starGroup != null)
                {
                    Transform emptyStar = starGroup.Find("EmptyStar");
                    Transform fullStar = starGroup.Find("Star");

                    if (emptyStar != null) emptyStar.gameObject.SetActive(true);
                    if (fullStar != null) fullStar.gameObject.SetActive(j <= savedStars);
                }

            }
        }
    }
}
