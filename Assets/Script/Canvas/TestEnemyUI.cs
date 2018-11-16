using UnityEngine;
using UnityEngine.UI;

public class TestEnemyUI : MonoBehaviour
{
    [HideInInspector]public GameObject TargetObject;
    Charactor chara_cmp;
    private Transform targetTfm;

    RectTransform myRectTfm;
    public Vector3 pos_offset;

    //α値変更用のやつ
    Image[] sprite;

    private Text targetText;
    void Start()
    {
        sprite = GetComponentsInChildren<Image>();
        foreach (Image s in sprite)
        {
            s.color = new Color(1, 1, 1, 0);
        }
        if (TargetObject != null)
        {
            targetTfm = TargetObject.transform;
            chara_cmp = TargetObject.GetComponent<Charactor>();
        }
        myRectTfm = GetComponent<RectTransform>();
        //targetText = GetComponent<Text>();

    }

    void Update()
    {
        if (targetTfm != null)
        {
            myRectTfm.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + pos_offset);
            //移動させてから非表示を解除
            foreach (Image s in sprite)
            {
                s.color = new Color(1, 1, 1, 1);
            }


        }
        if (chara_cmp != null)
        {
            //targetText.text = chara_cmp.status.HP.ToString();
        }
        //何故か順番が関係あるらしい↓
        if (TargetObject == null)
        {
            Destroy(this.gameObject);
        }


        //関連付けされてるオブジェクトが消えたら自身も消滅する
    }
}