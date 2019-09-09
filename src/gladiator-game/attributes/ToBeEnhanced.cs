using System;

public class ToBeEnhanced : Attribute  
{

    private string toChange;
    
    public ToBeEnhanced(string toChange)
    {
        this.toChange = toChange;
    }

    public override string ToString()
    {
        return this.toChange;
    }

}