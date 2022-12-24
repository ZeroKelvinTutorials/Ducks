
public class MamaDuck : Duck
{
    //Adds her to the duck list at the first index
    //this guarantees she's first in the duck row.
    //In case of several mama ducks, 
    //they will all go before the other ducks
    public override void OnEnable()
    {
        DuckManager.Ducks.Insert(0, this);
    }
}
