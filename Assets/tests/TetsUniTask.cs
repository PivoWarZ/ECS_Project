using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TetsUniTask : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    void Start()
    {
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TestsTask().Forget();
        }
    }

    private async UniTaskVoid TestsTask()
    {
        _button.image.color = Color.white;
        await UniTask.WaitForSeconds(2f);
        _button.image.color = Color.blue;
        await UniTask.WaitForSeconds(2f);
        _button.image.color = Color.red;
        await UniTask.WaitForSeconds(2f);
        _button.image.color = Color.white;
        int count = 10;
        do
        {
            _text.text = count.ToString();
            await UniTask.WaitForSeconds(0.5f);
            count--;

        } while (count > 0);
    }
}
