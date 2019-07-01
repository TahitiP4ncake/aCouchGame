using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSettings : MonoSingleton<PlayerSettings> {
    public Difficulty easy;
    public Difficulty medium;
    public Difficulty hard;

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