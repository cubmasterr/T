using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour
{
    [HideInInspector] public cellState state;
    private Image _image;
    [SerializeField] private Sprite [] _sprites;
    private void Awake()
    {
        _image = GetComponent<Image>(); 
    }
    public void PlayerSetCell()
    {
        if (state != cellState.empty)
        {
            return;
        }
        SetCell(cellState.cros);
    }
    public void SetCell(cellState newState)
    {
        if (state != cellState.empty)
        {
            return;
        }
        state=newState;
        switch(newState) 
        { 
            case cellState.cros:
                _image.sprite = _sprites[0];
                Field.instance.EnemyTurn();
                break;
            case cellState.nught:
                _image.sprite = _sprites[1];
                break;
        }

    }
}
public enum cellState
{
    empty,
    cros,
    nught
}