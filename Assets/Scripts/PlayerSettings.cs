using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSettings : MonoSingleton<PlayerSettings> {
    private GameManager gm { get { return GameManager.instance; } }
    private Couch playCouch { get { return CouchManager.instance.playCouch; } }

    public Difficulty easy;
    public Difficulty medium;
    public Difficulty hard;

    [HideInInspector]
    public Difficulty difficulty;

    public List<Body> players;

    public Cushion maxParts {
        get {
            return new Cushion (
                players.Select(x => x.ToCushion().AmountOf(BodyPartType.HANDS)).ToList().Sum(),
                players.Select(x => x.ToCushion().AmountOf(BodyPartType.FEET)).ToList().Sum(),
                players.Select(x => x.ToCushion().AmountOf(BodyPartType.BUTTS)).ToList().Sum(),
                players.Select(x => x.ToCushion().AmountOf(BodyPartType.HEADS)).ToList().Sum()
            );
        }
    }


}