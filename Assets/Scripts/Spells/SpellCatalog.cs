using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Spells/Catalog")]
public class SpellCatalog : ScriptableObject
{
    public List<SpellData> allSpellsList;

    public SpellData getSpellByID(int id){
        foreach (SpellData s in allSpellsList){
            if(s.id == id){
                return s;
            }
        }

        return null;
    }


}
