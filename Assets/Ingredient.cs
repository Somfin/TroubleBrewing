﻿public class Reageant{

    public enum Ingredient
    {
        // Basic ingredients
        RED_BERRIES,
        BLUE_BERRIES,
        KINGS_ROOT,
        GILLIWEED,
        DEAD_MANS_BONE,
        NEWT,
        HELLAPINO,
        FAERIE_DUST,
        DRAGON_HEART,
        WITCHS_EYE,
        LOVERS_ROSE,
        CRYSTAL_SHARD,
        // Combination ingredients
        RED_QUEEN,
        BLOODY_BONE,
        BLUE_SKY,
        SMURF_POWDER,
        CROWN_JEWELS,
        KING_NEWT,
        GOOD_TIME,
        BURRITO_MIX,
        IMAGINATION,
        SUPER_NEWT,
        CRYSTAL_LIZARD,
        PSEUDODRAGON,
        FLU_POWDER,
        DREAM_POWDER,
        MONTYS_PYTHON,
        HAYFEVER,
        PHEROMONES,
        TRUE_LOVE,
        // Cooked ingredients
        BLACK_BERRIES,
        BRAISED_ROOT,
        ARCANE_HAZE,
        BBQ_RIBS,
        TOASTED_NEWT,
        DARK_CRYSTAL,
        FIERY_DOOM,
        PIXIE_DUST,
        HEART_OF_COURAGE,
        SALAMANDERS_EYE,
        BROKEN_HEART,
        // Processed ingredients
        RED_BERRY_JUICE,
        BLUE_BERRY_PASTE,
        DICED_REGICIDE,
        POND_SCUM,
        BONE_MARROW_EXTRACT,
        NEWTS_TAIL,
        CRYSTAL_POWDER,
        TABASCO_SAUCE,
        REALITY,
        DRAGONS_HEARTSTRINGS,
        EVIL_EYE,
        WEDDING_RING,
        // Wombo combos
        NEWTZILLA,
        BLOODY_MARY,
        FINGER_LICKIN_GOODNESS,
        HEART_OF_DARKNESS,
        ETERNAL_YOUTH,
        SOCIETAL_EXPECTATIONS,
        BALANCED_BREAKFAST,
        TROPHY_WIFE,
        BRAVEHEART,
        DEVILS_HOOF,
        BITTERSWEET_SYMPHONY,
        MEXICAN_STANDOFF,
        OFFSPRING,
        // Catalysts
        OBELISK_OF_CHRONOS,
        ENERGY_CRYSTAL,
        DRAGON_SKULL
    }

    public static bool isCatalyst(Ingredient i)
    {
        return i >= Ingredient.OBELISK_OF_CHRONOS;
    }
}
