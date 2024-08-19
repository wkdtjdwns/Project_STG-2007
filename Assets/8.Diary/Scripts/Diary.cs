using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text indexText;
    [SerializeField] private Text diaryText;

    private DiaryManager diaryManager;

    private void Awake()
    {
        diaryManager = GameObject.Find("DiaryManager").GetComponent<DiaryManager>();
    }

    // �ϱ� �ý��� �ֱ�
}
